using System;
using System.Collections.Generic;
using System.Text;

namespace TAML.Writer.Yaml
{
	public class YamlWriter
	{
		///<summary>
		/// Convert the provided `tamlDocument` to a Yaml string.
		///</summary>
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

			return yaml.ToString();
		}

		/// Create an 'indentation string that contains `indentCount` spaces.
		/// If the indentCount is grater than 0 then append the YAML 'Block Sequence' character
		private static string Indent(int indentCount)
		{
			return "".PadLeft(indentCount) + (indentCount > 0 ? "- " : "");
		}

		/// Write a TamlKeyValuePair to the StringBuilder.
		/// If the value is both a TamlValue and TamlArray then write only the "Key" with YAML 'Mapping Key'.
		/// Then either:
		///  a)  a TamlArray, then write each TamlKeyValuePair recursively
		///  b)  a TamlValue, then write the Key and Value
		///  c)  neither, then simply write the Key 
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
				stringBuilder.AppendLine($"{Indent(indentCount)}{tamlKvp.Key}");
			}
		}
	}
}
