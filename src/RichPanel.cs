using System;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using NFive.LogViewer.Configuration;
using ScintillaNET;
using WeifenLuo.WinFormsUI.Docking;

namespace NFive.LogViewer
{
	public partial class RichPanel : DockContent
	{
		private static readonly Regex GuidMatch = new Regex("([\"\\{\\[]){0,1}[0-9a-fA-F]{8}\\-[0-9a-fA-F]{4}\\-[0-9a-fA-F]{4}\\-[0-9a-fA-F]{4}\\-[0-9a-fA-F]{12}([\\}\\]\"]){0,1}", RegexOptions.Compiled);
		private static readonly Regex EventMatch = new Regex("([\"\\{\\[]){0,1}[a-zA-Z][a-zA-Z0-9]+\\:[a-zA-Z][\\:a-zA-Z0-9]+([\"\\{\\[]){0,1}", RegexOptions.Compiled);
		private static readonly Regex KeywordMatch = new Regex("\\b([\"\\{\\[]){0,1}(null|true|false)([\"\\{\\[]){0,1}\\b", RegexOptions.Compiled);
		private static readonly Regex TimestampMatch = new Regex("([\"\\{\\[]){0,1}(-?(?:[1-9][0-9]*)?[0-9]{4})-(1[0-2]|0[1-9])-(3[01]|0[1-9]|[12][0-9])T(2[0-3]|[01][0-9]):([0-5][0-9]):([0-5][0-9])(\\.[0-9]+)?([\"\\{\\[]){0,1}", RegexOptions.Compiled);

		private Settings.ThemeConfiguration theme;

		public event EventHandler<PositionEventArgs> PositionChanged;

		public string Content => this.scintilla.Text;

		public bool WordWrap
		{
			set => this.scintilla.WrapMode = value ? WrapMode.Word : WrapMode.None;
		}

		public int Zoom
		{
			set => this.scintilla.Zoom = value;
		}

		public RichPanel(string title, Settings.ThemeConfiguration theme)
		{
			InitializeComponent();

			// ReSharper disable once VirtualMemberCallInConstructor
			this.Text = title;
			this.HideOnClose = true;

			this.theme = theme;

			this.scintilla.ReadOnly = true;
			this.scintilla.Zoom = 0;
			this.scintilla.WrapMode = WrapMode.None;
			this.scintilla.ZoomChanged += (s, a) => StyleEditor(this.theme);
			this.scintilla.UpdateUI += scintilla_UpdateUI;
			this.scintilla.StyleNeeded += scintilla_StyleNeeded;

			StyleEditor(this.theme);
		}

		private void scintilla_UpdateUI(object sender, UpdateUIEventArgs e)
		{
			if ((e.Change & UpdateChange.Selection) > 0)
			{
				this.PositionChanged?.Invoke(this, new PositionEventArgs(
					this.scintilla.CurrentLine + 1,
					this.scintilla.GetColumn(this.scintilla.CurrentPosition) + 1,
					this.scintilla.CurrentPosition,
					this.scintilla.AnchorPosition,
					this.scintilla.Lines[this.scintilla.CurrentLine].AnnotationText,
					this.scintilla.Lines[this.scintilla.CurrentLine].MarginText));
			}

			var startPos = this.scintilla.Lines[this.scintilla.FirstVisibleLine].Position;
			var endPos = this.scintilla.Lines[this.scintilla.FirstVisibleLine + this.scintilla.LinesOnScreen].EndPosition;
			var text = this.scintilla.GetTextRange(startPos, endPos - startPos);

			foreach (Match match in GuidMatch.Matches(text))
			{
				this.scintilla.StartStyling(match.Index + startPos);
				this.scintilla.SetStyling(match.Length, Style.Json.Number);
			}

			foreach (Match match in EventMatch.Matches(text))
			{
				this.scintilla.StartStyling(match.Index + startPos);
				this.scintilla.SetStyling(match.Length, Style.Json.PropertyName);
			}

			foreach (Match match in KeywordMatch.Matches(text))
			{
				this.scintilla.StartStyling(match.Index + startPos);
				this.scintilla.SetStyling(match.Length, Style.Json.Uri);
			}

			foreach (Match match in TimestampMatch.Matches(text))
			{
				this.scintilla.StartStyling(match.Index + startPos);
				this.scintilla.SetStyling(match.Length, Style.Json.Uri);
			}
		}

		public void Log(Log log)
		{
			this.scintilla.ReadOnly = false;

			var startLine = this.scintilla.Lines.Count;
			this.scintilla.AppendText($"{(string.IsNullOrEmpty(log.Prefix) ? string.Empty : $"[{log.Prefix}] ")}{log.Message}{Environment.NewLine}");
			var endLine = this.scintilla.Lines.Count;

			for (var i = startLine; i < endLine; i++)
			{
				var line = this.scintilla.Lines[i - 1];

				line.AnnotationText = log.DateTime.ToString("s");
				line.MarginText = log.Level;

				switch (log.Level)
				{
					case "Trace":
						line.MarkerAdd(0);
						break;
					case "Debug":
						line.MarkerAdd(1);
						break;
					case "Info":
						line.MarkerAdd(2);
						break;
					case "Warn":
						line.MarkerAdd(3);
						break;
					case "Error":
						line.MarkerAdd(4);
						break;
				}
			}

			if (ReachedBottom(this.scintilla))
			{
				this.scintilla.LineScroll(endLine, 0);
			}

			this.scintilla.ReadOnly = true;
		}

		[DllImport("user32")]
		private static extern int GetScrollInfo(IntPtr hwnd, int nBar, ref ScrollInfo scrollInfo);

		private struct ScrollInfo
		{
			public int cbSize;
			public int fMask;
			public int min;
			public int max;
			public int nPage;
			public int nPos;
			public int nTrackPos;
		}

		private static bool ReachedBottom(Scintilla scintilla)
		{
			var scrollInfo = new ScrollInfo();
			scrollInfo.cbSize = Marshal.SizeOf(scrollInfo);
			scrollInfo.fMask = 0x10 | 0x1 | 0x2;
			GetScrollInfo(scintilla.Handle, 1, ref scrollInfo);

			return scrollInfo.max <= scrollInfo.nTrackPos + scrollInfo.nPage;
		}

		public void ApplyStyles(Settings.ThemeConfiguration style)
		{
			this.theme = style;

			StyleEditor(this.theme);
		}

		public void ZoomIn()
		{
			this.scintilla.ZoomIn();
		}

		public void ZoomOut()
		{
			this.scintilla.ZoomOut();
		}

		public void Copy()
		{
			this.scintilla.Copy();
		}

		public void SelectAll()
		{
			this.scintilla.SelectAll();
		}

		private void scintilla_StyleNeeded(object sender, StyleNeededEventArgs e)
		{
			var startPos = this.scintilla.GetEndStyled();
			var startLine = this.scintilla.LineFromPosition(startPos);
			startPos = this.scintilla.Lines[startLine].Position;
			var endPos = e.Position;
			var endLine = this.scintilla.LineFromPosition(endPos);
			endPos = this.scintilla.Lines[endLine].EndPosition;

			var text = this.scintilla.GetTextRange(startPos, endPos - startPos);
			var matches = Regex.Matches(text, @"^\[.+?\] ", RegexOptions.Multiline).Cast<Match>().ToList();

			if (matches.Count > 0 && matches[0].Success)
			{
				if (matches[0].Index != startPos)
				{
					JsonHighlight(startPos, matches[0].Index);
				}

				for (var i = 0; i < matches.Count; i++)
				{
					var match = matches[i];
					var start = startPos + match.Index;
					var length = match.Length;
					var end = start + length;

					this.scintilla.StartStyling(start);
					this.scintilla.SetStyling(length - 1, 30);

					this.scintilla.StartStyling(end - 1); // Hack to reset current style
					this.scintilla.SetStyling(0, 0);

					var nextMatchPos = matches.Count > i + 1 ? matches[i + 1].Index : endPos;

					JsonHighlight(end, nextMatchPos);
				}
			}
			else
			{
				JsonHighlight(startPos, endPos);
			}
		}

		private void JsonHighlight(int startPos, int endPos)
		{
			this.scintilla.Lexer = Lexer.Json;
			this.scintilla.SetKeywords(0, "false true null");
			this.scintilla.Colorize(startPos, endPos);
			this.scintilla.Lexer = Lexer.Container;
		}

		private void StyleEditor(Settings.ThemeConfiguration style)
		{
			this.scintilla.Lexer = Lexer.Container;

			this.scintilla.StyleResetDefault();
			this.scintilla.Styles[Style.Default].Font = style.Font.FontFamily.Name;
			this.scintilla.Styles[Style.Default].Italic = style.Font.Italic;
			this.scintilla.Styles[Style.Default].Weight = style.Font.Bold ? 700 : 400;
			this.scintilla.Styles[Style.Default].Size = Convert.ToInt32(style.Font.Size);
			this.scintilla.Styles[Style.Default].BackColor = style.EditorBackground;
			this.scintilla.Styles[Style.Default].ForeColor = style.EditorText;
			this.scintilla.StyleClearAll();

			this.scintilla.SetSelectionBackColor(true, style.TextSelection);

			this.scintilla.Styles[Style.LineNumber].BackColor = style.MarginBackground;
			this.scintilla.Styles[Style.LineNumber].ForeColor = style.MarginText;

			this.scintilla.Styles[30].ForeColor = style.SyntaxColors["Prefix"];
			this.scintilla.Styles[Style.Json.Number].ForeColor = style.SyntaxColors["Number"];
			this.scintilla.Styles[Style.Json.String].ForeColor = style.SyntaxColors["String"];
			this.scintilla.Styles[Style.Json.PropertyName].ForeColor = style.SyntaxColors["Property"];
			this.scintilla.Styles[Style.Json.Operator].ForeColor = style.SyntaxColors["Operator"];
			this.scintilla.Styles[Style.Json.Uri].ForeColor = style.SyntaxColors["Uri"];
			this.scintilla.Styles[Style.Json.Keyword].ForeColor = style.SyntaxColors["Keyword"];

			this.scintilla.SetKeywords(0, "false true null");

			var lineNumberMargin = this.scintilla.Margins[1];
			lineNumberMargin.Width = 30 + Math.Max(0, 2 * this.scintilla.Zoom);
			lineNumberMargin.Type = MarginType.Number;
			lineNumberMargin.Sensitive = true;
			lineNumberMargin.Mask = 0;

			this.scintilla.Margins[2].Width = 10;

			var margin = this.scintilla.Margins[3];
			margin.Width = 2;
			margin.Sensitive = true;
			margin.Type = MarginType.Symbol;
			margin.Mask = 0xFFFFFF;
			margin.Cursor = MarginCursor.Arrow;

			this.scintilla.Margins[4].Width = 10;

			this.scintilla.Markers[0].Symbol = MarkerSymbol.FullRect;
			this.scintilla.Markers[0].SetBackColor(style.LevelColors["Trace"]);

			this.scintilla.Markers[1].Symbol = MarkerSymbol.FullRect;
			this.scintilla.Markers[1].SetBackColor(style.LevelColors["Debug"]);

			this.scintilla.Markers[2].Symbol = MarkerSymbol.FullRect;
			this.scintilla.Markers[2].SetBackColor(style.LevelColors["Info"]);

			this.scintilla.Markers[3].Symbol = MarkerSymbol.FullRect;
			this.scintilla.Markers[3].SetBackColor(style.LevelColors["Warn"]);

			this.scintilla.Markers[4].Symbol = MarkerSymbol.FullRect;
			this.scintilla.Markers[4].SetBackColor(style.LevelColors["Error"]);
		}
	}
}
