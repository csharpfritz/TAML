using System;
using System.Globalization;
using System.IO;
using Taml.Configuration;
using Microsoft.Extensions.Configuration;
using Xunit;

namespace Test.Taml.Configuration
{
	public class TamlConfigurationTest
	{
		private TamlConfigurationProvider LoadProvider(string Taml)
		{
			var p = new TamlConfigurationProvider(new TamlConfigurationSource { Optional = true });
			p.Load(TestStreamHelpers.StringToStream(Taml));
			return p;
		}

		[Fact]
		public void CanLoadValidTamlFromStreamProvider()
		{
			var Taml = 
@"firstname	test
test.last.name	last.name
residential.address
	street.name	Something street
	zipcode	12345";

			var config = new ConfigurationBuilder().AddTamlStream(TestStreamHelpers.StringToStream(Taml)).Build();
			Assert.Equal("test", config["firstname"]);
			Assert.Equal("last.name", config["test.last.name"]);
			Assert.Equal("Something street", config["residential.address:STREET.name"]);
			Assert.Equal("12345", config["residential.address:zipcode"]);
		}

		[Fact]
		public void ReloadThrowsFromStreamProvider()
		{
			var Taml = 
@"firstname	test";
			var config = new ConfigurationBuilder().AddTamlStream(TestStreamHelpers.StringToStream(Taml)).Build();
			Assert.Throws<InvalidOperationException>(() => config.Reload());
		}


		[Fact]
		public void LoadKeyValuePairsFromValidTaml()
		{
			var Taml = 
@"firstname	test
test.last.name	last.name
residential.address
	street.name	Something street
	zipcode	12345";

			var TamlConfigSrc = LoadProvider(Taml);

			Assert.Equal("test", TamlConfigSrc.Get("firstname"));
			Assert.Equal("last.name", TamlConfigSrc.Get("test.last.name"));
			Assert.Equal("Something street", TamlConfigSrc.Get("residential.address:STREET.name"));
			Assert.Equal("12345", TamlConfigSrc.Get("residential.address:zipcode"));
		}

		[Fact]
		public void LoadWithCulture()
		{
			var previousCulture = CultureInfo.CurrentCulture;

			try
			{
				CultureInfo.CurrentCulture = new CultureInfo("fr-FR");

				var Taml = 
@"number	3.14";

				var TamlConfigSrc = LoadProvider(Taml);
				Assert.Equal("3.14", TamlConfigSrc.Get("number"));
			}
			finally
			{
				CultureInfo.CurrentCulture = previousCulture;
			}
		}

		[Fact]
		public void ThrowExceptionWhenPassingNullAsFilePath()
		{
			var expectedMsg = new ArgumentException("File path must be a non-empty string.", "path").Message;

			var exception = Assert.Throws<ArgumentException>(() => new ConfigurationBuilder().AddTamlFile(path: null));

			Assert.Equal(expectedMsg, exception.Message);
		}

		[Fact]
		public void ThrowExceptionWhenPassingEmptyStringAsFilePath()
		{
			var expectedMsg = new ArgumentException("File path must be a non-empty string.", "path").Message;

			var exception = Assert.Throws<ArgumentException>(() => new ConfigurationBuilder().AddTamlFile(string.Empty));

			Assert.Equal(expectedMsg, exception.Message);
		}

		[Fact]
		public void TamlConfiguration_Throws_On_Missing_Configuration_File()
		{
			var config = new ConfigurationBuilder().AddTamlFile("NotExistingConfig.Taml", optional: false);
			var exception = Assert.Throws<FileNotFoundException>(() => config.Build());

			// Assert
			Assert.StartsWith($"The configuration file 'NotExistingConfig.Taml' was not found and is not optional. The physical path is '", exception.Message);
		}

		[Fact]
		public void TamlConfiguration_Does_Not_Throw_On_Optional_Configuration()
		{
			var config = new ConfigurationBuilder().AddTamlFile("NotExistingConfig.Taml", optional: true).Build();
		}

		[Fact]
		public void ThrowFormatExceptionWhenFileIsEmpty()
		{
			var exception = Assert.Throws<FormatException>(() => LoadProvider(@"{}"));
			Assert.Contains("TamlParseError", exception.Message);
		}
	}
}
