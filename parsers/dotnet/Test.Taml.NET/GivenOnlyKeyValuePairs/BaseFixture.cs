using System.IO;

namespace TAML.Test.Taml.NET.GivenOnlyKeyValuePairs
{
  public class BaseFixture
  {
    protected FileStream Simple { get; }

    public BaseFixture()
    {
      Simple = File.OpenRead("GivenOnlyKeyValuePairs/simple.taml");
    }

  }
}
