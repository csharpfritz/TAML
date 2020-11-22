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
					WriteKeyWithTamlValue(indentCount, item, yaml);
				}
			}

			var yamlResult = yaml.ToString();
			return yamlResult;
		}

		private static string Indent(int indentCount)
		{
			return "".PadLeft(indentCount) + (indentCount > 0 ? "- " : "");
		}

		private static void WriteKeyWithTamlValue(int indentCount, TamlKeyValuePair tamlKvp, StringBuilder stringBuilder)
		{
			var isTamlValue = tamlKvp.Value is TamlValue;
			var isTamlArray = tamlKvp.Value is TamlArray;

			if (isTamlArray && isTamlValue)
			{
				stringBuilder.AppendLine($"{Indent(indentCount)}{tamlKvp.Key}:");
			}

			if (isTamlArray && tamlKvp.HasValue && tamlKvp.Value != null)
			{
				var tva = (TamlArray)tamlKvp.Value;
				foreach (var item in tva)
				{
					WriteKeyWithTamlValue(indentCount + 2, (TamlKeyValuePair)item, stringBuilder);
				}
			}
			else if (isTamlValue)
			{
				stringBuilder.AppendLine($"{Indent(indentCount)}{tamlKvp.Key}: {tamlKvp.Value}");
			}
			else
			{
				stringBuilder.AppendLine($"{Indent(indentCount)}{ tamlKvp.Key}");
			}
		}
	}
}
