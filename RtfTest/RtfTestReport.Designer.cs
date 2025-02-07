namespace RtfTest {
	partial class RtfTestReport {
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

		#region Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent() {
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RtfTestReport));
			DevExpress.XtraReports.UI.XRWatermark xrWatermark1 = new DevExpress.XtraReports.UI.XRWatermark();
			this.TopMargin = new DevExpress.XtraReports.UI.TopMarginBand();
			this.BottomMargin = new DevExpress.XtraReports.UI.BottomMarginBand();
			this.Detail = new DevExpress.XtraReports.UI.DetailBand();
			this.RichText = new DevExpress.XtraReports.Parameters.Parameter();
			this.xrRichText1 = new DevExpress.XtraReports.UI.XRRichText();
			((System.ComponentModel.ISupportInitialize)(this.xrRichText1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
			// 
			// TopMargin
			// 
			this.TopMargin.Dpi = 254F;
			this.TopMargin.HeightF = 254F;
			this.TopMargin.Name = "TopMargin";
			// 
			// BottomMargin
			// 
			this.BottomMargin.Dpi = 254F;
			this.BottomMargin.HeightF = 254F;
			this.BottomMargin.Name = "BottomMargin";
			// 
			// Detail
			// 
			this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrRichText1});
			this.Detail.Dpi = 254F;
			this.Detail.HeightF = 551.1528F;
			this.Detail.HierarchyPrintOptions.Indent = 50.8F;
			this.Detail.Name = "Detail";
			// 
			// RichText
			// 
			this.RichText.AllowNull = true;
			this.RichText.Description = "Parameter1";
			this.RichText.Name = "RichText";
			// 
			// xrRichText1
			// 
			this.xrRichText1.BorderColor = System.Drawing.Color.LightCoral;
			this.xrRichText1.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
			this.xrRichText1.BorderWidth = 2F;
			this.xrRichText1.CanGrow = false;
			this.xrRichText1.CanShrink = true;
			this.xrRichText1.Dpi = 254F;
			this.xrRichText1.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Rtf", "?RichText")});
			this.xrRichText1.Font = new DevExpress.Drawing.DXFont("Arial", 9.75F);
			this.xrRichText1.LocationFloat = new DevExpress.Utils.PointFloat(472.7222F, 148.1667F);
			this.xrRichText1.Name = "xrRichText1";
			this.xrRichText1.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
			this.xrRichText1.SerializableRtfString = resources.GetString("xrRichText1.SerializableRtfString");
			this.xrRichText1.SizeF = new System.Drawing.SizeF(650F, 200F);
			this.xrRichText1.StylePriority.UseBorderColor = false;
			this.xrRichText1.StylePriority.UseBorders = false;
			this.xrRichText1.StylePriority.UseBorderWidth = false;
			// 
			// RtfTestReport
			// 
			this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.TopMargin,
            this.BottomMargin,
            this.Detail});
			this.Dpi = 254F;
			this.Font = new DevExpress.Drawing.DXFont("Arial", 9.75F);
			this.Margins = new DevExpress.Drawing.DXMargins(254F, 254F, 254F, 254F);
			this.PageHeight = 2794;
			this.PageWidth = 2159;
			this.Parameters.AddRange(new DevExpress.XtraReports.Parameters.Parameter[] {
            this.RichText});
			this.ReportUnit = DevExpress.XtraReports.UI.ReportUnit.TenthsOfAMillimeter;
			this.SnapGridSize = 25F;
			this.Version = "24.1";
			xrWatermark1.Id = "Watermark1";
			this.Watermarks.AddRange(new DevExpress.XtraPrinting.Drawing.Watermark[] {
            xrWatermark1});
			((System.ComponentModel.ISupportInitialize)(this.xrRichText1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this)).EndInit();

		}

		#endregion

		private DevExpress.XtraReports.UI.TopMarginBand TopMargin;
		private DevExpress.XtraReports.UI.BottomMarginBand BottomMargin;
		private DevExpress.XtraReports.UI.DetailBand Detail;
		private DevExpress.XtraReports.UI.XRRichText xrRichText1;
		public DevExpress.XtraReports.Parameters.Parameter RichText;
	}
}
