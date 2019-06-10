using System;
using System.Windows.Forms;
using NFive.LogViewer.Configuration;

namespace NFive.LogViewer
{
	public static class Program
	{
		[STAThread]
		public static void Main(string[] args)
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);

			Settings.FileName = "logviewer.yml";

			try
			{
				Application.Run(new Main(args));
			}
			catch (Exception ex)
			{
				MessageBox.Show(
					$"An unhandled fatal exception has occurred:{Environment.NewLine}{ex.Message}{Environment.NewLine}{Environment.NewLine}Application will now exit.",
					"NFive Log Viewer",
					MessageBoxButtons.OK,
					MessageBoxIcon.Error);
			}
		}
	}
}
