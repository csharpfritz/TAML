using System.Linq;

using TAML;

using Xunit;

namespace Test.Taml.NET.GivenComplexChildDocument
{
	public class WhenParsingSampleOne : BaseFixture
	{
		protected override string SampleFilename => "GivenComplexChildDocument/sample1.taml";

		[Fact]
		public void ShouldHaveOneRootKey()
		{
			var doc = Parser.Parse(base.Sample);

			Assert.Single(doc.KeyValuePairs);
			Assert.Equal("root", doc.KeyValuePairs.First().Key);
		}

		[Fact]
		public void ShouldHaveThreeElementsInTheTopArray()
		{
			var doc = Parser.Parse(base.Sample);

			Assert.Equal(3, ((TamlArray)doc.KeyValuePairs.First().Value).Count());
		}

		[Fact]
		public void ShouldHaveCorrectValueTypesInTheTopArray()
		{
			var doc = Parser.Parse(base.Sample);

			var rootValue = ((TamlArray)doc.KeyValuePairs.First().Value);
			Assert.IsType<TamlKeyValuePair>(rootValue[0]);
			Assert.IsType<TamlKeyValuePair>(rootValue[1]);
			Assert.IsType<TamlArray>(rootValue[2]);
		}
	}
}
