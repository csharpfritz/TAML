using System;
using System.IO;
using System.Linq;
using Xunit;

namespace TAML.Test.Taml.NET.GivenOnlyKeyValuePairs
{
  public class WhenSimplestMarkup : BaseFixture
  {

    [Fact]
    public void ShouldFindTwoKeyValuePairs()
    {

      // arrange
      var sr = new StreamReader(Simple);

      // act
      var result = Parser.Parse(sr);

      // assert
      Assert.Equal(2, result.KeyValuePairs.Count());

    }

  }
}
