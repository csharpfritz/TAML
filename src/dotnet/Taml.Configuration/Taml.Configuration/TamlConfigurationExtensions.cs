using System;
using System.IO;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.FileProviders;

namespace Taml.Configuration
{
	/// <summary>
	/// Extension methods for adding <see cref="TamlConfigurationProvider"/>.
	/// </summary>
	public static class TamlConfigurationExtensions
	{
		/// <summary>
		/// Adds the Taml configuration provider at <paramref name="path"/> to <paramref name="builder"/>.
		/// </summary>
		/// <param name="builder">The <see cref="IConfigurationBuilder"/> to add to.</param>
		/// <param name="path">Path relative to the base path stored in
		/// <see cref="IConfigurationBuilder.Properties"/> of <paramref name="builder"/>.</param>
		/// <returns>The <see cref="IConfigurationBuilder"/>.</returns>
		public static IConfigurationBuilder AddTamlFile(this IConfigurationBuilder builder, string path)
		{
			return AddTamlFile(builder, provider: null, path: path, optional: false, reloadOnChange: false);
		}

		/// <summary>
		/// Adds the Taml configuration provider at <paramref name="path"/> to <paramref name="builder"/>.
		/// </summary>
		/// <param name="builder">The <see cref="IConfigurationBuilder"/> to add to.</param>
		/// <param name="path">Path relative to the base path stored in
		/// <see cref="IConfigurationBuilder.Properties"/> of <paramref name="builder"/>.</param>
		/// <param name="optional">Whether the file is optional.</param>
		/// <returns>The <see cref="IConfigurationBuilder"/>.</returns>
		public static IConfigurationBuilder AddTamlFile(this IConfigurationBuilder builder, string path, bool optional)
		{
			return AddTamlFile(builder, provider: null, path: path, optional: optional, reloadOnChange: false);
		}

		/// <summary>
		/// Adds the Taml configuration provider at <paramref name="path"/> to <paramref name="builder"/>.
		/// </summary>
		/// <param name="builder">The <see cref="IConfigurationBuilder"/> to add to.</param>
		/// <param name="path">Path relative to the base path stored in
		/// <see cref="IConfigurationBuilder.Properties"/> of <paramref name="builder"/>.</param>
		/// <param name="optional">Whether the file is optional.</param>
		/// <param name="reloadOnChange">Whether the configuration should be reloaded if the file changes.</param>
		/// <returns>The <see cref="IConfigurationBuilder"/>.</returns>
		public static IConfigurationBuilder AddTamlFile(this IConfigurationBuilder builder, string path, bool optional, bool reloadOnChange)
		{
			return AddTamlFile(builder, provider: null, path: path, optional: optional, reloadOnChange: reloadOnChange);
		}

		/// <summary>
		/// Adds a Taml configuration source to <paramref name="builder"/>.
		/// </summary>
		/// <param name="builder">The <see cref="IConfigurationBuilder"/> to add to.</param>
		/// <param name="provider">The <see cref="IFileProvider"/> to use to access the file.</param>
		/// <param name="path">Path relative to the base path stored in
		/// <see cref="IConfigurationBuilder.Properties"/> of <paramref name="builder"/>.</param>
		/// <param name="optional">Whether the file is optional.</param>
		/// <param name="reloadOnChange">Whether the configuration should be reloaded if the file changes.</param>
		/// <returns>The <see cref="IConfigurationBuilder"/>.</returns>
		public static IConfigurationBuilder AddTamlFile(this IConfigurationBuilder builder, IFileProvider provider, string path, bool optional, bool reloadOnChange)
		{
			if (builder == null)
			{
				throw new ArgumentNullException(nameof(builder));
			}
			if (string.IsNullOrEmpty(path))
			{
				throw new ArgumentException("File path must be a non-empty string.", nameof(path));
			}

			return builder.AddTamlFile(s =>
			{
				s.FileProvider = provider;
				s.Path = path;
				s.Optional = optional;
				s.ReloadOnChange = reloadOnChange;
				s.ResolveFileProvider();
			});
		}

		/// <summary>
		/// Adds a Taml configuration source to <paramref name="builder"/>.
		/// </summary>
		/// <param name="builder">The <see cref="IConfigurationBuilder"/> to add to.</param>
		/// <param name="configureSource">Configures the source.</param>
		/// <returns>The <see cref="IConfigurationBuilder"/>.</returns>
		public static IConfigurationBuilder AddTamlFile(this IConfigurationBuilder builder, Action<TamlConfigurationSource> configureSource)
			=> builder.Add(configureSource);

		/// <summary>
		/// Adds a Taml configuration source to <paramref name="builder"/>.
		/// </summary>
		/// <param name="builder">The <see cref="IConfigurationBuilder"/> to add to.</param>
		/// <param name="stream">The <see cref="Stream"/> to read the Taml configuration data from.</param>
		/// <returns>The <see cref="IConfigurationBuilder"/>.</returns>
		public static IConfigurationBuilder AddTamlStream(this IConfigurationBuilder builder, Stream stream)
		{
			if (builder == null)
			{
				throw new ArgumentNullException(nameof(builder));
			}

			return builder.Add<TamlStreamConfigurationSource>(s => s.Stream = stream);
		}
	}
}
