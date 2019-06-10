using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using NFive.LogViewer.Configuration;
using WeifenLuo.WinFormsUI.Docking;

namespace NFive.LogViewer
{
	public partial class Main : Form
	{
		private static readonly Regex Split = new Regex(@"(?<! [^[]+\[[^]]+) ", RegexOptions.Compiled);
		private static readonly Regex ClientLogPrefix = new Regex(@"^\[[ 0-9]{10}\] $", RegexOptions.Compiled);
		private readonly Dictionary<string, RichPanel> panels = new Dictionary<string, RichPanel>();
		private LogFileMonitor monitor;

		public Main(IEnumerable<string> args)
		{
			InitializeComponent();

			this.dockPanel.Theme = new VS2015LightTheme();

			var file = args.FirstOrDefault(File.Exists);

			if (file != null)
			{
				OpenFile(file);
			}
			else
			{
				if (Settings.Instance.ShowWelcomeTab) ShowWelcomeTab();
			}
		}

		private void Main_Load(object sender, EventArgs e)
		{
			// Restore window position
			this.Bounds = new Rectangle(Settings.Instance.Window.X, Settings.Instance.Window.Y, Settings.Instance.Window.Width, Settings.Instance.Window.Height);
			this.WindowState = Settings.Instance.Window.Maximized ? FormWindowState.Maximized : FormWindowState.Normal;

			var preMaximizeBounds = this.Bounds;

			this.ResizeBegin += (s, a) =>
			{
				preMaximizeBounds = this.Bounds;
			};

			this.ResizeEnd += (s, a) =>
			{
				if (this.WindowState == FormWindowState.Maximized) this.Bounds = preMaximizeBounds;
			};

			// Load settings
			this.wordWrapToolStripMenuItem.Checked = Settings.Instance.WordWrap;

			foreach (var panel in this.panels.Values)
			{
				panel.WordWrap = Settings.Instance.WordWrap;
			}
		}

		private void Main_DragEnter(object sender, DragEventArgs e)
		{
			if (e.Data.GetDataPresent(DataFormats.FileDrop)) e.Effect = DragDropEffects.Copy;
		}

		private void Main_DragDrop(object sender, DragEventArgs e)
		{
			var files = (string[]) e.Data.GetData(DataFormats.FileDrop);

			OpenFile(files.FirstOrDefault(File.Exists));
		}

		private void Main_FormClosing(object sender, FormClosingEventArgs e)
		{
			Settings.Instance.Window.Maximized = this.WindowState == FormWindowState.Maximized;

			if (Settings.Instance.Window.Maximized)
			{
				Settings.Instance.Window.X = this.RestoreBounds.X;
				Settings.Instance.Window.Y = this.RestoreBounds.Y;
				Settings.Instance.Window.Width = this.RestoreBounds.Width;
				Settings.Instance.Window.Height = this.RestoreBounds.Height;
			}
			else
			{
				Settings.Instance.Window.X = this.Bounds.X;
				Settings.Instance.Window.Y = this.Bounds.Y;
				Settings.Instance.Window.Width = this.Bounds.Width;
				Settings.Instance.Window.Height = this.Bounds.Height;
			}

			Settings.Save();
		}

		private void Main_FormClosed(object sender, FormClosedEventArgs e)
		{
			this.monitor?.Stop();
		}

		private void ShowWelcomeTab()
		{
			CreatePanel("Welcome", DockState.Document, hidden => { });

			this.panels["Welcome"].Log(new Log
			{
				DateTime = DateTime.UtcNow,
				Level = "Trace",
				Prefix = "Log Viewer",
				Message = "Below is examples of log levels and JSON highlighting"
			});
			this.panels["Welcome"].Log(new Log
			{
				DateTime = DateTime.UtcNow,
				Level = "Trace"
			});
			this.panels["Welcome"].Log(new Log
			{
				DateTime = DateTime.UtcNow,
				Level = "Trace",
				Message = $"{{{Environment.NewLine}\t\"name\": \"{this.Text}\",{Environment.NewLine}\t\"version\": {Assembly.GetExecutingAssembly().GetCustomAttributes<AssemblyFileVersionAttribute>().First().Version},{Environment.NewLine}\t\"website\": \"https://github.com/NFive/logviewer\"{Environment.NewLine}}}"
			});
			this.panels["Welcome"].Log(new Log
			{
				DateTime = DateTime.UtcNow,
				Level = "Trace"
			});
			this.panels["Welcome"].Log(new Log
			{
				DateTime = DateTime.UtcNow,
				Level = "Trace",
				Message = "Trace message"
			});
			this.panels["Welcome"].Log(new Log
			{
				DateTime = DateTime.UtcNow,
				Level = "Debug",
				Message = "Debug message"
			});
			this.panels["Welcome"].Log(new Log
			{
				DateTime = DateTime.UtcNow,
				Level = "Info",
				Message = "Info message"
			});
			this.panels["Welcome"].Log(new Log
			{
				DateTime = DateTime.UtcNow,
				Level = "Warn",
				Message = "Warn message"
			});
			this.panels["Welcome"].Log(new Log
			{
				DateTime = DateTime.UtcNow,
				Level = "Error",
				Message = "Error message"
			});
		}

		private void CloseFile()
		{
			// Stop monitor
			this.monitor?.Stop();

			// Remove panels
			foreach (var panel in this.panels.Values)
			{
				panel.Close();
				panel.Dispose();
			}

			this.panels.Clear();

			// UI
			this.statusToolStripStatusLabel.Text = "Ready";
			this.saveToolStripMenuItem.Enabled = false;
			this.copyToolStripMenuItem.Enabled = false;
			this.selectAllToolStripMenuItem.Enabled = false;
			this.masterToolStripMenuItem.Enabled = false;
			this.levelTraceToolStripMenuItem.Enabled = false;
			this.levelDebugToolStripMenuItem.Enabled = false;
			this.levelInfoToolStripMenuItem.Enabled = false;
			this.levelWarnToolStripMenuItem.Enabled = false;
			this.levelErrorToolStripMenuItem.Enabled = false;
		}

		private void OpenFile(string file)
		{
			if (file == null) return;

			CloseFile();

			// UI
			this.statusToolStripStatusLabel.Text = $"Monitoring {file}";
			this.saveToolStripMenuItem.Enabled = true;
			this.copyToolStripMenuItem.Enabled = true;
			this.selectAllToolStripMenuItem.Enabled = true;
			this.masterToolStripMenuItem.Enabled = true;
			this.levelTraceToolStripMenuItem.Enabled = true;
			this.levelDebugToolStripMenuItem.Enabled = true;
			this.levelInfoToolStripMenuItem.Enabled = true;
			this.levelWarnToolStripMenuItem.Enabled = true;
			this.levelErrorToolStripMenuItem.Enabled = true;

			// Create panels
			CreatePanel("Master", DockState.Document, hidden => this.masterToolStripMenuItem.CheckState = hidden ? CheckState.Unchecked : CheckState.Checked);
			CreatePanel("Trace", DockState.DockBottomAutoHide, hidden => this.levelTraceToolStripMenuItem.CheckState = hidden ? CheckState.Unchecked : CheckState.Checked);
			CreatePanel("Debug", DockState.DockBottomAutoHide, hidden => this.levelDebugToolStripMenuItem.CheckState = hidden ? CheckState.Unchecked : CheckState.Checked);
			CreatePanel("Info", DockState.DockBottomAutoHide, hidden => this.levelInfoToolStripMenuItem.CheckState = hidden ? CheckState.Unchecked : CheckState.Checked);
			CreatePanel("Warn", DockState.DockBottomAutoHide, hidden => this.levelWarnToolStripMenuItem.CheckState = hidden ? CheckState.Unchecked : CheckState.Checked);
			CreatePanel("Error", DockState.DockBottomAutoHide, hidden => this.levelErrorToolStripMenuItem.CheckState = hidden ? CheckState.Unchecked : CheckState.Checked);

			var stockPanels = new Dictionary<string, RichPanel>(this.panels);

			// Read file
			using (var fs = new FileStream(file, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
			using (var sr = new StreamReader(fs))
			{
				while (!sr.EndOfStream)
				{
					LogChanged(null, new LogFileMonitorLineEventArgs(sr.ReadLine()));
				}
			}

			// Menus
			this.windowsToolStripMenuItem.DropDownItems.Insert(2, new ToolStripSeparator());

			var pos = 2;

			foreach (var panel in this.panels.Except(stockPanels).Where(p => !p.Key.StartsWith("Client#")))
			{
				this.windowsToolStripMenuItem.DropDownItems.Insert(pos++, new ToolStripMenuItem
				{
					Text = panel.Key,
					CheckOnClick = true,
					Checked = true
				});
			}

			var clients = new Dictionary<string, List<string>>();

			foreach (var panel in this.panels.Except(stockPanels).Where(p => p.Key.StartsWith("Client#")))
			{
				var parts = panel.Key.Split(new[] { '|' }, StringSplitOptions.RemoveEmptyEntries);

				if (!clients.ContainsKey(parts[0])) clients.Add(parts[0], new List<string>());

				clients[parts[0]].Add(parts.Length == 1 ? "Master" : string.Join("|", parts.Skip(1)));
			}

			if (clients.Count > 0)
			{
				this.windowsToolStripMenuItem.DropDownItems.Insert(pos++, new ToolStripSeparator());
			}

			foreach (var client in clients)
			{
				var menu = new ToolStripMenuItem
				{
					Text = client.Key
				};

				foreach (var subMenu in client.Value)
				{
					menu.DropDownItems.Add(new ToolStripMenuItem
					{
						Text = subMenu,
						CheckOnClick = true,
						Checked = true
					});
				}

				this.windowsToolStripMenuItem.DropDownItems.Insert(pos, menu);
			}

			// Monitor file
			this.monitor = new LogFileMonitor(file, this);
			this.monitor.OnLineAddition += LogChanged;
			this.monitor.Start();

			// Focus master panel
			this.panels["Master"].Focus();
		}

		private void CreatePanel(string name, DockState state, Action<bool> visibilityCallback)
		{
			if (this.panels.ContainsKey(name)) return;

			var panel = new RichPanel(name, state, Settings.Instance.Theme);

			panel.VisibleChanged += (s, e) =>
			{
				visibilityCallback(panel.IsHidden);

				this.saveToolStripMenuItem.Enabled = this.panels.Values.Any(p => p.Visible && p.Text != "Welcome");
				this.copyToolStripMenuItem.Enabled = this.panels.Values.Any(p => p.Visible);
				this.selectAllToolStripMenuItem.Enabled = this.panels.Values.Any(p => p.Visible);
			};

			panel.PositionChanged += (s, e) =>
			{
				if (this.ActiveControl != s) return;

				this.timestampToolStripStatusLabel.Text = e.Timestamp;
				this.levelToolStripStatusLabel.Text = e.Level;
				this.lineToolStripStatusLabel.Text = $"Ln {e.Line}";
				this.columnToolStripStatusLabel.Text = $"Col {e.Column}";
				this.selectionToolStripStatusLabel.Text = $"Sel {Math.Abs(e.Position - e.Anchor)}";
			};

			panel.Show(this.dockPanel);

			this.panels[name] = panel;
		}

		private static string ParseClientLog(string log)
		{
			if (log.Length < 14) return log;
			if (!log.StartsWith("[")) return log;
			if (log.Substring(11, 1) != "]") return log;
			return !ClientLogPrefix.IsMatch(log.Substring(0, 13)) ? log : log.Substring(13);
		}

		private static Log ParseLine(string log)
		{
			if (string.IsNullOrWhiteSpace(log)) return null;

			var parts = Split.Split(ParseClientLog(log));

			if (!DateTime.TryParseExact(parts[0].Trim(), "s", null, DateTimeStyles.AssumeUniversal, out var dt)) return null;
			if (!parts[1].StartsWith("[") || !parts[1].EndsWith("]")) return null;

			var result = new Log
			{
				DateTime = dt,
				Level = parts[1].Substring(1, parts[1].Length - 2).Trim(),
				Prefix = string.Empty
			};

			var skip = 2;

			if (parts[2].StartsWith("[") && parts[2].EndsWith("]"))
			{
				skip++;
				result.Prefix = parts[2].Substring(1, parts[2].Length - 2).Trim().TrimEnd('|');
			}

			result.Message = string.Join(" ", parts.Skip(skip));

			return result;
		}

		private void LogChanged(object sender, LogFileMonitorLineEventArgs e)
		{
			var log = ParseLine(e.Line);
			if (log == null) return;

			if (!string.IsNullOrWhiteSpace(log.Prefix)) CreatePanel(log.Prefix, DockState.Document, hidden => { });
			if (!string.IsNullOrWhiteSpace(log.Level)) CreatePanel(log.Level, DockState.DockBottomAutoHide, hidden => { });

			this.panels["Master"].Log(log);

			if (!string.IsNullOrWhiteSpace(log.Prefix)) this.panels[log.Prefix].Log(new Log
			{
				DateTime = log.DateTime,
				Level = log.Level,
				Message = log.Message
			});

			if (!string.IsNullOrWhiteSpace(log.Level)) this.panels[log.Level].Log(new Log
			{
				DateTime = log.DateTime,
				Level = log.Level,
				Prefix = log.Prefix,
				Message = log.Message
			});
		}

		private void TogglePanelMenu(string panel)
		{
			var panelControl = this.panels[panel];

			if (!panelControl.Visible && panelControl.IsHidden)
			{
				panelControl.Show(this.dockPanel);
			}
			else
			{
				panelControl.Hide();
			}
		}

		private void OpenToolStripMenuItem_Click(object sender, EventArgs e)
		{
			using (var dialog = new OpenFileDialog
			{
				CheckFileExists = true,
				CheckPathExists = true,
				DefaultExt = "log",
				Filter = "Supported Logs|nfive.log;CitizenFX.log;CitizenFX.log.*|NFive Log|nfive.log|FiveM Client Log|CitizenFX.log;CitizenFX.log.*|Log (*.log)|*.log|Text (*.txt)|*.txt|All files (*.*)|*.*",
				Multiselect = false,
				ReadOnlyChecked = true,
				ShowHelp = false,
				Title = "Select the log file you want to view"
			})
			{
				if (dialog.ShowDialog() != DialogResult.OK) return;

				OpenFile(dialog.FileName);
			}
		}

		private void SaveToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (!(this.ActiveControl is Panel)) return;

			using (var dialog = new SaveFileDialog
			{
				FileName = $"{((Panel)this.ActiveControl).Text.Replace('|', '-')}",
				CreatePrompt = false,
				AddExtension = false,
				CheckFileExists = false,
				DefaultExt = "log",
				Filter = "Log|*.log|Text|*.txt|All files (*.*)|*.*",
				Title = "Select the file to save the log to",
				CheckPathExists = true
			})
			{
				if (dialog.ShowDialog() != DialogResult.OK) return;

				File.WriteAllText(dialog.FileName, (this.ActiveControl as RichPanel)?.Content, Encoding.UTF8);
			}
		}

		private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void CopyToolStripMenuItem_Click(object sender, EventArgs e)
		{
			(this.ActiveControl as RichPanel)?.Copy();
		}

		private void SelectAllToolStripMenuItem_Click(object sender, EventArgs e)
		{
			(this.ActiveControl as RichPanel)?.SelectAll();
		}

		private void FontToolStripMenuItem_Click(object sender, EventArgs e)
		{
			using (var dialog = new FontDialog
			{
				Font = Settings.Instance.Theme.Font,
				AllowScriptChange = false,
				AllowVerticalFonts = false,
				FontMustExist = true,
				ShowColor = false,
				ShowApply = true,
				ShowEffects = false,
				ShowHelp = false
			})
			{
				dialog.Apply += (s, a) =>
				{
					// ReSharper disable once AccessToDisposedClosure
					Settings.Instance.Theme.Font = dialog.Font;

					foreach (var panel in this.panels.Values)
					{
						panel.ApplyStyles(Settings.Instance.Theme);
					}
				};

				if (dialog.ShowDialog() != DialogResult.OK) return;

				Settings.Instance.Theme.Font = dialog.Font;

				foreach (var panel in this.panels.Values)
				{
					panel.ApplyStyles(Settings.Instance.Theme);
				}
			}

			Settings.Save();
		}

		private void ZoomInToolStripMenuItem_Click(object sender, EventArgs e)
		{
			foreach (var panel in this.panels.Values)
			{
				panel.ZoomIn();
			}
		}

		private void ZoomOutToolStripMenuItem_Click(object sender, EventArgs e)
		{
			foreach (var panel in this.panels.Values)
			{
				panel.ZoomOut();
			}
		}

		private void ResetZoomToolStripMenuItem_Click(object sender, EventArgs e)
		{
			foreach (var panel in this.panels.Values)
			{
				panel.Zoom = 0;
			}
		}

		private void WordWrapToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Settings.Instance.WordWrap = this.wordWrapToolStripMenuItem.CheckState == CheckState.Checked;

			foreach (var panel in this.panels.Values)
			{
				panel.WordWrap = Settings.Instance.WordWrap;
			}
		}

		private void PreferencesToolStripMenuItem_Click(object sender, EventArgs e)
		{
			using (var form = new Preferences())
			{
				form.Apply += (s, a) =>
				{
					foreach (var panel in this.panels.Values)
					{
						panel.ApplyStyles(Settings.Instance.Theme);
					}
				};

				if (form.ShowDialog() != DialogResult.OK) return;

				foreach (var panel in this.panels.Values)
				{
					panel.ApplyStyles(Settings.Instance.Theme);
				}
			}

			Settings.Save();
		}

		private void MasterToolStripMenuItem_Click(object sender, EventArgs e)
		{
			TogglePanelMenu("Master");
		}

		private void LevelTraceToolStripMenuItem_Click(object sender, EventArgs e)
		{
			TogglePanelMenu("Trace");
		}

		private void LevelDebugToolStripMenuItem_Click(object sender, EventArgs e)
		{
			TogglePanelMenu("Debug");
		}

		private void LevelInfoToolStripMenuItem_Click(object sender, EventArgs e)
		{
			TogglePanelMenu("Info");
		}

		private void LevelWarnToolStripMenuItem_Click(object sender, EventArgs e)
		{
			TogglePanelMenu("Warn");
		}

		private void LevelErrorToolStripMenuItem_Click(object sender, EventArgs e)
		{
			TogglePanelMenu("Error");
		}

		private void AboutToolStripMenuItem_Click(object sender, EventArgs e)
		{
			using (var form = new About())
			{
				form.ShowDialog();
			}
		}
	}
}
