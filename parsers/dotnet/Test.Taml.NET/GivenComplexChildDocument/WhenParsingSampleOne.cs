using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TAML;
using Xunit;

namespace Test.Taml.NET.GivenComplexChildDocument
{

	public class WhenParsingSampleOne : BaseFixture
	{
		protected override string SampleFilename => "GivenComplexChildDocument/sample1.taml";

		[Fact]
		public void ShouldHaveOneRootKey()
		{

			var doc = Parser.Parse(base.Sample);

			Assert.Equal(1, doc.KeyValuePairs.Count);
			Assert.Equal("root", doc.KeyValuePairs.First().Key);

		}

		[Fact]
		public void ShouldHaveThreeElementsInTheTopArray()
		{

			var doc = Parser.Parse(base.Sample);

			Assert.Equal(3, ((TamlArray)doc.KeyValuePairs.First().Value).Count());

		}

	}

}
