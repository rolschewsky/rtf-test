using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraReports.UI;

namespace RtfTest {
	public partial class SimpleRtfEditorForm : XtraForm {
		public SimpleRtfEditorForm() {
			InitializeComponent();
		}

		private void simpleButton1_Click(object sender, EventArgs e) {
			var report = new RtfTestReport();
			report.RichText.Value = wysiwygRichEditControl1.RtfText;
			var file = Path.GetTempFileName() + ".pdf";
			report.ExportToPdf(file);
			Process.Start(file);
		}
	}
}