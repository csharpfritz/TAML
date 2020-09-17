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

		public override string ToString()
		{
			return $"{Key}: {Value?.ToString()}";
		}

		public static implicit operator string(TamlKeyValuePair value)
		{
			return value.ToString();
		}


	}


}
