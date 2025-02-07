﻿namespace RtfTest {
	partial class SimpleRtfEditorForm {
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
			this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
			this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
			this.Root = new DevExpress.XtraLayout.LayoutControlGroup();
			this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
			this.wysiwygRichEditControl1 = new Brendel.Toolbelt.Winforms.Controls.WysiwygRichEditControl();
			this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
			((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
			this.layoutControl1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
			this.SuspendLayout();
			// 
			// layoutControl1
			// 
			this.layoutControl1.Controls.Add(this.simpleButton1);
			this.layoutControl1.Controls.Add(this.wysiwygRichEditControl1);
			this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.layoutControl1.Location = new System.Drawing.Point(0, 0);
			this.layoutControl1.Name = "layoutControl1";
			this.layoutControl1.Root = this.Root;
			this.layoutControl1.Size = new System.Drawing.Size(1117, 781);
			this.layoutControl1.TabIndex = 0;
			this.layoutControl1.Text = "layoutControl1";
			// 
			// simpleButton1
			// 
			this.simpleButton1.Location = new System.Drawing.Point(12, 737);
			this.simpleButton1.Name = "simpleButton1";
			this.simpleButton1.Size = new System.Drawing.Size(1093, 32);
			this.simpleButton1.StyleController = this.layoutControl1;
			this.simpleButton1.TabIndex = 5;
			this.simpleButton1.Text = "Export nach Report";
			this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
			// 
			// Root
			// 
			this.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
			this.Root.GroupBordersVisible = false;
			this.Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem2,
            this.layoutControlItem1});
			this.Root.Name = "Root";
			this.Root.Size = new System.Drawing.Size(1117, 781);
			this.Root.TextVisible = false;
			// 
			// layoutControlItem1
			// 
			this.layoutControlItem1.Control = this.simpleButton1;
			this.layoutControlItem1.Location = new System.Drawing.Point(0, 725);
			this.layoutControlItem1.Name = "layoutControlItem1";
			this.layoutControlItem1.Size = new System.Drawing.Size(1097, 36);
			this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
			this.layoutControlItem1.TextVisible = false;
			// 
			// wysiwygRichEditControl1
			// 
			this.wysiwygRichEditControl1.AutoGrowPageHeight = false;
			this.wysiwygRichEditControl1.AutoTrimTrailingEmptyParagraphs = true;
			this.wysiwygRichEditControl1.Location = new System.Drawing.Point(12, 12);
			this.wysiwygRichEditControl1.Modified = true;
			this.wysiwygRichEditControl1.Name = "wysiwygRichEditControl1";
			this.wysiwygRichEditControl1.Options.DocumentSaveOptions.CurrentFormat = DevExpress.XtraRichEdit.DocumentFormat.PlainText;
			this.wysiwygRichEditControl1.Options.HorizontalRuler.Visibility = DevExpress.XtraRichEdit.RichEditRulerVisibility.Hidden;
			this.wysiwygRichEditControl1.Options.VerticalRuler.Visibility = DevExpress.XtraRichEdit.RichEditRulerVisibility.Hidden;
			this.wysiwygRichEditControl1.PageMargins = new System.Drawing.Printing.Margins(0, 0, 0, 0);
			this.wysiwygRichEditControl1.PageSize = new System.Drawing.SizeF(65F, 20F);
			this.wysiwygRichEditControl1.PageZoomMode = Brendel.Toolbelt.Winforms.Controls.WysiwygRichEditControl.ZoomMode.None;
			this.wysiwygRichEditControl1.Size = new System.Drawing.Size(1093, 721);
			this.wysiwygRichEditControl1.TabIndex = 4;
			this.wysiwygRichEditControl1.Unit = DevExpress.Office.DocumentUnit.Millimeter;
			this.wysiwygRichEditControl1.Views.PrintLayoutView.MaxHorizontalPageCount = 1;
			this.wysiwygRichEditControl1.Views.PrintLayoutView.ZoomFactor = 1.251222F;
			// 
			// layoutControlItem2
			// 
			this.layoutControlItem2.Control = this.wysiwygRichEditControl1;
			this.layoutControlItem2.Location = new System.Drawing.Point(0, 0);
			this.layoutControlItem2.MinSize = new System.Drawing.Size(1, 1);
			this.layoutControlItem2.Name = "layoutControlItem2";
			this.layoutControlItem2.Size = new System.Drawing.Size(1097, 725);
			this.layoutControlItem2.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
			this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
			this.layoutControlItem2.TextVisible = false;
			// 
			// SimpleRtfEditorForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1117, 781);
			this.Controls.Add(this.layoutControl1);
			this.Name = "SimpleRtfEditorForm";
			this.Text = "RtfEditTestcs";
			((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
			this.layoutControl1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private DevExpress.XtraLayout.LayoutControl layoutControl1;
		private DevExpress.XtraLayout.LayoutControlGroup Root;
		private Brendel.Toolbelt.Winforms.Controls.WysiwygRichEditControl wysiwygRichEditControl1;
		private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
		private DevExpress.XtraEditors.SimpleButton simpleButton1;
		private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
	}
}