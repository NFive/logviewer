using System;

namespace NFive.LogViewer
{
	public class Log
	{
		public DateTime DateTime { get; set; }

		public string Level { get; set; }

		public string Prefix { get; set; }

		public string Message { get; set; }

		public override string ToString() => $"{this.DateTime:s} [{this.Level}]{(string.IsNullOrEmpty(this.Prefix) ? string.Empty : $" [{this.Prefix}]")} {this.Message}";
	}
}
