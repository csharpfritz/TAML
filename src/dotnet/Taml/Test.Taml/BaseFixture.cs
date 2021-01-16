using System.IO;

namespace Test.Taml
{
	public abstract class BaseFixture
	{
		protected StreamReader Sample { get; }

		protected abstract string SampleFilename { get; }

		public BaseFixture() 
		{
			Sample = new StreamReader(File.OpenRead(SampleFilename));
		}

	}
}
