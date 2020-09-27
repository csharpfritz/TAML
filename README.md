# TAML - Tab Annotated Markup Language

Defining the coolest and simplest markup language delimited ONLY by tabs and carriage returns.  This started as a goof on YAML because @csharpfritz is not a fan of that markup technology, but grew into something that we believe may have a better purpose and functionality than YAML.

The purpose of this markup language is to delimit and format configuration files as well as formatting data for storage and transmission.

You can get TAML parsers and handlers for your favorite programming languages and frameworks at:

[![Nuget](https://img.shields.io/nuget/v/TAML?color=%239146FF)](https://www.nuget.org/packages/TAML/)

### All TAML documents adhere to these rules STRICTLY

1. New entries are separated by carriage returns (CR / CRLF)
1. Keys and values are separated by 1+ tab characters (\t)
1. Subkeys are defined on a line starting with 1+ tab characters (\t)
1. An array is a key with multiple child values
1. Presence of space characters are illegal
1. Comments **TBD**

Mime-type for TAML documents should be `application/taml`

Tabs are important to us, the project maintainers, after we read this [article about how they are NOT accessible to all developers](https://www.reddit.com/r/javascript/comments/c8drjo/nobody_talks_about_the_real_reason_to_use_tabs/).

Documentation website is starting at:  https://csharpfritz.github.io/TAML/

### How to Engage, Contribute, and Give Feedback

Review the [Code Of Conduct](./CODE-OF-CONDUCT.md).

Some of the best ways to contribute are to try things out, file issues, and make pull-requests.

Check out the [CONTRIBUTING.md](./CONTRIBUTING.md) document to see the best places to log issues and start discussions.
