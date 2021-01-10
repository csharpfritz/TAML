using System;
using System.IO;
using Microsoft.Extensions.Configuration;

namespace Taml.Configuration
{
	/// <summary>
	/// A Taml file based <see cref="FileConfigurationProvider"/>.
	/// </summary>
	public class TamlConfigurationProvider : FileConfigurationProvider
	{
		/// <summary>
		/// Initializes a new instance with the specified source.
		/// </summary>
		/// <param name="source">The source settings.</param>
		public TamlConfigurationProvider(TamlConfigurationSource source) : base(source) { }

		/// <summary>
		/// Loads the Taml data from a stream.
		/// </summary>
		/// <param name="stream">The stream to read.</param>
		public override void Load(Stream stream)
		{
			try
			{
				Data = TamlConfigurationFileParser.Parse(stream);
			}
			catch (Exception e)
			{
				throw new FormatException("TamlParseError", e);
			}
		}
	}
}
