namespace TAML
{
	public class TamlKeyValuePair : TamlValue
	{
		public TamlKeyValuePair(string key, TamlValue? value)
		{
			this.Key = key;
			this.Value = value;
		}

		public string Key { get; set; }

		public TamlValue? Value { get; set; }

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
