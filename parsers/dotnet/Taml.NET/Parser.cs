using System;
using System.IO;
using System.Text.RegularExpressions;

namespace TAML
{

	public class Parser
	{

		private static readonly Regex _KeyValuePair = new Regex(@"(?<key>\S[^\t]*)\t+(?<value>\S[^\t]*)");

		public static TamlDocument Parse(StreamReader rdr) {

			rdr.BaseStream.Position = 0;
			var outDoc = new TamlDocument();

			while (!rdr.EndOfStream) {
				var line = rdr.ReadLine();
				Console.WriteLine(line + "-" + _KeyValuePair.Matches(line).Count);
				var captures = _KeyValuePair.Matches(line)[0].Groups;
				outDoc.KeyValuePairs.Add(captures["key"].Value, new TamlValue(captures["value"].Value));
			}

			return outDoc;

		}

	}

}
