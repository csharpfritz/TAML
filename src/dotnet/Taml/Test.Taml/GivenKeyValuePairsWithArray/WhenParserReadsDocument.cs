using System.IO;
using TAML;
using Test.Taml;
using Xunit;

namespace Test.Taml.GivenKeyValuePairsWithArray
{
	public class WhenParserReadsDocument : BaseFixture
	{

		protected override string SampleFilename => "GivenKeyValuePairsWithArray/sample.taml";

		[Fact]
		public void ShouldFindTwoKeyPairs()
		{

			var doc = Parser.Parse(Sample);

			Assert.Equal(2, doc.KeyValuePairs.Count);

		}

	}

}
