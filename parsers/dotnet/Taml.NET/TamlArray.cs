using System.Collections.Generic;
using System.Linq;

namespace TAML
{
	public class TamlArray : TamlValue
	{

		private readonly List<string> _Values = new List<string>();

		public string this[int pos] {
			get { return _Values.Skip(pos).First();}
		}

		internal void AppendValue(string newValue) {
			_Values.Add(newValue);
		}

	}	


}
