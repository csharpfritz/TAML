using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TAML;
using Xunit;

namespace Test.Taml.NET.Spec_1_1.GivenParserDirectives
{

	public class WhenReadingSingleTermParserDirectives : BaseFixture
	{

		protected override string SampleFilename => "Spec_1-1/GivenParserDirectives/singleTerm.taml";


		[Fact]
		public void ThenShouldIdentifyDirectiveWithNoSetting()
		{

			// act
			var result = Parser.Parse(Sample);

			// assert
			Assert.Single(result.ProcessorDirectives);

			var directive = result.ProcessorDirectives.First();
			Assert.Equal("TAML.Strict", directive.Key);
			Assert.Equal("", directive.Value);

		}

	}

}
