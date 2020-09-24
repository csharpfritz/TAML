# .NET

The .NET parser is available to allow you to read a TAML document and navigate it as a complex object tree.  There are TAMLArrays, TAMLValues, and TAMLKeyValuePairs that describe each of the appopriate TAML data structures in your document.

## Install from NuGet

TBD

## Example Code

### Parsing a document
```csharp
var doc = TAML.Parser.Parse(new StreamReader("SomeFile.taml"));

// Access the 3rd element in the array of objects 
// under the root element and report it's name
doc.rootElement[2].Name;
```

### Traversing a document
