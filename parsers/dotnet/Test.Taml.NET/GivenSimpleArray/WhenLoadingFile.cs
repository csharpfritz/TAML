using System.IO;
using System.Linq;

using TAML;

using Xunit;

namespace Test.Taml.NET.GivenSimpleArray
{

	public class WhenLoadingFile : BaseFixture
	{

		public WhenLoadingFile() : base()
		{

		}

		protected override string SampleFilename => "GivenSimpleArray/simple.taml";

		[Fact]
		public void ThenShouldFindAnArray()
		{

			var result = Parser.Parse(Sample);

			Assert.Single(result.KeyValuePairs);
			Assert.IsType<TamlArray>(result.KeyValuePairs.First().Value);

		}

		[Fact]
		public void ThenArrayShouldContainThreeElements()
		{

			var result = Parser.Parse(Sample);

			var entry = result.KeyValuePairs.First();
			Assert.Equal("key", entry.Key);

			var array = entry.Value as TamlArray;
			Assert.Equal(3, array.Count());

		}

		[Fact]
		public void ThenArrayShouldIgnoreTrailingSpace()
		{

			var result = Parser.Parse(Sample);

			var entry = result.KeyValuePairs.First();
			Assert.Equal("key", entry.Key);

			var array = entry.Value as TamlArray;
			Assert.Equal("value3", array[2].ToString());

		}

	}

}
