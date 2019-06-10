using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using NFive.LogViewer.Configuration;

namespace NFive.LogViewer
{
	public partial class Preferences : Form
	{
		public event EventHandler Apply;

		public Preferences()
		{
			InitializeComponent();

			LoadPreferences();
		}

		private void PanelColor_Click(object sender, EventArgs e)
		{
			var panel = (Panel)sender;
			var color = ShowColorPicker(panel.BackColor);

			if (color.HasValue) panel.BackColor = color.Value;
		}

		private void ButtonReset_Click(object sender, EventArgs e)
		{
			if (MessageBox.Show("Reset all preferences to default?", "NFive Log Viewer", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) != DialogResult.Yes) return;

			Settings.Instance.Initialize();

			LoadPreferences();

			this.Apply?.Invoke(this, EventArgs.Empty);
		}

		private void ButtonOk_Click(object sender, EventArgs e)
		{
			ApplyPreferences();

			this.DialogResult = DialogResult.OK;

			Close();
		}

		private void ButtonApply_Click(object sender, EventArgs e)
		{
			ApplyPreferences();

			this.Apply?.Invoke(this, EventArgs.Empty);
		}

		private void ButtonCancel_Click(object sender, EventArgs e)
		{
			this.DialogResult = DialogResult.Cancel;

			Close();
		}

		private Color? ShowColorPicker(Color startColor)
		{
			using (var dialog = new ColorDialog
			{
				Color = startColor,
				CustomColors = new[] { startColor.ToArgb(), this.panelEditorBackgroundColor.BackColor.ToArgb(), this.panelMarginTextColor.BackColor.ToArgb() }.Distinct().ToArray(),
				AllowFullOpen = true,
				AnyColor = true,
				FullOpen = true,
				ShowHelp = false,
				SolidColorOnly = true
			})
			{
				return dialog.ShowDialog() == DialogResult.OK ? dialog.Color : default(Color?);
			}
		}

		private void LoadPreferences()
		{
			this.checkBoxShowWelcomeTab.Checked = Settings.Instance.ShowWelcomeTab;
			this.checkBoxRestoreLastFile.Checked = Settings.Instance.RestoreLastFile;
			this.numericUpDownFileHistory.Value = Settings.Instance.FileHistory;

			this.panelEditorBackgroundColor.BackColor = Settings.Instance.Theme.EditorBackground;
			this.panelEditorTextColor.BackColor = Settings.Instance.Theme.EditorText;
			this.panelMarginBackgroundColor.BackColor = Settings.Instance.Theme.MarginBackground;
			this.panelMarginTextColor.BackColor = Settings.Instance.Theme.MarginText;
			this.panelTextSelectionColor.BackColor = Settings.Instance.Theme.TextSelection;

			this.panelSyntaxPrefix.BackColor = Settings.Instance.Theme.SyntaxColors["Prefix"];
			this.panelSyntaxNumber.BackColor = Settings.Instance.Theme.SyntaxColors["Number"];
			this.panelSyntaxString.BackColor = Settings.Instance.Theme.SyntaxColors["String"];
			this.panelSyntaxProperty.BackColor = Settings.Instance.Theme.SyntaxColors["Property"];
			this.panelSyntaxOperator.BackColor = Settings.Instance.Theme.SyntaxColors["Operator"];
			this.panelSyntaxUri.BackColor = Settings.Instance.Theme.SyntaxColors["Uri"];
			this.panelSyntaxKeyword.BackColor = Settings.Instance.Theme.SyntaxColors["Keyword"];

			this.panelLevelTrace.BackColor = Settings.Instance.Theme.LevelColors["Trace"];
			this.panelLevelDebug.BackColor = Settings.Instance.Theme.LevelColors["Debug"];
			this.panelLevelInfo.BackColor = Settings.Instance.Theme.LevelColors["Info"];
			this.panelLevelWarn.BackColor = Settings.Instance.Theme.LevelColors["Warn"];
			this.panelLevelError.BackColor = Settings.Instance.Theme.LevelColors["Error"];
		}

		private void ApplyPreferences()
		{
			Settings.Instance.ShowWelcomeTab = this.checkBoxShowWelcomeTab.Checked;
			Settings.Instance.RestoreLastFile = this.checkBoxRestoreLastFile.Checked;
			Settings.Instance.FileHistory = Convert.ToUInt16(this.numericUpDownFileHistory.Value);

			Settings.Instance.Theme.EditorBackground = this.panelEditorBackgroundColor.BackColor;
			Settings.Instance.Theme.EditorText = this.panelEditorTextColor.BackColor;
			Settings.Instance.Theme.MarginBackground = this.panelMarginBackgroundColor.BackColor;
			Settings.Instance.Theme.MarginText = this.panelMarginTextColor.BackColor;
			Settings.Instance.Theme.TextSelection = this.panelTextSelectionColor.BackColor;

			Settings.Instance.Theme.SyntaxColors["Prefix"] = this.panelSyntaxPrefix.BackColor;
			Settings.Instance.Theme.SyntaxColors["Number"] = this.panelSyntaxNumber.BackColor;
			Settings.Instance.Theme.SyntaxColors["String"] = this.panelSyntaxString.BackColor;
			Settings.Instance.Theme.SyntaxColors["Property"] = this.panelSyntaxProperty.BackColor;
			Settings.Instance.Theme.SyntaxColors["Operator"] = this.panelSyntaxOperator.BackColor;
			Settings.Instance.Theme.SyntaxColors["Uri"] = this.panelSyntaxUri.BackColor;
			Settings.Instance.Theme.SyntaxColors["Keyword"] = this.panelSyntaxKeyword.BackColor;

			Settings.Instance.Theme.LevelColors["Trace"] = this.panelLevelTrace.BackColor;
			Settings.Instance.Theme.LevelColors["Debug"] = this.panelLevelDebug.BackColor;
			Settings.Instance.Theme.LevelColors["Info"] = this.panelLevelInfo.BackColor;
			Settings.Instance.Theme.LevelColors["Warn"] = this.panelLevelWarn.BackColor;
			Settings.Instance.Theme.LevelColors["Error"] = this.panelLevelError.BackColor;
		}
	}
}
