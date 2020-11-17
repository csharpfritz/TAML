using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.Extensions.Configuration;
using TAML;

namespace Configuraiton.Taml.NET
{
	internal class TamlConfigurationFileParser
	{
		private TamlConfigurationFileParser() { }

		private readonly IDictionary<string, string> _data = new SortedDictionary<string, string>(StringComparer.OrdinalIgnoreCase);
		private readonly Stack<string> _context = new Stack<string>();
		private string _currentPath;

		public static IDictionary<string, string> Parse(Stream input)
			=> new TamlConfigurationFileParser().ParseStream(input);

		private IDictionary<string, string> ParseStream(Stream input)
		{
			_data.Clear();

			using (var reader = new StreamReader(input))
			{
				var document = Parser.Parse(reader);

				foreach (var pair in document.KeyValuePairs)
				{
					EnterContext(pair.Key);
					VisitValue(pair.Value);
					ExitContext();
				}
			}

			return _data;
		}

		private void VisitElement(TamlDocument document)
		{
			var isEmpty = true;

			foreach (var pair in document.KeyValuePairs)
			{
				isEmpty = false;
				EnterContext(pair.Key);
				VisitValue(pair.Value);
				ExitContext();
			}

			if (isEmpty && _currentPath != null)
			{
				_data[_currentPath] = null;
			}
		}

		private bool IsArray(TamlArray array)
		{
			return array.All(x => x is TamlArray) ||
				array.All(x =>
				{
					if (x is TamlKeyValuePair pair)
					{
						return !pair.HasValue;
					}
					if (x is TamlValue)
					{
						return true;
					}
					
					return false;
				});
		}

		private void VisitValue(TamlValue value)
		{
			if (value is TamlArray array)
			{
				if (IsArray(array))
				{
					int index = 0;
					foreach (TamlValue arrayElement in array)
					{
						EnterContext(index.ToString());
						VisitValue(arrayElement);
						ExitContext();
						index++;
					}
				}
				else
				{
					foreach (TamlValue arrayElement in array)
					{
						VisitValue(arrayElement);
					}
				}
			}
			else if (value is TamlKeyValuePair pair)
			{
				if (pair.HasValue)
				{
					EnterContext(pair.Key);
					VisitValue(pair.Value);
					ExitContext();
				}
				else
				{
					_data[_currentPath] = pair.Key;
				}
			}
			else
			{
				string key = _currentPath;
				if (_data.ContainsKey(key))
				{
					throw new FormatException($"Key`{key}` is duplicated.");
				}
				_data[key] = value.ToString();
			}
		}

		private void EnterContext(string context)
		{
			_context.Push(context);
			_currentPath = ConfigurationPath.Combine(_context.Reverse());
		}

		private void ExitContext()
		{
			_context.Pop();
			_currentPath = ConfigurationPath.Combine(_context.Reverse());
		}
	}
}
