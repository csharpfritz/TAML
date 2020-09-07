using System.IO;
using TAML;
using Test.Taml.NET;
using Xunit;

namespace Taml.NET.GivenKeyValuePairsWithArray
{
	public class WhenParserReadsDocument : BaseFixture
	{

		protected override string SampleFilename => "GivenKeyValuePairsWithArray/sample.taml";

		[Fact]
		public void ShouldFindTwoKeyPairs()
		{

			var doc = Parser.Parse(base.Sample);

			Assert.Equal(2, doc.KeyValuePairs.Count);

		}

	}

}
