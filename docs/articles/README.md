# TAML

## Specification

### Version 1.0

TAML attempts to provide a very simple message format that can be used for network communications or hierarchical configuration storage on disk.  It is defined by these 5 simple rules:

1. New entries are separated by carriage returns (CR / CRLF)
1. Keys and values are separated by 1+ tab characters (\t)
1. Subkeys are defined on a line starting with 1+ tab characters (\t)
1. An array is a key with multiple child values
1. Presence of space characters are illegal

A test suite of documents is available at the root of the GitHub repository and more information is provided in the [Test Suite documentation topic](test_suite.md).

### Version 1.1

The 1.1 specification for TAML adds support for Processor Directives and comments in the file format.  In keeping with the spirit of each line in a file is a distinct record, only single-line comments are supported and directives appear on a single line with a namespaced directive, at least one tab, and then the value assigned.

```
# This is a TAML comment
! TAML.EmptyArraySupported		FALSE
```

Additionally, we introducing the `!` escape character to help indicate empty values and empty arrays. 

- Key value pairs without an associated value use `!""` to indicate an empty string.
- Empty Arrays are indicated with a `![]` on the same line as the array key.

```
# This is a key with an empty value
key			!""

# This is an empty array defined by arrayKey
arrayKey
	![]

myArray
	!""
```

## Available Interpreters

- [dotNET](interpreters/dotnet.md)
- [python](interpreters/python.md)

## Mockups of Well-Known Documents as TAML

- Package.JSON -- Node Package Format
- Appsettings.JSON -- .NET Configuration Format
- kubernetes configuration.yml
- workflow.yml -- GitHub Action specification in YAML
