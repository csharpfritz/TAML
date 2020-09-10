namespace TAML
{
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

		public static implicit operator string(TamlValue value) {

			return value.ToString();

		}

	}

}
