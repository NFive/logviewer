using System;
using System.Drawing;
using System.Globalization;
using YamlDotNet.Core;
using YamlDotNet.Core.Events;
using YamlDotNet.Serialization;

namespace NFive.LogViewer.Configuration
{
	public class ColorConverter : IYamlTypeConverter
	{
		public bool Accepts(Type type) => type == typeof(Color);

		public object ReadYaml(IParser parser, Type type)
		{
			var value = ((Scalar)parser.Current).Value;
			parser.MoveNext();

			return Color.FromArgb(int.Parse(value, NumberStyles.HexNumber));
		}

		public void WriteYaml(IEmitter emitter, object value, Type type)
		{
			var color = (Color)value;

			emitter.Emit(new Scalar(color.ToArgb().ToString("X")));
		}
	}
}
