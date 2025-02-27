using System;
using System.Windows.Forms;
using System.Windows.Input;
using Brendel.Toolbelt.DevExpress.Win.Controls;
using DevExpress.XtraEditors;

namespace RtfTest;

internal static class Program {
	/// <summary>
	/// The main entry point for the application.
	/// </summary>
	[STAThread]
	static void Main() {
		Application.EnableVisualStyles();
		Application.SetCompatibleTextRenderingDefault(false);

		/*
		while (true) {
			var control = new DatePickerEdit();
			control.EditValue = null;
			XtraDialog.Show(control, "Wähle ein Datum!");
			if (Keyboard.IsKeyDown(Key.Escape)) {
				return;
			}
		}
		*/

		Application.Run(new Form1());
	}
}