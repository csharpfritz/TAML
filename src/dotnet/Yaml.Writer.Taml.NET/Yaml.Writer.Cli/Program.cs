using System;
using System.IO;
using TAML;
using TAML.Writer.Yaml;

namespace Yaml.Writer.Cli
{
	internal class Program
	{
		private static void Main(string[] args)
		{
			var filename = GetFileName(args);
			var tamlDoc = Parser.Parse(new StreamReader(File.OpenRead(filename)));

			var yaml = YamlWriter.Write(tamlDoc);

			Console.WriteLine(yaml);
		}

		private static string GetFileName(string[] args)
		{
			if (args.Length >= 1)
			{
				if (File.Exists(args[0]))
				{
					return args[0];
				}
			}
			return "sample1.taml";
		}
	}
}
