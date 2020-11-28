using System.Collections.Generic;

namespace TAML
{

	/// <summary>
	/// A representation of a TAML document
	/// </summary>
	public class TamlDocument
	{

		/// <summary>
		/// The collection of data stored in the document
		/// </summary>
		/// <typeparam name="TamlKeyValuePair">The data represented in the document</typeparam>
		/// <returns></returns>
		public List<TamlKeyValuePair> KeyValuePairs { get; set; } = new List<TamlKeyValuePair>();

		/// <summary>
		/// Instructions for the parser that were identified in the document
		/// </summary>
		/// <typeparam name="TamlKeyValuePair"></typeparam>
		/// <returns>The instruction keys and their configured values</returns>
		public IEnumerable<TamlKeyValuePair> ProcessorDirectives { get; set; } = new List<TamlKeyValuePair>();

	}

}
