using System;
using System.Collections.Generic;
using System.Text;

namespace TAML.Writer.Yaml
{
	public class YamlWriter
	{
		public static string Write(TamlDocument tamlDocument)
		{
			var yaml = new StringBuilder();
			var indentCount = 0;

			foreach (var item in tamlDocument.KeyValuePairs)
			{
				if (item.HasValue && item.Value != null)
				{
					WriteValue(indentCount, item.Value, yaml);
				}
			}

			var yamlResult = yaml.ToString();
			return yamlResult;
		}

		private static string Indent(int indentCount)
		{
			return "".PadLeft(indentCount);
		}

		private static void WriteValue(int indentCount, TamlValue tamlValue, StringBuilder stringBuilder)
		{
			switch (tamlValue.GetType().Name)
			{
				case "TamlArray":
					var valueArray = (TamlArray)tamlValue;
					stringBuilder.AppendLine($"{Indent(indentCount)}{tamlValue}:");
					foreach (var value in valueArray)
					{
						WriteValue(indentCount + 2, value, stringBuilder);
						stringBuilder.AppendLine($"{Indent(indentCount + 2)}- {value}");
					}

					break;

				case "TamlValue":
					stringBuilder.AppendLine($"{Indent(indentCount)}{tamlValue}: {tamlValue}");

					break;
			}
		}
	}
}
