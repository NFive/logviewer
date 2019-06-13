using System;
using System.ComponentModel;
using System.IO;
using JetBrains.Annotations;

namespace NFive.LogViewer
{
	public class LogFileMonitorLineEventArgs : EventArgs
	{
		public string Line { get; }

		public LogFileMonitorLineEventArgs(string line)
		{
			this.Line = line;
		}
	}

	[PublicAPI]
	public class LogFileMonitor
	{
		private readonly object @lock = new object();
		private readonly string path;
		private readonly string delimiter;
		private readonly FileSystemWatcher watcher;
		private string buffer;
		private long size;
		private bool monitoring;

		public event EventHandler<EventArgs> Created;
		public event EventHandler<EventArgs> Deleted;
		public event EventHandler<EventArgs> Renamed;
		public event EventHandler<EventArgs> Changed;
		public event EventHandler<LogFileMonitorLineEventArgs> LineAdded;

		public LogFileMonitor(string path, ISynchronizeInvoke synchronizingObject = null, string delimiter = "\n")
		{
			this.path = path;
			this.delimiter = delimiter;
			this.watcher = new FileSystemWatcher(Path.GetDirectoryName(this.path), Path.GetFileName(this.path))
			{
				SynchronizingObject = synchronizingObject
			};

			this.watcher.Changed += (s, a) =>
			{
				Check();

				this.Changed?.Invoke(this, EventArgs.Empty);
			};

			this.watcher.Created += (s, a) =>
			{
				this.size = new FileInfo(this.path).Length;
				this.buffer = string.Empty;

				this.Created?.Invoke(this, EventArgs.Empty);
			};

			this.watcher.Deleted += (s, a) =>
			{
				this.size = 0;
				this.buffer = string.Empty;

				this.Deleted?.Invoke(this, EventArgs.Empty);
			};

			this.watcher.Renamed += (s, a) =>
			{
				this.size = 0;
				this.buffer = string.Empty;

				this.Renamed?.Invoke(this, EventArgs.Empty);
			};

			this.watcher.EnableRaisingEvents = true;
		}

		public void Start()
		{
			this.size = new FileInfo(this.path).Length;
			this.buffer = string.Empty;

			this.watcher.EnableRaisingEvents = true;
		}

		public void Stop()
		{
			this.watcher.EnableRaisingEvents = false;
		}

		private bool StartMonitoring()
		{
			lock (this.@lock)
			{
				if (this.monitoring) return true;

				this.monitoring = true;
				return false;
			}
		}

		private void Check()
		{
			if (!StartMonitoring()) return;

			var newSize = new FileInfo(this.path).Length;

			if (this.size >= newSize) return;

			using (var stream = File.Open(this.path, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
			using (var sr = new StreamReader(stream, true))
			{
				sr.BaseStream.Seek(this.size, SeekOrigin.Begin);

				var data = this.buffer + sr.ReadToEnd();

				if (!data.EndsWith(this.delimiter))
				{
					if (data.IndexOf(this.delimiter, StringComparison.Ordinal) == -1)
					{
						this.buffer += data;

						data = string.Empty;
					}
					else
					{
						var pos = data.LastIndexOf(this.delimiter, StringComparison.Ordinal) + this.delimiter.Length;

						this.buffer = data.Substring(pos);

						data = data.Substring(0, pos);
					}
				}

				var lines = data.Split(new[] { this.delimiter }, StringSplitOptions.RemoveEmptyEntries);

				foreach (var line in lines)
				{
					this.LineAdded?.Invoke(this, new LogFileMonitorLineEventArgs(line));
				}
			}

			this.size = newSize;

			lock (this.@lock) this.monitoring = false;
		}
	}
}
