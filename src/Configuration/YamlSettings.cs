using System;
using System.IO;
using JetBrains.Annotations;
using YamlDotNet.Serialization;

namespace NFive.LogViewer.Configuration
{
	[PublicAPI]
	public abstract class YamlSettings<T> : ISettings<T> where T : class, ISettings<T>, new()
	{
		// ReSharper disable once StaticMemberInGenericType
		private static string directory = AppDomain.CurrentDomain.BaseDirectory;
		private static T instance;

		public static T Instance
		{
			get
			{
				if (instance != null) return instance;

				try
				{
					instance = new DeserializerBuilder()
						.WithTypeConverter(new ColorConverter())
						.WithTypeConverter(new FontConverter())
						.Build()
						.Deserialize<T>(File.ReadAllText(Path));

					// ReSharper disable once ThrowExceptionInUnexpectedLocation
					if (instance == null) throw new FileNotFoundException();
				}
				catch
				{
					instance = new T();
					instance = instance.Initialize();
					Save();
				}

				return instance;
			}
		}

		public static string Path => System.IO.Path.Combine(Directory, FileName);

		public static bool FileExists => File.Exists(Path);

		// ReSharper disable once StaticMemberInGenericType
		public static string FileName { get; set; } = "settings.yml";

		public static string Directory
		{
			get => directory;
			set
			{
				if (!System.IO.Directory.Exists(value)) throw new DirectoryNotFoundException();

				directory = value;
			}
		}

		public virtual T Initialize()
		{
			instance = new T();

			return instance;
		}

		public static void Save()
		{
			File.WriteAllText(Path, new SerializerBuilder()
				.WithTypeConverter(new ColorConverter())
				.WithTypeConverter(new FontConverter())
				.Build()
				.Serialize(Instance));
		}
	}

	public interface ISettings<out T>
	{
		T Initialize();
	}
}
