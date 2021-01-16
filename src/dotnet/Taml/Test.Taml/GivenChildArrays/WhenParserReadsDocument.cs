using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TAML;
using Xunit;

namespace Test.Taml.GivenChildArrays
{
	public class WhenParserReadsDocument : BaseFixture
	{

		protected override string SampleFilename => "GivenChildArrays/childarrays.taml";

		[Fact]
		public void ShouldFindThreeElements() {

			var result = Parser.Parse(base.Sample);

			Assert.Equal(3, (result.KeyValuePairs.First().Value as TamlArray).Count());
			Assert.Equal(3, result.KeyValuePairs.Count);

			var thisPair = result.KeyValuePairs.First();
			Assert.Equal("value1", thisPair.Key);
			Assert.Equal("value12", ((TamlArray)(thisPair.Value))[0]);
			Assert.Equal("value13", ((TamlArray)(thisPair.Value))[1]);
			Assert.Equal("value14", ((TamlArray)(thisPair.Value))[2]);

			thisPair = result.KeyValuePairs.Skip(1).First();
			Assert.Equal("value2", thisPair.Key);
			Assert.Equal("value22", ((TamlArray)(thisPair.Value))[0]);
			Assert.Equal("value23", ((TamlArray)(thisPair.Value))[1]);
			Assert.Equal("value24", ((TamlArray)(thisPair.Value))[2]);

			thisPair = result.KeyValuePairs.Skip(2).First();
			Assert.Equal("value3", thisPair.Key);
			Assert.Equal("value32", ((TamlArray)(thisPair.Value))[0]);
			Assert.Equal("value33", ((TamlArray)(thisPair.Value))[1]);
			Assert.Equal("value34", ((TamlArray)(thisPair.Value))[2]);

		}

	}
}
