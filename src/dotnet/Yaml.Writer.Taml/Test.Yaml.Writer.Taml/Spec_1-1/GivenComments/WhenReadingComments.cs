using TAML;
using TAML.Writer.Yaml;
using Test.Taml;
using Xunit;

namespace Test.Yaml.Writer.Taml.NET.Spec_1_1.GivenComments
{
	public class WhenReadingComments : BaseFixture
	{
		protected override string SampleFilename => "Spec_1-1/GivenComments/simple.taml";

		[Fact]
		public void ThenShouldIgnoreCommentLines()
		{
			// arrange
			var expected = @"key1: value1
key2: value2
";

			// act
			var result = YamlWriter.Write(Parser.Parse(Sample));

			// assert
			Assert.Equal(expected, result);
		}
	}
}
