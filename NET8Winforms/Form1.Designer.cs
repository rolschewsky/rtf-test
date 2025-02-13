namespace NET8Winforms {
	partial class Form1 {
		/// <summary>
		///  Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		///  Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing) {
			if (disposing && (components != null)) {
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		///  Required method for Designer support - do not modify
		///  the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent() {
			wysiwygRichEditControl1 = new Brendel.Toolbelt.Desktop.Controls.WysiwygRichEditControl();
			SuspendLayout();
			// 
			// wysiwygRichEditControl1
			// 
			wysiwygRichEditControl1.AutoGrowPageHeight = false;
			wysiwygRichEditControl1.AutoTrimTrailingEmptyParagraphs = true;
			wysiwygRichEditControl1.Location = new Point(68, 70);
			wysiwygRichEditControl1.Modified = true;
			wysiwygRichEditControl1.Name = "wysiwygRichEditControl1";
			wysiwygRichEditControl1.Options.DocumentSaveOptions.CurrentFormat = DevExpress.XtraRichEdit.DocumentFormat.PlainText;
			wysiwygRichEditControl1.Options.HorizontalRuler.Visibility = DevExpress.XtraRichEdit.RichEditRulerVisibility.Hidden;
			wysiwygRichEditControl1.Options.VerticalRuler.Visibility = DevExpress.XtraRichEdit.RichEditRulerVisibility.Hidden;
			wysiwygRichEditControl1.PageMargins = new System.Drawing.Printing.Margins(0, 0, 0, 0);
			wysiwygRichEditControl1.PageSize = new SizeF(65F, 20F);
			wysiwygRichEditControl1.PageZoomMode = Brendel.Toolbelt.Desktop.Controls.WysiwygRichEditControl.ZoomMode.None;
			wysiwygRichEditControl1.Size = new Size(600, 300);
			wysiwygRichEditControl1.TabIndex = 0;
			wysiwygRichEditControl1.Unit = DevExpress.Office.DocumentUnit.Millimeter;
			wysiwygRichEditControl1.Views.PrintLayoutView.MaxHorizontalPageCount = 1;
			// 
			// Form1
			// 
			AutoScaleDimensions = new SizeF(9F, 19F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(800, 450);
			Controls.Add(wysiwygRichEditControl1);
			Name = "Form1";
			Text = "Ich bin DX v24.1 in NET8";
			ResumeLayout(false);
		}

		#endregion

		private Brendel.Toolbelt.Desktop.Controls.WysiwygRichEditControl wysiwygRichEditControl1;
	}
}
