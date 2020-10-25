# TAML

## Specification

TAML attempts to provide a very simple message format that can be used for network communications or hierarchical configuration storage on disk.  It is defined by these 5 simple rules:

1. New entries are separated by carriage returns (CR / CRLF)
1. Keys and values are separated by 1+ tab characters (\t)
1. Subkeys are defined on a line starting with 1+ tab characters (\t)
1. An array is a key with multiple child values
1. Presence of space characters are illegal

A test suite of documents is available at the root of the GitHub repository and more information is provided in the [Test Suite documentation topic](test_suite.md).

## Available Interpreters

- [dotNET](interpreters/dotnet.md)
- [python](interpreters/python.md)

## Mockups of Well-Known Documents as TAML

- Package.JSON -- Node Package Format
- Appsettings.JSON -- .NET Configuration Format
- kubernetes configuration.yml
- workflow.yml -- GitHub Action specification in YAML
