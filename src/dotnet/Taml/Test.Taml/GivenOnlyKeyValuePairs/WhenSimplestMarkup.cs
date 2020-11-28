using System;
using System.IO;
using System.Linq;
using TAML;
using Xunit;

namespace Test.Taml.GivenOnlyKeyValuePairs
{
	public class WhenSimplestMarkup : BaseFixture
	{

		protected override string SampleFilename => "GivenOnlyKeyValuePairs/simple.taml";


		[Fact]
		public void ShouldFindTwoKeyValuePairs()
		{

			// arrange

			// act
			var result = Parser.Parse(base.Sample);

			// assert
			Assert.Equal(2, result.KeyValuePairs.Count());

		}

	}
}
