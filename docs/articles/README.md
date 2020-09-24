# TAML

## Specification

### Sample Documents and Test Suite

- [Simple KeyValuePairs](test_suite/1_keyvaluepairs.taml)
- [Simple Array](test_suite/2_arrays.taml)
- [Child Arrays](test_suite/3_childarrays.taml)
- [Child KeyValue Pairs](test_suite/4_childkeyvaluepairs.taml)

## Available Interpreters

- [dotNET](interpreters/dotnet.md)
- [python](interpreters/python.md)

## Mockups of Well-Known Documents as TAML

- Package.JSON -- Node Package Format
- Appsettings.JSON -- .NET Configuration Format
- kubernetes configuration.yml
- workflow.yml -- GitHub Action specification in YAML

## Test Suite Documents that illustrate common use patterns

- [KeyValuePairs](test_suite/1_keyvaluepairs.taml) - A simple collection of KeyValuePairs in a document
- [Arrays](test_suite/2_arrays.taml) - An array of values that belong to a key value in a document
- [Child Arrays](test_suite/3_childarrays.taml) - A set of top-level keys that each have an array associated
- [Child KeyValuePairs](test_suite/4_childkeyvaluepairs.taml) - A complex document that features arrays and key value pairs mixed together
