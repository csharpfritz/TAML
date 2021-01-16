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
			Console.WriteLine($"Read file: {filename}");
			var tamlDoc = Parser.Parse(new StreamReader(File.OpenRead(filename)));

			var yaml = YamlWriter.Write(tamlDoc);

			Console.WriteLine(yaml);
		}

		/// <Summary>
		/// Find the first file with a `.taml` extension from the command line arguments.
		/// If no such file exists then default to `sample1.taml`
		/// </Summary>
		private static string GetFileName(string[] args)
		{
			foreach(var arg in args){

				if (arg.EndsWith("taml") && File.Exists(arg))
				{
					return arg;
				}
			}
			return "sample1.taml";
		}
	}
}
