using Microsoft.Extensions.Configuration;

namespace Configuraiton.Taml.NET
{
	/// <summary>
	/// Represents a Taml file as an <see cref="IConfigurationSource"/>.
	/// </summary>
	public class TamlStreamConfigurationSource : StreamConfigurationSource
	{
		/// <summary>
		/// Builds the <see cref="TamlStreamConfigurationProvider"/> for this source.
		/// </summary>
		/// <param name="builder">The <see cref="IConfigurationBuilder"/>.</param>
		/// <returns>An <see cref="TamlStreamConfigurationProvider"/></returns>
		public override IConfigurationProvider Build(IConfigurationBuilder builder)
			=> new TamlStreamConfigurationProvider(this);
	}
}
