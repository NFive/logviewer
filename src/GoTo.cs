using System;
using System.Windows.Forms;

namespace NFive.LogViewer
{
	public partial class GoTo : Form
	{
		private readonly RichPanel panel;

		public GoTo(RichPanel panel)
		{
			this.panel = panel;

			InitializeComponent();

			this.numericUpDownLine.Maximum = this.panel.TotalLines;
			this.numericUpDownLine.Value = this.panel.CurrentLine;

			this.numericUpDownLine.Select(0, this.numericUpDownLine.Text.Length);
		}

		private void buttonGoTo_Click(object sender, EventArgs e)
		{
			this.panel.CurrentLine = Convert.ToInt32(this.numericUpDownLine.Value);
		}
	}
}
