using System;
using System.Collections.Generic;
using System.Text;
using TAML;
using TAML.Writer.Yaml;
using Test.Taml.NET;
using Xunit;

namespace Test.Yaml.Writer.Taml.NET.GivenComplexChildDocument
{
	public class WhenParsingSampleOne : BaseFixture
	{
		protected override string SampleFilename => "GivenComplexChildDocument/sample1.taml";

		[Fact]
		public void ShouldHaveOneRootKey()
		{
			var result = YamlWriter.Write(Parser.Parse(base.Sample));

			var rootLineCount = 0;

			foreach (var line in result.Split(Environment.NewLine))
			{
				if (!line.StartsWith(" ") && line.Length > 2) rootLineCount++;
			}

			Assert.Equal(1, rootLineCount);
		}

		[Fact]
		public void ShouldHaveCorrectNesting()
		{
			var expected =
@"root:
  - key1: value1
  - key2: value2
  - key3:
    - item1
    - item2
    - item3
    - item4:
      - key41: value41
      - key42: value42
      - key43: value43
      - key44: value44
";
			var result = YamlWriter.Write(Parser.Parse(base.Sample));

			Assert.Equal(expected, result);
		}
	}
}
