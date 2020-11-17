using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace TAML
{
	public class Parser
	{
		private static readonly Regex _KeyValuePair = new Regex(@"(?<key>\S[^\t]*)\t+(?<value>\S[^\t]*)");
		private static readonly Regex _SingleValue = new Regex(@"^\t*\S[^\t]*\t*$");

		/// <summary>
		/// The maximum TAML specification version supported by this parser
		/// </summary>
		/// <returns></returns>
		public static Version SupportedSpecVersion => new Version(1,1); 

		public static TamlDocument Parse(StreamReader reader)
		{

			var lines = ReadLines(reader);

			var document = new TamlDocument();

			int currentLevel = 0;

			var stack = new Stack<TamlKeyValuePair>();

			for (var i = 0; i < lines.Count; i++)
			{

				var (indent, currentPair) = lines[i];

				if (indent == 0)
				{
					// line is root element
					document.KeyValuePairs.Add(currentPair!);
					currentLevel = 0;
					continue;
				}

				if (indent > currentLevel)
				{
					stack.Push(lines[i - 1].value);
				}
				else if (indent < currentLevel)
				{
					stack.Pop();
				}

				TamlKeyValuePair? parent = stack.Count > 0 ? stack.Peek() : null;

				if (indent > currentLevel)
				{
					if (parent!.Value is null)
					{
						var newArray = new TamlArray();
						newArray.AppendValue(currentPair);
						parent.Value = newArray;
					}
				}
				else if (parent != null && parent.Value is TamlArray parentArray)
				{
					parentArray.AppendValue(currentPair);
				}

				currentLevel = indent;
			}
			return document;
		}

		public static TamlDocument ParseFile(string fileName)
		{
			var sr = new StreamReader(fileName);
			return Parse(sr);
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

		private static TamlValue GetPairIfNoValue(TamlKeyValuePair currentPair)
		{
			return currentPair.HasValue && !string.IsNullOrEmpty(currentPair.Value) ? currentPair : new TamlKeyValuePair(currentPair!.Key, null);
		}

		private static Dictionary<int, (int indent, TamlKeyValuePair value)> ReadLines(StreamReader reader)
		{
			var lines = new Dictionary<int, (int indent, TamlKeyValuePair value)>();
			int currentLineNumber = 0;

			while (!reader.EndOfStream)
			{
				var rawLine = reader.ReadLine();

				// Handle comments - ignore and read next line
				if (rawLine?[0] == '#') continue;

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
	}
}
