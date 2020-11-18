using System.IO;

namespace Test.Taml.NET
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
