using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace TAML
{
  public class TamlArray : TamlValue, IEnumerable<string>
  {

    private readonly List<string> _Values = new List<string>();

    public string this[int pos]
    {
      get { return _Values.Skip(pos).First(); }
    }

    public IEnumerator<string> GetEnumerator()
    {
      return ((IEnumerable<string>)_Values).GetEnumerator();
    }

    internal void AppendValue(string newValue)
    {
      _Values.Add(newValue);
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
      return ((IEnumerable)_Values).GetEnumerator();
    }
  }

}
