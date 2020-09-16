using System;
using System.IO;
using System.Linq;

using Xunit;

namespace TAML.Test.Taml.NET.GivenSimplestTamlDoc
{
	public class WhenParsingTheDoc
	{

		private readonly FileStream _Simple;

		public WhenParsingTheDoc()
		{

			_Simple = File.OpenRead("GivenSimplestTamlDoc/simple.taml");

		}


		[Fact]
		public void ShouldFindTwoKeyValuePairs()
		{

			// arrange
			var sr = new StreamReader(_Simple);

			// act
			var result = Parser.Parse(sr);

			// assert
			Assert.Equal(2, result.KeyValuePairs.Count());

		}
	}
}
