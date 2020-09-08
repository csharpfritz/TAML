using System.Collections.Generic;

namespace TAML
{
	public class TamlDocument
	{

		public Dictionary<string, TamlValue> KeyValuePairs { get; set; } = new Dictionary<string, TamlValue>();

	}

	public class TamlValue
	{
		private string value;

		protected TamlValue() { }

		public TamlValue(string value)
		{
			this.value = value;
		}

		public override string ToString()
		{
			return value;
		}

	}

}
