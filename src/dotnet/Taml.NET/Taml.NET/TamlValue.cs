namespace TAML
{
	public class TamlValue
	{
		private readonly string _Value = string.Empty;

		protected TamlValue()
		{
		}

		public TamlValue(string value)
		{
			this._Value = value;
		}

		public override string ToString()
		{
			return _Value;
		}

		public static implicit operator string(TamlValue? value)
		{
			return value?.ToString() ?? string.Empty;
		}
	}
}
