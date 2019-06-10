using System;
using System.Drawing;
using YamlDotNet.Core;
using YamlDotNet.Core.Events;
using YamlDotNet.Serialization;

namespace NFive.LogViewer.Configuration
{
	public class FontConverter : IYamlTypeConverter
	{
		public bool Accepts(Type type) => type == typeof(Font);

		public object ReadYaml(IParser parser, Type type)
		{
			parser.MoveNext();

			parser.MoveNext();
			var name = ((Scalar)parser.Current).Value;
			parser.MoveNext();

			parser.MoveNext();
			var style = ((Scalar)parser.Current).Value;
			parser.MoveNext();

			parser.MoveNext();
			var size = float.Parse(((Scalar)parser.Current).Value);
			parser.MoveNext();

			parser.MoveNext();

			return new Font(new FontFamily(name), size, (FontStyle)Enum.Parse(typeof(FontStyle), style), GraphicsUnit.Point);
		}

		public void WriteYaml(IEmitter emitter, object value, Type type)
		{
			var font = (Font)value;

			emitter.Emit(new MappingStart(null, null, false, MappingStyle.Any));

			emitter.Emit(new Scalar(null, "Name"));
			emitter.Emit(new Scalar(null, font.Name));

			emitter.Emit(new Scalar(null, "Style"));
			emitter.Emit(new Scalar(null, font.Style.ToString()));

			emitter.Emit(new Scalar(null, "Size"));
			emitter.Emit(new Scalar(null, font.SizeInPoints.ToString("F0")));

			emitter.Emit(new MappingEnd());
		}
	}
}
