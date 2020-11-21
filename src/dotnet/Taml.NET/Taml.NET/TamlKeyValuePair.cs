namespace TAML
{

	/// <summary>
	/// Represents a key and value entry in a TAML document
	/// </summary>
	public class TamlKeyValuePair : TamlValue
	{
		public TamlKeyValuePair(string key, TamlValue? value)
		{
			this.Key = key;
			this.Value = value;
		}

		/// <summary>
		/// The unique identifier that represents this entry
		/// </summary>
		/// <value></value>
		public string Key { get; set; }

		/// <summary>
		/// Entry that corresponds to the key
		/// </summary>
		/// <value></value>
		public TamlValue? Value { get; set; }

		/// <summary>
		/// Boolean indicating if a value is present
		/// </summary>
		public bool HasValue => Value != null;

		public override string ToString()
		{
			return HasValue ? $"{Key}: {Value}" : Key;
		}

		public static implicit operator string(TamlKeyValuePair value)
		{
			return value.ToString();
		}


	}


}
