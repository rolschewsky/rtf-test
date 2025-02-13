using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using Dapper;
using DevExpress.XtraEditors;
using RtfTest.Properties;

namespace RtfTest;

public partial class Form1 : XtraForm {

	private const string EXAMPLE_RTF = """
	                                   {\rtf1\ansi
	                                   {\fonttbl{\f0 Arial;}}

	                                   {\trowd
	                                   \trrh240
	                                   \trgaph80
	                                   \trftsWidth1\trautofit1
	                                   \clvertalc\clftsWidth1\cellx1000
	                                   \clvertalc\clftsWidth1\cellx2000
	                                   \pard\plain\ql\intbl\fs20 Druck\cell 
	                                   \pard\plain\ql\intbl\fs20 6-farbig + Drucklackierung\cell
	                                   \row}

	                                   {\trowd
	                                   \trrh240
	                                   \trgaph80
	                                   \trftsWidth1\trautofit1
	                                   \clvertalc\clftsWidth1\cellx1000
	                                   \clvertalc\clftsWidth1\cellx2000
	                                   \pard\plain\ql\intbl\fs20 Gr\u246?\u223?e\cell 
	                                   \pard\plain\ql\intbl\fs20 392 x 133 mm\cell
	                                   \row}

	                                   {\trowd
	                                   \trrh240
	                                   \trgaph80
	                                   \trftsWidth1\trautofit1
	                                   \clvertalc\clftsWidth1\cellx1000
	                                   \clvertalc\clftsWidth1\cellx2000
	                                   \pard\plain\ql\intbl\fs20 Material\cell 
	                                   \pard\plain\ql\intbl\fs20 400 g/qm Chromokarton GC2\cell
	                                   \row}

	                                   {\trowd
	                                   \trrh240
	                                   \trgaph80
	                                   \trftsWidth1\trautofit1
	                                   \clvertalc\clftsWidth1\cellx1000
	                                   \clvertalc\clftsWidth1\cellx2000
	                                   \pard\plain\ql\intbl\fs20 Achtung\cell 
	                                   \pard\plain\ql\intbl\fs20 Bitte Korrekturabzug zur Druckgenehmigung vorlegen!\cell
	                                   \row}
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

		wysiwygRichEditControl1.RtfText = EXAMPLE_RTF;
	}

	private void simpleButton1_Click(object sender, EventArgs e) {
		try {
			var connectionString = textEdit1.Text;
			Settings.Default.ConnectionString = connectionString;
			Settings.Default.Save();

			using var conn = new SqlConnection(connectionString);
			conn.Open();
			var rtfText = conn.QuerySingleOrDefault<string>(
				"""
				SELECT Details 
				FROM dbo.AT_Stamm 
				WHERE AT_StammId = @ArtikelID
				""",
				new {
					ArtikelID = int.Parse(textEdit2.Text)
				});

			memoEdit1.Text = rtfText;
		} catch (Exception ex) {
			XtraMessageBox.Show(ex.ToString(), ex.GetType().Name, MessageBoxButtons.OK);
		}
	}

	private void textEdit2_KeyUp(object sender, KeyEventArgs e) {
		if (e.KeyCode == Keys.Enter) {
			simpleButton1_Click(sender, EventArgs.Empty);
		}
	}

	private void memoEdit1_EditValueChanged(object sender, EventArgs e) {
		wysiwygRichEditControl1.RtfText = memoEdit1.Text;
	}

	private void memoEdit2_EditValueChanged(object sender, EventArgs e) {
		wysiwygRichEditControl1.RtfText = memoEdit2.Text;
	}

	private void wysiwygRichEditControl1_RtfTextChanged(object sender, EventArgs e) {
		memoEdit2.Text = wysiwygRichEditControl1.RtfText;
	}
}