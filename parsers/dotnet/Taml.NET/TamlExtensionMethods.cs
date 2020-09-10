using System.Collections.Generic;
using System.Linq;

namespace TAML
{
	public static class TamlExtensionMethods 
	{

		public static void Add(this IList<TamlKeyValuePair> list, string key, TamlValue value)
		{

			list.Add(new TamlKeyValuePair(key, value));

		}

		public static TamlValue FindByKey(this IList<TamlKeyValuePair> list, string key)
		{

			return list.FirstOrDefault(p => p.Key == key).Value;

		}

	}

}
