using System.Collections.Generic;

namespace TAML
{
	public class TamlDocument
	{

		public List<TamlKeyValuePair> KeyValuePairs { get; set; } = new List<TamlKeyValuePair>();

		public IEnumerable<TamlKeyValuePair> ProcessorDirectives { get; set; } = new List<TamlKeyValuePair>();

	}

}
