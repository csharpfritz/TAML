using System.Linq;
using TAML;
using Xunit;

namespace Test.Taml.NET.GivenOnlyKeyValuePairs
{
	public class WhenArrayFirst : BaseFixture
	{

		protected override string SampleFilename => "GivenKeyValuePairsWithArray/arrayfirst.taml";


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
