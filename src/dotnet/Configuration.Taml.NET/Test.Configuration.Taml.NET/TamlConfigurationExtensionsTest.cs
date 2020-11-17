using System;
using System.IO;
using Configuraiton.Taml.NET;
using Microsoft.Extensions.Configuration;
using Xunit;

namespace Test.Configuration.Taml.NET
{
	public class TamlConfigurationExtensionsTest
	{
		[Theory]
		[InlineData(null)]
		[InlineData("")]
		public void AddTamlFile_ThrowsIfFilePathIsNullOrEmpty(string path)
		{
			// Arrange
			var configurationBuilder = new ConfigurationBuilder();

			// Act and Assert
			var ex = Assert.Throws<ArgumentException>(() => TamlConfigurationExtensions.AddTamlFile(configurationBuilder, path));
			Assert.Equal("path", ex.ParamName);
			Assert.StartsWith("File path must be a non-empty string.", ex.Message);
		}

		[Fact]
		public void AddTamlFile_ThrowsIfFileDoesNotExistAtPath()
		{
			// Arrange
			var path = "file-does-not-exist.Taml";

			// Act and Assert
			var ex = Assert.Throws<FileNotFoundException>(() => new ConfigurationBuilder().AddTamlFile(path).Build());
			Assert.StartsWith($"The configuration file '{path}' was not found and is not optional. The physical path is '", ex.Message);
		}
	}
}
