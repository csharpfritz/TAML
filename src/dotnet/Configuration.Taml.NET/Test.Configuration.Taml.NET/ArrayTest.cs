using System.Linq;
using Configuraiton.Taml.NET;
using Microsoft.Extensions.Configuration;
using Xunit;

namespace Test.Configuration.Taml.NET
{
	public class ArrayTest
	{
		[Fact]
		public void ArraysAreConvertedToKeyValuePairs()
		{
			var Taml = 
@"ip
	1.2.3.4
	7.8.9.10
	11.12.13.14";

			var TamlConfigSource = new TamlConfigurationProvider(new TamlConfigurationSource());
			TamlConfigSource.Load(TestStreamHelpers.StringToStream(Taml));

			Assert.Equal("1.2.3.4", TamlConfigSource.Get("ip:0"));
			Assert.Equal("7.8.9.10", TamlConfigSource.Get("ip:1"));
			Assert.Equal("11.12.13.14", TamlConfigSource.Get("ip:2"));
		}

		[Fact]
		public void ArrayOfObjects()
		{
			var Taml =
@"ip
	First
		address	1.2.3.4
		hidden	False
	Second
		address	5.6.7.8
		hidden	True";

			var TamlConfigSource = new TamlConfigurationProvider(new TamlConfigurationSource());
			TamlConfigSource.Load(TestStreamHelpers.StringToStream(Taml));

			Assert.Equal("1.2.3.4", TamlConfigSource.Get("ip:First:address"));
			Assert.Equal("False", TamlConfigSource.Get("ip:First:hidden"));
			Assert.Equal("5.6.7.8", TamlConfigSource.Get("ip:Second:address"));
			Assert.Equal("True", TamlConfigSource.Get("ip:Second:hidden"));
		}

		[Fact]
		public void NestedArrays()
		{
			var Taml = 
@"ip
	First
		1.2.3.4
		5.6.7.8
	Second
		9.10.11.12
		13.14.15.16";

			var TamlConfigSource = new TamlConfigurationProvider(new TamlConfigurationSource());
			TamlConfigSource.Load(TestStreamHelpers.StringToStream(Taml));

			Assert.Equal("1.2.3.4", TamlConfigSource.Get("ip:First:0"));
			Assert.Equal("5.6.7.8", TamlConfigSource.Get("ip:First:1"));
			Assert.Equal("9.10.11.12", TamlConfigSource.Get("ip:Second:0"));
			Assert.Equal("13.14.15.16", TamlConfigSource.Get("ip:Second:1"));
		}

		[Fact]
		public void ImplicitArrayItemReplacement()
		{
			var Taml1 = 
@"ip
	1.2.3.4
	7.8.9.10
	11.12.13.14";

			var Taml2 = 
@"ip
	15.16.17.18";

			var TamlConfigSource1 = new TamlConfigurationSource { FileProvider = TestStreamHelpers.StringToFileProvider(Taml1) };
			var TamlConfigSource2 = new TamlConfigurationSource { FileProvider = TestStreamHelpers.StringToFileProvider(Taml2) };

			var configurationBuilder = new ConfigurationBuilder();
			configurationBuilder.Add(TamlConfigSource1);
			configurationBuilder.Add(TamlConfigSource2);
			var config = configurationBuilder.Build();

			Assert.Equal(3, config.GetSection("ip").GetChildren().Count());
			Assert.Equal("15.16.17.18", config["ip:0"]);
			Assert.Equal("7.8.9.10", config["ip:1"]);
			Assert.Equal("11.12.13.14", config["ip:2"]);
		}

		[Fact]
		public void ExplicitArrayReplacement()
		{
			var Taml1 = 
@"ip
	1.2.3.4
	7.8.9.10
	11.12.13.14";

			var Taml2 = 
@"ip
	1	15.16.17.18";

			var TamlConfigSource1 = new TamlConfigurationSource { FileProvider = TestStreamHelpers.StringToFileProvider(Taml1) };
			var TamlConfigSource2 = new TamlConfigurationSource { FileProvider = TestStreamHelpers.StringToFileProvider(Taml2) };

			var configurationBuilder = new ConfigurationBuilder();
			configurationBuilder.Add(TamlConfigSource1);
			configurationBuilder.Add(TamlConfigSource2);
			var config = configurationBuilder.Build();

			Assert.Equal(3, config.GetSection("ip").GetChildren().Count());
			Assert.Equal("1.2.3.4", config["ip:0"]);
			Assert.Equal("15.16.17.18", config["ip:1"]);
			Assert.Equal("11.12.13.14", config["ip:2"]);
		}

		[Fact]
		public void ArrayMerge()
		{
			var Taml1 = 
@"ip
	1.2.3.4
	7.8.9.10
	11.12.13.14";

			var Taml2 = 
@"ip
	3	15.16.17.18";

			var TamlConfigSource1 = new TamlConfigurationSource { FileProvider = TestStreamHelpers.StringToFileProvider(Taml1) };
			var TamlConfigSource2 = new TamlConfigurationSource { FileProvider = TestStreamHelpers.StringToFileProvider(Taml2) };

			var configurationBuilder = new ConfigurationBuilder();
			configurationBuilder.Add(TamlConfigSource1);
			configurationBuilder.Add(TamlConfigSource2);
			var config = configurationBuilder.Build();

			Assert.Equal(4, config.GetSection("ip").GetChildren().Count());
			Assert.Equal("1.2.3.4", config["ip:0"]);
			Assert.Equal("7.8.9.10", config["ip:1"]);
			Assert.Equal("11.12.13.14", config["ip:2"]);
			Assert.Equal("15.16.17.18", config["ip:3"]);
		}

		[Fact]
		public void ArraysAreKeptInFileOrder()
		{
			var Taml = 
@"setting
	b
	a
	2";

			var TamlConfigSource = new TamlConfigurationSource { FileProvider = TestStreamHelpers.StringToFileProvider(Taml) };

			var configurationBuilder = new ConfigurationBuilder();
			configurationBuilder.Add(TamlConfigSource);
			var config = configurationBuilder.Build();

			var configurationSection = config.GetSection("setting");
			var indexConfigurationSections = configurationSection.GetChildren().ToArray();

			Assert.Equal(3, indexConfigurationSections.Count());
			Assert.Equal("b", indexConfigurationSections[0].Value);
			Assert.Equal("a", indexConfigurationSections[1].Value);
			Assert.Equal("2", indexConfigurationSections[2].Value);
		}

		[Fact]
		public void PropertiesAreSortedByNumberOnlyFirst()
		{
			var Taml = 
@"setting
	hello	a
	bob	b
	42	c
	4	d
	10	e
	1text	f";

			var TamlConfigSource = new TamlConfigurationSource { FileProvider = TestStreamHelpers.StringToFileProvider(Taml) };

			var configurationBuilder = new ConfigurationBuilder();
			configurationBuilder.Add(TamlConfigSource);
			var config = configurationBuilder.Build();

			var configurationSection = config.GetSection("setting");
			var indexConfigurationSections = configurationSection.GetChildren().ToArray();

			Assert.Equal(6, indexConfigurationSections.Count());
			Assert.Equal("4", indexConfigurationSections[0].Key);
			Assert.Equal("10", indexConfigurationSections[1].Key);
			Assert.Equal("42", indexConfigurationSections[2].Key);
			Assert.Equal("1text", indexConfigurationSections[3].Key);
			Assert.Equal("bob", indexConfigurationSections[4].Key);
			Assert.Equal("hello", indexConfigurationSections[5].Key);
		}
	}
}
