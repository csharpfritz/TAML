using System.IO;
using System.Linq;
using TAML;
using Xunit;

namespace Test.Taml.NET {

  public class WhenLoadingFile  : BaseFixture
  {

	  [Fact]
	  public void ThenShouldFindAnArray()
	  {

		var result = Parser.Parse(base.SimpleFile);

		Assert.Equal(1, result.KeyValuePairs.Count);
		Assert.IsType<TamlArray>(result.KeyValuePairs.First().Value);

	  }

	  [Fact]
	  public void ThenArrayShouldContainThreeElements()
	  {

		  var result = Parser.Parse(base.SimpleFile);

		  var entry = result.KeyValuePairs.First();
		  Assert.Equal("key", entry.Key);

		  var array = entry.Value as TamlArray;
		  Assert.Equal(3, array.Count());

	  }

	  [Fact]
	  public void ThenArrayShouldIgnoreTrailingSpace()
	  {

		  var result = Parser.Parse(base.SimpleFile);

		  var entry = result.KeyValuePairs.First();
		  Assert.Equal("key", entry.Key);

		  var array = entry.Value as TamlArray;
		  Assert.Equal("value3", array[2]);

	  }

  }

  public abstract class BaseFixture {

	  public BaseFixture()
	  {
		  SimpleFile = new StreamReader("GivenSimpleArray/simple.taml");
	  }

	  public StreamReader SimpleFile { get; }

  }

}
