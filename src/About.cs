using System;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;

namespace NFive.LogViewer
{
	public partial class About : Form
	{
		public About()
		{
			InitializeComponent();
		}

		private void About_Load(object sender, EventArgs e)
		{
			this.labelVersion.Text = "v" + Assembly.GetExecutingAssembly().GetCustomAttributes<AssemblyInformationalVersionAttribute>().First().InformationalVersion;
		}

		private void LinkLabelWebsite_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			Process.Start(this.linkLabelWebsite.Text);
		}

		private void LinkLabelRepo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			Process.Start(this.linkLabelRepo.Text);
		}

		private void ButtonClose_Click(object sender, EventArgs e)
		{
			Close();
		}
	}
}
