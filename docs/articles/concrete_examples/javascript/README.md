# JavaScript TAML Format Samples

The following JavaScript configuration files are provided as a proposed definition of support to replace existing file formats with TAML alternatives.


## Package.json

The defacto configuration file for JavaScript packages manages by the npm command-line utility is a simple format that could be replaced and made easier to read with the format and handling that TAML provides.  Consider this sample package.json file:

```json
{
        "name": "my_package",
        "description": "",
        "version": "1.0.0",
        "scripts": {
                "test": "echo \"Error: no test specified\" && exit 1"
        },
        "repository": {
                "type": "git",
                "url": "https://github.com/monatheoctocat/my_package.git"
        },
        "keywords": [],
        "author": "",
        "license": "ISC",
        "bugs": {
                "url": "https://github.com/monatheoctocat/my_package/issues"
        },
        "homepage": "https://github.com/monatheoctocat/my_package"
}
```

There's a lot in this file, and a lot of markup that confuses and makes the document locked to the JavaScript language for parsing and managing.

When we convert it to TAML, it becomes simpler and clearer to understand the purpose of the configuration:

```
name						my_package
description     !""
version					1.0.0
scripts
        test			echo "Error: no test specified" && exit 1
repository
        type			git
        url				https://github.com/monatheoctocat/my_package.git
keywords
        ![]
author						!""
licenses					ISC
bugs
        url				https://github.com/monatheoctocat/my_package/issues
homepage					https://github.com/monatheoctocat/my_package
```

