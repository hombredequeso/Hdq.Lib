# Hdq.Lib

Grab-bag of helpful C# classes.

## Getting Started

This is a Visual Studio 2017 Solution. It contains two projects written in C#:
- Hdq.Lib
- Hdq.lib.Tests

## Deployment

Hdq.Lib is available from [nuget.org](https://www.nuget.org/packages/Hdq.Lib/).

It is built using [Appveyor](https://www.appveyor.com/).

### Deployment/Continuous Integration Process

#### Dev

Whenever code is pushed to the github master branch, it initiates a build on appveyor.

A build on appveyor will do the following:
- Build all projects in the solution.
- Run all tests in the solution (namely Hdq.Lib.Tests)
- Create all nuget packages in the solution (namely Hdq.Lib)
- Make the nuget package available on the appveyor project feed.

The version number for such a build will be 0.0.0.{appveyor-build-number}

#### Release

To create a release, git tag and push to github master.

```
git tag -a 1.2.3 -m "Tag comment here"
git push --follow-tags
```

Doing so will initiate the same process as for a Dev build, with the following alterations:
* the version number will be {git-tag-number}.{appveyor-build-number}
* the resultant nuget package will be published to [nuget.org](https://www.nuget.org/packages/Hdq.Lib/). 

## Built With

* [Appveyor](https://www.appveyor.com/) - Continuous integration/deployment
* [Nuget.org](https://www.nuget.org) - Package Repository 

## Versioning

Uses [SemVer](http://semver.org/) for versioning. For the versions available, see the [tags on this repository](https://github.com/hombredequeso/Hdq.Lib/tags)

## License

This project is licensed under the MIT License - see the [LICENSE.md](LICENSE.md) file for details


