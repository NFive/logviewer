using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using ScintillaNET;

namespace NFive.LogViewer
{
	public partial class QuickFind : UserControl
	{
		private List<CharacterRange> matches = new List<CharacterRange>();
		private int currentMatch = 0;
		private RichPanel panel;

		public RichPanel Panel
		{
			get => this.panel;
			set
			{
				this.panel = value;

				textBoxFind_TextChanged(null, null);
			}
		}

		public QuickFind()
		{
			InitializeComponent();
		}

		public void SelectAll()
		{
			this.textBoxFind.SelectAll();
			this.textBoxFind.Focus();
		}

		private void QuickFind_VisibleChanged(object sender, EventArgs e)
		{
			this.textBoxFind.Focus();
		}

		private void textBoxFind_TextChanged(object sender, EventArgs e)
		{
			Search();
		}

		private void textBoxFind_KeyDown(object sender, KeyEventArgs e)
		{
			// ReSharper disable once SwitchStatementMissingSomeCases
			switch (e.KeyCode)
			{
				case Keys.Enter:
				case Keys.Down:
					buttonNext_Click(null, null);
					e.Handled = true;
					break;

				case Keys.Up:
					buttonPrevious_Click(null, null);
					e.Handled = true;
					break;

				case Keys.Escape:
					buttonClose_Click(null, null);
					e.Handled = true;
					break;
			}
		}

		private void buttonClose_Click(object sender, EventArgs e)
		{
			Hide();
		}

		private void checkBoxCase_CheckedChanged(object sender, EventArgs e)
		{
			Search();
		}

		private void checkBoxWholeWord_CheckedChanged(object sender, EventArgs e)
		{
			Search();
		}

		private void checkBoxRegex_CheckedChanged(object sender, EventArgs e)
		{
			Search();
		}

		private void buttonPrevious_Click(object sender, EventArgs e)
		{
			if (this.Panel == null) return;
			if (this.textBoxFind.Text == string.Empty) return;
			if (this.matches.Count < 1) return;

			this.currentMatch--;
			if (this.currentMatch < 0) this.currentMatch = this.matches.Count - 1;

			this.labelMatches.Text = $"{(this.currentMatch + 1):N0} of {this.matches.Count:N0}";
			this.labelMatches.ForeColor = Color.Black;

			this.Panel.SetSelection(this.matches.ElementAtOrDefault(this.currentMatch).First, this.matches.ElementAtOrDefault(this.currentMatch).Length);
		}

		private void buttonNext_Click(object sender, EventArgs e)
		{
			if (this.Panel == null) return;
			if (this.textBoxFind.Text == string.Empty) return;
			if (this.matches.Count < 1) return;

			this.currentMatch++;
            if (this.currentMatch > this.matches.Count - 1) this.currentMatch = 0;

			this.labelMatches.Text = $"{(this.currentMatch + 1):N0} of {this.matches.Count:N0}";
			this.labelMatches.ForeColor = Color.Black;

			this.Panel.SetSelection(this.matches.ElementAtOrDefault(this.currentMatch).First, this.matches.ElementAtOrDefault(this.currentMatch).Length);
		}

		private void Search()
		{
			if (this.Panel == null || this.textBoxFind.Text == string.Empty)
			{
				this.matches.Clear();

				this.labelMatches.Text = "No results";
				this.labelMatches.ForeColor = Color.Black;

				return;
			}

			this.matches = this.Panel.FindAll(0, this.Panel.TotalLength, this.textBoxFind.Text, GetSearchFlags());
			this.currentMatch = 0;

			if (this.matches.Count < 1)
			{
				this.currentMatch = 0;

				this.labelMatches.Text = "No results";
				this.labelMatches.ForeColor = Color.Red;
			}
			else
			{
				this.labelMatches.Text = $"{(this.currentMatch + 1):N0} of {this.matches.Count:N0}";
				this.labelMatches.ForeColor = Color.Black;

				this.Panel.SetSelection(this.matches.ElementAtOrDefault(this.currentMatch).First, this.matches.ElementAtOrDefault(this.currentMatch).Length);
			}
		}

		private SearchFlags GetSearchFlags()
		{
			var flags = SearchFlags.None;

			if (this.checkBoxCase.Checked) flags |= SearchFlags.MatchCase;
			if (this.checkBoxWholeWord.Checked) flags |= SearchFlags.WholeWord;
			if (this.checkBoxRegex.Checked) flags |= SearchFlags.Regex;

			return flags;
		}
	}
}
