using System;

namespace NFive.LogViewer
{
	public class PositionEventArgs : EventArgs
	{
		public int Line { get; }

		public int Column { get; }

		public int Position { get; }

		public int Anchor { get; }

		public string Timestamp { get; }

		public string Level { get; }

		public PositionEventArgs(int line, int column, int position, int anchor, string timestamp, string level)
		{
			this.Line = line;
			this.Column = column;
			this.Position = position;
			this.Anchor = anchor;
			this.Timestamp = timestamp;
			this.Level = level;
		}
	}
}
