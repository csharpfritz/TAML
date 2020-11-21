using System;
using System.Collections.Generic;
using System.Text;

namespace TAML
{

	internal class ParsedDocument
	{

		public ParsedDocument(Dictionary<int, (int indent, TamlKeyValuePair value)> lines, IEnumerable<TamlKeyValuePair> processorDirectives)
		{
			Lines = lines;
			ProcessorDirectives = processorDirectives;
		}

		public Dictionary<int, (int indent, TamlKeyValuePair value)> Lines { get; private set; }

		public IEnumerable<TamlKeyValuePair> ProcessorDirectives { get; private set; }

	}

}
