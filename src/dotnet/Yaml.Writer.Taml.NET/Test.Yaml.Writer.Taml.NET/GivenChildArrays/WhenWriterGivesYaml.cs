using System;
using System.Collections.Generic;
using System.Text;
using TAML;
using TAML.Writer.Yaml;
using Test.Taml.NET;
using Xunit;

namespace Test.Yaml.Writer.Taml.NET.GivenChildArrays
{
	public class WhenWriterGivesYaml : BaseFixture
	{
		protected override string SampleFilename => "GivenChildArrays/childarrays.taml";

		[Fact]
		public void ShouldFindThreeElements()
		{
			var tamlDocument = Parser.Parse(base.Sample);
			var yamlString = YamlWriter.Write(tamlDocument);

			var newLines = yamlString.Split(Environment.NewLine);

			Assert.Equal(13, newLines.Length);
		}
	}
}
