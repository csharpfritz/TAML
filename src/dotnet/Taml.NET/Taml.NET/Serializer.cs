using System;
using System.Collections.Generic;
using System.Text;

namespace Taml.NET
{


	public class Serializer
	{

		/// <summary>
		/// Convert the submitted object to a properly formatted string of TAML
		/// </summary>
		/// <param name="value">Object to convert to a string</param>
		/// <param name="options">Additional configuration options for the parser</param>
		/// <returns>TAML formatted string</returns>
		public static string Serialize(object value, SerializerOptions options = null) { return ""; }

		/// <summary>
		/// Read TAML syntax from the input string and convert to a .NET object
		/// </summary>
		/// <typeparam name="T">Type of the object to create</typeparam>
		/// <param name="value">TAML foramtted string</param>
		/// <param name="options">Additional configuration options for the parser</param>
		/// <returns>.NET object that represents the TAML submitted</returns>
		public static T Deserialize<T>(string value, SerializerOptions options = null) where T : new()
		{
			return default;
		}

		/// <summary>
		/// Read TAML syntax from the input string and convert to a .NET object
		/// </summary>
		/// <param name="value">TAML foramtted string</param>
		/// <param name="destinationType">The type of the .NET object to be returned</param>
		/// <param name="options">Additional configuration options for the parser</param>
		/// <returns>.NET object that represents the TAML submitted</returns>
		public static object Deserialize(string value, Type destinationType, SerializerOptions options = null) where T : new()
		{
			return new object();
		}

	}

	/// <summary>
	/// A collection of serializer configuration options
	/// </summary>
	public class SerializerOptions {

		/// <summary>
		/// The default options to be used by the serializer
		/// </summary>
		public static SerializerOptions DefaultOptions = new SerializerOptions() { };
	
	}

}
