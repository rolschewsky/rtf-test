using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Dapper;
using DevExpress.XtraEditors;
using RtfTest.Properties;

namespace RtfTest {
	public partial class Form1 : DevExpress.XtraEditors.XtraForm {

		private const string EXAMPLE_RTF = """
		                                   {\rtf1\ansi\deff0
		                                   {\fonttbl
		                                   {\f0
		                                   Monotype Corsiva;
		                                   }
		                                   }
		                                   \qc
		                                   \f0\fs120\i
		                                   \b Hello,
		                                   \line
		                                   World!
		                                   }
		                                   """;
		public Form1() {
			InitializeComponent();
		}

		protected override void OnLoad(EventArgs e) {
			textEdit1.Text = Settings.Default.ConnectionString;
			if (string.IsNullOrEmpty(textEdit1.Text)) {
				textEdit1.Text = "hier Connection String zur DB eingeben";
			}

			richEditControl1.Document.RtfText = EXAMPLE_RTF;
		}

		private void simpleButton1_Click(object sender, EventArgs e) {
			try {
				var connectionString = textEdit1.Text;
				Settings.Default.ConnectionString = connectionString;
				Settings.Default.Save();

				using var conn = new SqlConnection(connectionString);
				conn.Open();
				var text = conn.QuerySingleOrDefault<string>(
					"""
					SELECT Details 
					FROM dbo.AT_Stamm 
					WHERE AT_StammId = @ArtikelID
					""",
					new {
						ArtikelID = int.Parse(textEdit2.Text)
					});

				memoEdit1.Text = text;
				richEditControl1.Document.RtfText = text;
			} catch (Exception ex) {
				XtraMessageBox.Show(ex.ToString(), ex.GetType().Name, MessageBoxButtons.OK);
			}
		}

		private void textEdit2_KeyUp(object sender, KeyEventArgs e) {
			if (e.KeyCode == Keys.Enter) {
				simpleButton1_Click(sender, EventArgs.Empty);
			}
		}
	}
}