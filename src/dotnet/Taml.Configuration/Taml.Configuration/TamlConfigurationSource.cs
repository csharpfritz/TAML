using Microsoft.Extensions.Configuration;

namespace Taml.Configuration
{
	/// <summary>
	/// Represents a Taml file as an <see cref="IConfigurationSource"/>.
	/// </summary>
	public class TamlConfigurationSource : FileConfigurationSource
	{
		/// <summary>
		/// Builds the <see cref="TamlConfigurationProvider"/> for this source.
		/// </summary>
		/// <param name="builder">The <see cref="IConfigurationBuilder"/>.</param>
		/// <returns>A <see cref="TamlConfigurationProvider"/></returns>
		public override IConfigurationProvider Build(IConfigurationBuilder builder)
		{
			EnsureDefaults(builder);
			return new TamlConfigurationProvider(this);
		}
	}
}
