# The TAML Test Suite

To ensure compatibility between tools working with TAML files, we have provided a standard test suite of documents that help define the various levels of support.  Test Suite files reside in the `/test_suite` folder of the [GitHub repository](https://github.com/csharpfritz/TAML) and are reproduced below with descriptions of how they should each be interpreted

## Naming Convention

Compatibility levels are defined with teh first digit of the test suite file name, followed by an index number, a brief description, and the standard `.taml` file extension.

## Definitions

- **Entries** in TAML are contiguous blocks of text that do NOT contain a tab (\t) character.  
- **Keys** are an entry defined with one or more corresponding entries
- **Values** are entries associated with a Key
- **Complex Values** are entries comprised of a combination of Keys and Values
- **Key Value Pairs** are a Complex Value made up of a Key and a Value
- **Arrays** are a Complex Value comprised of a Key with multiple Values

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

The second test ensure that tenet 4 is met:

  An array is a key with multiple child values

Child values appear on a new line with one additional indent compared to the key value above it.  Additional child values can be defined on proceeding lines at the same indentation level.

This test should present 1 array defined by `key` containing 3 values.  

```
key
        value1
        value2
        value3
```

### 1_03 - Child Arrays

The third test combines the first two features and tests for support of an array of three arrays each containing three values.

```
value1
        value12
        value13
        value14
value2
        value22
        value23
        value24
value3
        value32
        value33
        value34
```

### 1_04 - Child Key Value Pairs

The fourth test combines the key value pair feature with the array feature to ensure support of a more complex structure that contains arrays of key value pairs with some values that are themselves arrays of more values and key value pairs.

This sample should be parsed and return the following structure:

- A single array with a key named `root` 
- Three values in the array:
  - 2 key value pairs
  - An array defined by `key3` with 4 values:
    - `item1`, `item2`, `item3`
    - `item4` defines another array with 4 key value pairs as values

```
root
        key1            value1
        key2            value2
        key3
                item1
                item2
                item3
                item4
                        key41                   value41
                        key42                   value42
                        key43                   value43
                        key44                   value44
```
