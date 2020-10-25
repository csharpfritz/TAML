# The TAML Test Suite

To ensure compatibility between tools working with TAML files, we have provided a standard test suite of documents that help define the various levels of support.  Test Suite files reside in the `/test_suite` folder of the [GitHub repository](https://github.com/csharpfritz/TAML) and are reproduced below with descriptions of how they should each be interpreted

## Naming Convention

Compatibility levels are defined with teh first digit of the test suite file name, followed by an index number, a brief description, and the standard `.taml` file extension.

```
1_01_keyvaluepairs.taml
```

## Compatibility Level 1

The initial release of the TAML specification is supported by these test suite definitions that provide the foundation of TAML interactions

### 1_01 - KeyValuePairs

The first test ensures that the first two tenets of TAML are met and enforced:

1. New entries are separated by carriage returns (CR / CRLF)
1. Keys and values are separated by 1+ tab characters (\t)

There are 4 entries that should each be recognized as a key/value pair.  New entries are presented on new lines and each key/value pair is separated by one or more tab (\t) characters.

```
key1	value1
key2	value2
key3		value3
key4					value4
```

### 1_02 - Arrays
