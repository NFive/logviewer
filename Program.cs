using System;
using System.Windows.Forms;

namespace NFive.LogViewer
{
	public static class Program
	{
		[STAThread]
		public static void Main(string[] args)
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new Main(args));
		}
	}
}
