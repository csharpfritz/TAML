using System.IO;
using TAML;
using Xunit;

namespace Test.Taml.GivenOnlyKeyValuePairs
{

	public class WhenExtraTabs
	{

		[Fact]
		public void ShouldIgnoreTrailingTabs()
		{

			// arrange
			var theDoc = @"key	value						";
			var mem = new MemoryStream(System.Text.Encoding.ASCII.GetBytes(theDoc.ToCharArray(), 0, theDoc.Length));
			var sr = new StreamReader(mem);

			// act
			var result = Parser.Parse(sr);

			// assert
			Assert.Equal("value", result.KeyValuePairs.FindByKey("key").ToString());

		}

		[Fact]
		public void ShouldIgnoreMultipleInteriorTabs()
		{

			// arrange
			var theDoc = @"key										value";
			var mem = new MemoryStream(System.Text.Encoding.ASCII.GetBytes(theDoc.ToCharArray(), 0, theDoc.Length));
			var sr = new StreamReader(mem);

			// act
			var result = Parser.Parse(sr);

			// assert
			Assert.NotNull(result.KeyValuePairs);
			Assert.NotEmpty(result.KeyValuePairs);
			Assert.Equal("value", result.KeyValuePairs.FindByKey("key").ToString());

		}

	}

}
