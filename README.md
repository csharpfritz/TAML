# TAML - Tab Annotated Markup Language

Defining the coolest and simplest markup language delimited ONLY by tabs and carriage returns.  This started as a goof on YAML because @csharpfritz is not a fan of that markup technology, but grew into something that we believe may have a better purpose and functionality than YAML.

The purpose of this markup language is to delimit and format configuration files as well as formatting data for storage and transmission.

All TAML documents adhere to these rules STRICTLY
1. New entries are separated by carriage returns (CR / CRLF)
1. Keys and values are separated by 1+ tab characters (\t)
1. Subkeys are defined on a line starting with 1+ tab characters (\t)
1. An array is a key with multiple child values
1. Presence of space characters are illegal
1. Comments **TBD**

Tabs are important to us, the project maintainers, after we read this [article about how they are NOT accessible to all developers](https://www.reddit.com/r/javascript/comments/c8drjo/nobody_talks_about_the_real_reason_to_use_tabs/).

Documentation website is starting at:  https://csharpfritz.github.io/TAML/
