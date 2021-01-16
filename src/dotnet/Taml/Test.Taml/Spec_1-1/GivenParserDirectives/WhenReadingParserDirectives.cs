using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TAML;
using Xunit;

namespace Test.Taml.Spec_1_1.GivenParserDirectives
{

	public class WhenReadingParserDirectives : BaseFixture
	{

		protected override string SampleFilename => "Spec_1-1/GivenParserDirectives/simple.taml";


		[Fact]
		public void ThenResultShouldNotConvertToAValue()
		{

			// act
			var result = Parser.Parse(Sample);

			// assert
			Assert.Equal(2, result.KeyValuePairs.Count);

		}

	}

}
