namespace DX24Project {
	partial class Form1 {
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
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
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent() {
			this.wysiwygRichEditControl1 = new Brendel.Toolbelt.Desktop.Controls.WysiwygRichEditControl();
			this.SuspendLayout();
			// 
			// wysiwygRichEditControl1
			// 
			this.wysiwygRichEditControl1.AutoGrowPageHeight = false;
			this.wysiwygRichEditControl1.AutoTrimTrailingEmptyParagraphs = true;
			this.wysiwygRichEditControl1.Location = new System.Drawing.Point(236, 82);
			this.wysiwygRichEditControl1.Modified = true;
			this.wysiwygRichEditControl1.Name = "wysiwygRichEditControl1";
			this.wysiwygRichEditControl1.Options.DocumentSaveOptions.CurrentFormat = DevExpress.XtraRichEdit.DocumentFormat.PlainText;
			this.wysiwygRichEditControl1.Options.HorizontalRuler.Visibility = DevExpress.XtraRichEdit.RichEditRulerVisibility.Hidden;
			this.wysiwygRichEditControl1.Options.VerticalRuler.Visibility = DevExpress.XtraRichEdit.RichEditRulerVisibility.Hidden;
			this.wysiwygRichEditControl1.PageMargins = new System.Drawing.Printing.Margins(0, 0, 0, 0);
			this.wysiwygRichEditControl1.PageSize = new System.Drawing.SizeF(65F, 20F);
			this.wysiwygRichEditControl1.PageZoomMode = Brendel.Toolbelt.Desktop.Controls.WysiwygRichEditControl.ZoomMode.None;
			this.wysiwygRichEditControl1.Size = new System.Drawing.Size(401, 120);
			this.wysiwygRichEditControl1.TabIndex = 0;
			this.wysiwygRichEditControl1.Unit = DevExpress.Office.DocumentUnit.Millimeter;
			this.wysiwygRichEditControl1.Views.PrintLayoutView.MaxHorizontalPageCount = 1;
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(948, 406);
			this.Controls.Add(this.wysiwygRichEditControl1);
			this.Margin = new System.Windows.Forms.Padding(4);
			this.Name = "Form1";
			this.Text = "Ich bin DX v24.1 in NetFramework";
			this.ResumeLayout(false);

		}

		#endregion

		private Brendel.Toolbelt.Desktop.Controls.WysiwygRichEditControl wysiwygRichEditControl1;
	}
}

