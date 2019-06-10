using System.Collections.Generic;
using System.Drawing;
using JetBrains.Annotations;

namespace NFive.LogViewer.Configuration
{
	[PublicAPI]
	public class Settings : YamlSettings<Settings>
	{
		public bool WordWrap { get; set; }

		public bool ShowWelcomeTab { get; set; } = true;

		public bool RestoreLastFile { get; set; }

		public ushort FileHistory { get; set; } = 10;

		public ThemeConfiguration Theme { get; set; } = new ThemeConfiguration();

		public WindowState Window { get; set; } = new WindowState();

		public class ThemeConfiguration
		{
			public Font Font { get; set; } = new Font(new FontFamily("Consolas"), 10, FontStyle.Regular, GraphicsUnit.Point);

			public Color EditorBackground = 0xFF212121.ToColor();

			public Color EditorText = 0xFFFFFFFF.ToColor();

			public Color MarginBackground = 0xFF212121.ToColor();

			public Color MarginText = 0xFFBBBBBB.ToColor();

			public Dictionary<string, Color> LevelColors = new Dictionary<string, Color>
			{
				{ "Trace", 0xFF2C2F33.ToColor() },
				{ "Debug", 0xFF808080.ToColor() },
				{ "Info", 0xFF3768B7.ToColor() },
				{ "Warn", 0xFFFFCC00.ToColor() },
				{ "Error", 0xFFE95378.ToColor() }
			};

			public Dictionary<string, Color> SyntaxColors = new Dictionary<string, Color>
			{
				{ "Prefix", 0xFFD7AB4C.ToColor() },
				{ "Number", 0xFF4EC9B0.ToColor() },
				{ "String", 0xFFCE9178.ToColor() },
				{ "Property", 0xFF9CDCFE.ToColor() },
				{ "Operator", 0xFFBBBBBB.ToColor() },
				{ "Uri", 0xFFE95378.ToColor() },
				{ "Keyword", 0xB877DBE6.ToColor() }
			};
		}

		public class WindowState
		{
			public int X { get; set; } = 100;

			public int Y { get; set; } = 100;

			public int Width { get; set; } = 1000;

			public int Height { get; set; } = 600;

			public bool Maximized { get; set; }
		}
	}
}
