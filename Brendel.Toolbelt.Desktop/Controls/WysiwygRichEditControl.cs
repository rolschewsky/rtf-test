using System.ComponentModel;
using System.Drawing.Printing;
using System.Media;
using DevExpress.Drawing.Printing;
using DevExpress.Office;
using DevExpress.Utils.Controls;
using DevExpress.XtraEditors;
using DevExpress.XtraPrinting.Drawing;
using DevExpress.XtraPrinting.Native;
using DevExpress.XtraRichEdit;
using DevExpress.XtraRichEdit.API.Native;
using DevExpress.XtraRichEdit.Commands;
using DevExpress.XtraRichEdit.Localization;

namespace Brendel.Toolbelt.Desktop.Controls;

[Description("Ein einfaches Rich Text Feld")]
public class WysiwygRichEditControl : RichEditControl, IXtraResizableControl {
	#region IXtraResizableControl

	Size IXtraResizableControl.MinSize => Size;

	Size IXtraResizableControl.MaxSize => Size;

	bool IXtraResizableControl.IsCaptionVisible => false;

	private event EventHandler? _changed;

	event EventHandler? IXtraResizableControl.Changed {
		add => this._changed += value;
		remove => this._changed -= value;
	}

	#endregion

	private SizeF _pageSize = new(148, 105);
	private MarginsF _pageMargins = new(0, 0, 0, 0);
	private bool _hasOverflow;
	private bool _isTrimming;
	private int _paragraphCount;
	private CancellationTokenSource? _fitPageCts;

	/// <summary>
	/// Ränder der Seite in Millimeter
	/// </summary>
	[Description("Ränder der Seite in Millimeter")]
	[Category("Page")]
	public MarginsF PageMargins {
		get => _pageMargins;
		set {
			if (Equals(_pageMargins, value)) {
				return;
			}

			_pageMargins = value;
			UpdatePageMargins(_pageMargins);
		}
	}

	/// <summary>
	/// Legt die Größe der Seite in fest, die Einheit bezieht sich auf das Feld <see cref="WysiwygRichEditControl.Unit"/>
	/// </summary>
	[Description("Legt die Größe der Seite in fest, die Einheit bezieht sich auf das Feld Unit")]
	[Category("Page")]
	public SizeF PageSize {
		get => _pageSize;
		set {
			if (Equals(_pageSize, value)) {
				return;
			}

			_pageSize = value;
			UpdatePageSize(_pageSize);
		}
	}

	/// <summary>
	/// Legt fest ob die Seite mit der Eingabe in die Höhe wächst
	/// </summary>
	[Description("Legt fest ob die Seite mit der Eingabe in die Höhe wächst")]
	[Category("Page")]
	public bool AutoGrowPageHeight { get; set; }

	/// <summary>
	/// Automatischer Zoom der Seite, an die größe des Controls
	/// </summary>
	[Description("Automatischer Zoom der Seite, an die größe des Controls")]
	[Category("Page")]
	public ZoomMode PageZoomMode { get; set; }

	/// <summary>
	/// Legt fest, ob leere Absätze am Ende automatisch abgeschnitten werden.
	/// </summary>
	[Description("Legt fest, ob leere Absätze am Ende automatisch abgeschnitten werden.")]
	[Category("Page")]
	public bool AutoTrimTrailingEmptyParagraphs { get; set; } = true;

	[Browsable(false)]
	public bool HasOverflow {
		get => _hasOverflow;
		private set {
			if (Equals(_hasOverflow, value)) {
				return;
			}

			_hasOverflow = value;

			if (_hasOverflow) {
				Views.PrintLayoutView.BackColor = Color.Red;
				SystemSounds.Hand.Play();
				XtraMessageBox.Show("Der Inhalt dieser Text-Box ist zu lang und kann nicht vollständig verarbeitet/angezeigt werden.", "Inhaltsbegrenzung", MessageBoxButtons.OK, MessageBoxIcon.Warning);
			} else {
				Views.PrintLayoutView.BackColor = Color.White;
			}
		}
	}

	[Bindable(true)]
	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new string? RtfText {
		get => base.RtfText;
		set {
			base.RtfText = value;
			BeginInvoke(() => UpdatePageMargins(PageMargins));
			BeginInvoke(() => UpdatePageSize(PageSize));
		}
	}

	public WysiwygRichEditControl() {
		Unit = DocumentUnit.Millimeter;
		Options.HorizontalScrollbar.Visibility = RichEditScrollbarVisibility.Auto;
		Options.HorizontalRuler.Visibility = RichEditRulerVisibility.Hidden;
		Options.VerticalScrollbar.Visibility = RichEditScrollbarVisibility.Auto;
		Options.VerticalRuler.Visibility = RichEditRulerVisibility.Hidden;

		InitializeDocument += (_, _) => OnInitializeDocument();
		ContentChanged += (_, _) => OnContentChanged();
		Views.PrintLayoutView.PageCountChanged += (_, _) => OnPageCountChanged();
		Views.PrintLayoutView.MaxHorizontalPageCount = 1;
		OnInitializeDocument();
	}

	private CancellationTokenSource? _trimDebounceCts;

	public void ExecuteDebouncedTrimTrailingEmptyParagraphs(TimeSpan? debounceDelay = null) {
		var delay = debounceDelay ?? TimeSpan.FromMilliseconds(250);
		_trimDebounceCts?.Cancel();
		var token = (_trimDebounceCts = new()).Token;
		Task.Delay(delay, token).ContinueWith(_ => {
			if (token.IsCancellationRequested) {
				return;
			}

			_isTrimming = true;
			var isUpdatingDocument = false;

			foreach (var paragraph in Document.Paragraphs.Reverse()) {
				// prüft ob der Cursor in dem Absatz ist
				if (paragraph.Range.Contains(Document.CaretPosition)) {
					break;
				}

				// prüft ob der Absatz leer ist
				var paragraphText = Document.GetText(paragraph.Range);
				if (!string.IsNullOrWhiteSpace(paragraphText)) {
					break;
				}

				// Dokument in Update-Modus versetzen, damit sukzessive Änderungen schneller durchgeführt werden können
				if (!isUpdatingDocument) {
					isUpdatingDocument = true;
					BeginUpdate();
				}

				Document.Delete(paragraph.Range);
			}

			if (isUpdatingDocument) {
				EndUpdate();
			}

			_isTrimming = false;
		}, token, TaskContinuationOptions.OnlyOnRanToCompletion, TaskScheduler.FromCurrentSynchronizationContext());
	}

	protected override void OnSizeChanged(EventArgs e) {
		base.OnSizeChanged(e);
		_changed?.Invoke(this, EventArgs.Empty);
		ExecuteDebouncedFitWidthCommand();
	}

	protected override void Dispose(bool disposing) {
		if (disposing) {
			_fitPageCts?.Cancel();
			_fitPageCts?.Dispose();
			_fitPageCts = null;
		}

		base.Dispose(disposing);
	}

	private void ExecuteDebouncedFitWidthCommand(TimeSpan? delay = null) {
		_fitPageCts?.Cancel();

		if (PageZoomMode == ZoomMode.None) {
			return;
		}

		var token = (_fitPageCts = new CancellationTokenSource()).Token;
		var delayOrDefault = delay ?? TimeSpan.FromMilliseconds(250);
		Task.Delay(delayOrDefault, token).ContinueWith(_ => {
			if (token.IsCancellationRequested) {
				return;
			}

			var cmd = new FitToPageCommand(this, PageZoomMode);
			cmd.Execute();
		}, token, TaskContinuationOptions.OnlyOnRanToCompletion, TaskScheduler.FromCurrentSynchronizationContext());
	}

	private void OnContentChanged() {
		if (!_isTrimming && AutoTrimTrailingEmptyParagraphs) {
			ExecuteDebouncedTrimTrailingEmptyParagraphs();
		}

		if (!_isTrimming) {
			var paragraphCount = Document.Paragraphs.Count();
			if (paragraphCount != _paragraphCount) {
				_paragraphCount = paragraphCount;
				OnParagraphCountChanged();
			}
		}
	}

	private void OnInitializeDocument() {
		UpdatePageSize(PageSize);
		UpdatePageMargins(PageMargins);
		HasOverflow = false;
	}

	private SectionPage GetFirstPage() => Document.Sections.First().Page;

	private int GetPageCount() => Views.PrintLayoutView.PageCount;

	private void FitPageToContent() {
		BeginUpdate();

		// schrumpfe die Seite zurück
		if (GetPageCount() == 1) {
			while (GetPageCount() == 1) {
				var page = GetFirstPage();
				var height = page.Height - 0.25f;
				if (height < PageSize.Height) {
					UpdatePageSize(PageSize);
					break;
				}

				var size = new SizeF(page.Width, height);
				UpdatePageSize(size);
			}
		} else {
			// vergrößere die Seite
			while (GetPageCount() > 1) {
				var page = GetFirstPage();
				var size = new SizeF(page.Width, page.Height + 0.25f);
				UpdatePageSize(size);
			}
		}

		EndUpdate();
		ExecuteDebouncedFitWidthCommand();
	}

	private void OnParagraphCountChanged() {
		if (AutoGrowPageHeight) {
			FitPageToContent();
		}
	}

	private void OnPageCountChanged() {
		if (GetPageCount() <= 1) {
			HasOverflow = false;
			return;
		}

		if (AutoGrowPageHeight) {
			HasOverflow = false;
			FitPageToContent();
			return;
		}

		HasOverflow = true;
	}

	private void UpdatePageSize(SizeF size) {
		foreach (var section in Document.Sections) {
			var page = section.Page;
			page.PaperKind = DXPaperKind.Custom;
			page.Width = size.Width;
			page.Height = size.Height;
		}
	}

	private void UpdatePageMargins(MarginsF margins) {
		foreach (var section in Document.Sections) {
			section.Margins.Left = margins.Left;
			section.Margins.Right = margins.Right;
			section.Margins.Top = margins.Top;
			section.Margins.Bottom = margins.Bottom;
		}
	}

	public enum ZoomMode {
		None,
		FitWidth,
		FitHeight,
		FitPage
	}

	internal class FitToPageCommand(IRichEditControl control, ZoomMode mode) : FitToPageCommandBase(control) {
		public override XtraRichEditStringId MenuCaptionStringId => XtraRichEditStringId.MenuCmd_FitToPage;
		public override XtraRichEditStringId DescriptionStringId => XtraRichEditStringId.MenuCmd_FitToPageDescription;

		protected override float GetPreferredZoomFactor(float heightZoomFactor, float widthZoomFactor) {
			var factor = mode switch {
				ZoomMode.FitWidth  => widthZoomFactor,
				ZoomMode.FitHeight => heightZoomFactor,
				ZoomMode.FitPage   => Math.Min(heightZoomFactor, widthZoomFactor),
				_                  => throw new ArgumentOutOfRangeException(nameof(mode), mode, null)
			};

			// Zoom Faktor ein bisschen dämpfen, damit die Scrollbars besser angezeigt werden
			var koeffizient = (factor < 1 ? 4 : 2) / factor;
			var dampenedFactor = factor * (1 - +Math.Log(factor + 1) * koeffizient * 0.01);
			return (float)Math.Round(dampenedFactor, 6);
		}
	}
}