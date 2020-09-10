using System;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;

namespace TAML
{

	public class Parser
	{

		private static readonly Regex _KeyValuePair = new Regex(@"(?<key>\S[^\t]*)\t+(?<value>\S[^\t]*)");
		private static readonly Regex _SingleValue = new Regex(@"^\t*\S[^\t]*\t*$");

		public static TamlDocument Parse(StreamReader rdr) {

			rdr.BaseStream.Position = 0;
			byte currentLevel = 0;
			byte previousLevel = 0;
			TamlArray currentArray = null;
			var currentLabel = string.Empty;
			var outDoc = new TamlDocument();

			while (!rdr.EndOfStream) {

				previousLevel = currentLevel;
				var line = rdr.ReadLine();
				currentLevel = IdentifyLevel(line);

				if (previousLevel > currentLevel) {
					if (currentArray != null) {
						outDoc.KeyValuePairs.Add(currentLabel, currentArray);
						currentArray = null;
						currentLabel = string.Empty;
					}
				}

				if (_SingleValue.IsMatch(line)) {
					if (string.IsNullOrEmpty(currentLabel)) {
						currentLabel = line.Trim();
						// add existing array to the doc
						currentArray = new TamlArray();
					} else {
						currentArray.AppendValue(new TamlValue(line.Trim()));
					}

				} else if (_KeyValuePair.IsMatch(line)) { 

					// cleanup any arrays or items that need to be added

					Console.WriteLine(line + "-" + _KeyValuePair.Matches(line).Count);
					var captures = _KeyValuePair.Matches(line)[0].Groups;

					if (string.IsNullOrEmpty(currentLabel))
					{
						outDoc.KeyValuePairs.Add(captures["key"].Value, new TamlValue(captures["value"].Value));
					} else {
						currentArray.AppendValue(new TamlKeyValuePair(captures["key"].Value, new TamlValue(captures["value"].Value)));
					}
				}
			}

			// add any leftover objects to the doc
			if (currentArray != null) outDoc.KeyValuePairs.Add(currentLabel, currentArray);

			return outDoc;

		}

		private static byte IdentifyLevel(string line) {

			byte outValue = 0;

			for (byte i=0; i<line.Length; i++) {
				if (line[i] == '\t') outValue++;
				else break;
			}

			return outValue;

		}

	}

}
