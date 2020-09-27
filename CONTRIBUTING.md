# Contributing to BlazorWebFormsComponents

Thank you for taking the time to consider contributing to our project.

The following is a set of guidelines for contributing to the project.  These are mostly guidelines, not rules, and can be changed in the future.  Please submit your suggestions with a pull-request to this document.

1. [Code of Conduct](#code-of-conduct)
1. [What should I know before I get started?](#what-should-i-know-before-i-get-started?)
    1. [Project Folder Structure](#project-folder-structure)
    1. [Design Decisions](#design-decisions)
1. [How can I contribute?](#how-can-i-contribute?)
    1. [Tool suggestions for contributing](#tool-suggestions-for-contributing)
    1. [Report a Bug](#report-a-bug)
    3. [Look at the current issues](#Look-at-the-current-issues)
    4. [Add a new issue](#add-a-new-issue)
    1. [Write documentation](#write-documentation)


## Code of Conduct

We have adopted a code of conduct from the Contributor Covenant.  Contributors to this project are expected to adhere to this code.  Please report unwanted behavior to [jeff@jeffreyfritz.com](mailto:jeff@jeffreyfritz.com)

## What should I know before I get started?

This project is currently a single library that will provide a shim, a buffer that will help you convert markup to run in Blazor. The project will grow in the future to support more automated conversion from ASP<span></span>.NET Web Forms to Blazor.

### Project Folder Structure

This project is designed to be built and run primarily with Visual Studio 2019. The folders are configured so that they will support editing and working in other editors and on non-Windows operating systems.  We encourage you to develop with these other environments, because we would like to be able to support developers who use those tools as well.  The folders are configured as follows:

```
/docs                                  -- User Documentation
/parsers                               -- TAML Parsers
  /dotnet
    /Taml.NET                          -- DotNet Parser
    /Test.Taml.NET                     -- Unit tests
  /python
    /src
      /pytaml                          -- Python Parser
    /tests                             -- Unit tests

```

All official versions of the project are built and delivered with GitHub Actions and linked in the main README.md and [releases tab in GitHub](https://github.com/FritzAndFriends/BlazorWebFormsComponents/releases).

### Design Decisions

Design for this project is ultimately decided by the project lead, [Jeff Fritz](https://github.com/csharpfritz).  The following project tenets are adhered to when making decisions:

## How can I contribute?

We are always looking for help on this project.  There are several ways that you can help:

### Tool suggestions for contributing

1. [Visual Studio](https://visualstudio.microsoft.com/) (Windows)
2. [Visual Studio Code](https://visualstudio.microsoft.com/) (Windows, Linux, Mac)
3. [Visual Studio For Mac](https://visualstudio.microsoft.com/)
4. Any text editor (Windows, Linux, Mac)
5. Any Web browser.

### Report a Bug

1. [Report a bug](https://github.com/csharpfritz/TAML/issues) with the details of a bug that you have found.  Be sure to tag it as a `Bug` so that we can triage and track it

### Look at the current issues

1. If you see an issue that you would like to help with, add a comment stating your intest.
2. Fork the project to create your own version of the repositorry.
3. Clone the repository locally.
4. Create a new branch referencing the issue or bug you are addressing.
5. Write some code.

### Add a new issue

[Create a new issue](https://github.com/csharpfritz/TAML/issues) if you have suggestions or ideas to improve the project.

### Write documentation

We are always looking for help to add content to the `/docs` section of the repository with proper links back through to the main `/README.md`.

### Recources

[cmjchrisjones Blog: Contributing To Someone else's git repository](https://cmjchrisjones.dev/posts/contributing-to-someone-elses-git-repository/)
