using System.Drawing;

namespace NFive.LogViewer.Configuration
{
	public static class ColorExtensions
	{
		public static Color ToColor(this uint value)
		{
			var a = (byte)(value >> 24);
			var r = (byte)(value >> 16);
			var g = (byte)(value >> 8);
			var b = (byte)value;

			return Color.FromArgb(a, r, g, b);
		}
	}
}
