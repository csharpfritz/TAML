using System.IO;
using Microsoft.Extensions.Configuration;

namespace Configuraiton.Taml.NET
{
	/// <summary>
	/// Loads configuration key/values from a Taml stream into a provider.
	/// </summary>
	public class TamlStreamConfigurationProvider : StreamConfigurationProvider
	{
		/// <summary>
		/// Constructor.
		/// </summary>
		/// <param name="source">The <see cref="TamlStreamConfigurationSource"/>.</param>
		public TamlStreamConfigurationProvider(TamlStreamConfigurationSource source) : base(source) { }

		/// <summary>
		/// Loads Taml configuration key/values from a stream into a provider.
		/// </summary>
		/// <param name="stream">The Taml <see cref="Stream"/> to load configuration data from.</param>
		public override void Load(Stream stream)
		{
			Data = TamlConfigurationFileParser.Parse(stream);
		}
	}
}
