using TAML;
using Xunit;

namespace Test.Taml.NET.Spec_1_1.GivenComments
{

  public class WhenReadingComments : BaseFixture
  {

    protected override string SampleFilename => "Spec_1-1/GivenComments/simple.taml";

    [Fact]
    public void ThenShouldIgnoreCommentLines()
    {

			// act
			var result = Parser.Parse(Sample);

			// assert
			Assert.Equal(2, result.KeyValuePairs.Count);


    }

  }

}
