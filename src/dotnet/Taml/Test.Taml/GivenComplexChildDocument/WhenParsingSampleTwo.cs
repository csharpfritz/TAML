using System.Linq;

using TAML;

using Xunit;

namespace Test.Taml.GivenComplexChildDocument
{
	public class WhenParsingSampleTwo : BaseFixture
	{
		protected override string SampleFilename => "GivenComplexChildDocument/sample2.taml";

		[Fact]
		public void ShouldHaveTwoRootKeys()
		{
			var doc = Parser.Parse(base.Sample);

			Assert.Equal(2, doc.KeyValuePairs.Count);
			Assert.Equal("root1", doc.KeyValuePairs.First().Key);
			Assert.Equal("root2", doc.KeyValuePairs.Last().Key);
		}

		[Fact]
		public void ShouldHaveFourElementsInTheTopArray()
		{
			var doc = Parser.Parse(base.Sample);

			Assert.Equal(4, ((TamlArray)doc.KeyValuePairs.First().Value).Count());
		}

		[Fact]
		public void ShouldHaveFourElementsInTheSecondArray()
		{
			var doc = Parser.Parse(base.Sample);

			Assert.Equal(4, ((TamlArray)doc.KeyValuePairs.Last().Value).Count());
		}

		[Fact]
		public void ShouldHaveCorrectValueTypesInFirstArray()
		{
			var doc = Parser.Parse(base.Sample);

			var rootValue = ((TamlArray)doc.KeyValuePairs.First().Value);
			Assert.IsType<TamlKeyValuePair>(rootValue[0]);
			Assert.IsType<TamlKeyValuePair>(rootValue[1]);
			Assert.IsType<TamlKeyValuePair>(rootValue[2]);

			Assert.IsType<TamlArray>((rootValue[2] as TamlKeyValuePair).Value);
			Assert.IsType<TamlKeyValuePair>(rootValue[3]);
			Assert.Equal("key4: value4", rootValue[3].ToString());
		}
	}
}
