using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;

namespace TAML
{

	public class Parser
	{

		private static readonly Regex _KeyValuePair = new Regex(@"(?<key>\S[^\t]*)\t+(?<value>\S[^\t]*)");
		private static readonly Regex _SingleValue = new Regex(@"^\t*\S[^\t]*\t*$");

		public static TamlDocument Parse(StreamReader reader)
		{
			//return ParseNonRecursive(reader);
			//var (_, parsedDocument) = ParseRecursive(0, reader); // We start parsing at the root (=0) level
			//return (TamlDocument)parsedDocument!;

			var lines = ReadLines(reader);

			var document = new TamlDocument();

			int currentLevel = 0;

			TamlKeyValuePair? parent = null;

			for (var i = 0; i < lines.Count; i++)
			{

				var (indent, tamlValue) = lines[i];

				var tamlKeyValuePair = tamlValue as TamlKeyValuePair;



				if (indent == 0)
				{
					// line is root element
					document.KeyValuePairs.Add(tamlKeyValuePair!);
					currentLevel = 0;
				}
				else if (indent > currentLevel)
				{
					// belongs to the parrent

					parent = lines[i - 1].value as TamlKeyValuePair;

					if (parent!.Value is null)
					{
						var newValue = new TamlArray();
						newValue.AppendValue(new TamlValue(tamlKeyValuePair!.Key));
						parent.Value = newValue;
						currentLevel = indent;
					}
				}
				else if (indent < currentLevel)
				{
					// we have to go one indent level up
					currentLevel = indent;
					i--;
				}
				else if (indent == currentLevel && parent != null && parent.Value is TamlArray parrentArray)
				{
					parrentArray.AppendValue(new TamlValue(tamlKeyValuePair!.Key));
				}
			}
			return document;
		}

		private static Dictionary<int, (int indent, TamlValue value)> ReadLines(StreamReader reader)
		{
			var lines = new Dictionary<int, (int indent, TamlValue value)>();
			int currentLineNumber = 0;

			while (!reader.EndOfStream)
			{
				var rawLine = reader.ReadLine();
				var indent = CountIntendedTabs(rawLine);
				var line = rawLine.Trim();
				TamlKeyValuePair? value = null;

				if (string.IsNullOrEmpty(line))
				{
					// empty line we ignore
					currentLineNumber--; // we don't count empty lines
					continue;
				}
				else if (line.Contains('\t'))
				{
					// this is a KeyValuePair
					var match = _KeyValuePair.Matches(line)[0].Groups;

					value = new TamlKeyValuePair(match["key"].Value, new TamlValue(match["value"].Value));
				}
				else
				{
					// this is a single value
					value = new TamlKeyValuePair(line, null);
				}
				lines.Add(currentLineNumber, (indent, value));
				currentLineNumber++;
			}
			return lines;
		}

		private static int CountIntendedTabs(string currentLine)
		{
			int tabs = 0;

			while (currentLine[tabs] == '\t')
			{
				tabs++;
			}

			return tabs;
		}
	}
}
