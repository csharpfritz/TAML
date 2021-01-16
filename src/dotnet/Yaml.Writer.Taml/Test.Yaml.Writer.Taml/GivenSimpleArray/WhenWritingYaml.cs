using System;
using Xunit;
using Test.Taml;
using TAML;
using TAML.Writer.Yaml;

namespace Test.Yaml.Writer.Taml.NET.GivenSimpleArray
{
	public class WhenWritingYaml : BaseFixture
	{
		protected override string SampleFilename => "GivenSimpleArray/simple.taml";

		[Fact]
		public void ThenShouldFindArray()
		{
			var tamlDocument = Parser.Parse(Sample);

			var yamlString = YamlWriter.Write(tamlDocument);

			var newLines = yamlString.Split(Environment.NewLine);

			Assert.Equal(5, newLines.Length);
		}
	}
}
