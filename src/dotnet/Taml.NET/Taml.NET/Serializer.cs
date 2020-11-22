using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace TAML
{


  public class Serializer
  {

    /// <summary>
    /// Convert the submitted object to a properly formatted string of TAML
    /// </summary>
    /// <param name="value">Object to convert to a string</param>
    /// <param name="options">Additional configuration options for the parser</param>
    /// <returns>TAML formatted string</returns>
    public static string Serialize(object value, SerializerOptions options = null)
    {
      return "";
    }

    /// <summary>
    /// Read TAML syntax from the input string and convert to a .NET object
    /// </summary>
    /// <typeparam name="T">Type of the object to create</typeparam>
    /// <param name="value">TAML foramtted string</param>
    /// <param name="options">Additional configuration options for the parser</param>
    /// <returns>.NET object that represents the TAML submitted</returns>
    public static T Deserialize<T>(string value, SerializerOptions options = null) where T : new()
    {

      var outValue = new T();
      var outType = typeof(T);
      var properties = outType.GetProperties();

      var doc = Parser.Parse(new StringReader(value));

      foreach (var kvp in doc.KeyValuePairs)
      {

				Console.WriteLine($"Looking for property '{kvp.Key}'");
				var thisProp = properties.FirstOrDefault(p => p.Name == kvp.Key);
				Console.WriteLine($"Property identified: '{thisProp}'");

        if (!(thisProp is null))
        {
					thisProp.SetValue(outValue, kvp.Value.ToString());
        }
      }

      return outValue;

    }

    /// <summary>
    /// Read TAML syntax from the input string and convert to a .NET object
    /// </summary>
    /// <param name="value">TAML foramtted string</param>
    /// <param name="destinationType">The type of the .NET object to be returned</param>
    /// <param name="options">Additional configuration options for the parser</param>
    /// <returns>.NET object that represents the TAML submitted</returns>
    public static object Deserialize(string value, Type destinationType, SerializerOptions options = null)
    {
      return new object();
    }

  }

  /// <summary>
  /// A collection of serializer configuration options
  /// </summary>
  public class SerializerOptions
  {

    /// <summary>
    /// The default options to be used by the serializer
    /// </summary>
    public static SerializerOptions DefaultOptions = new SerializerOptions() { };

  }

}
