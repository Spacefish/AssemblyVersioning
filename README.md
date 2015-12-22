![Nuget version](http://img.shields.io/nuget/v/Nortal.Utilities.AssemblyVersioning.MsBuildTask.svg)
![Nuget downloads](http://img.shields.io/nuget/dt/Nortal.Utilities.AssemblyVersioning.MsBuildTask.svg)

Nortal.Utilities.AssemblyVersioning
==================

Sets up a c# project to automatically generate extended version information attributes on each build using various predefined or customized patterns. This provides developers the tools to always know for sure where and how a binary was created by looking only at the assembly dll. 
Developers can easily configure which algorithms to use and extend existing logic using standard MsBuild functionality.

No Visual Studio configuration, plugins or extensions are needed - just add the nuget package to project and same functionality is in effect for all members of the team.

Licenced under Apache Licence v2.0.

Requirements
-------------
MSBuild task is built using Microsoft .Net Framework 4.0. 
Can be applied to c# projects of any .Net version as long as MsBuild 4.0 or newer is used (Visual Studio 2010+).

Functionality
-------------
Tool uses AssemblyVersionAttribute value as input and can automatically create the following attributes to project:
* AssemblyInformationalVersionAttribute - to control business-friendly version number
* FileVersionAttribute - to control version number shown in windows explorer, to make each build result unique
* ConfigurationAttribute - to attach additional build information about build environment or settings

User can configure which pattern is used for each target attribute. Available patterns:
* HumanReadable2SlotTimestamp
  * 1.23.{5-number-date}.{time}.    Example: 1.23.30423.2059 (Read: v1.23, built on 2013-04-23 20:59)
* HumanReadable1SlotTimestamp
  * 1.23.67.{5-number-date}
* HumanReadableBuildInfo
  * {conf} (on UTC{datetime} by {user} at {machine}
* NugetSemanticVersion
  * 1.23.67[-{conf}-{date}-{time}]    Examples: 1.23.3 -or- 1.2.3-Debug-20130423-2059
* Skip
  * Attribute will not be generated

Getting started
---------------
To install the MsBuild task over <a href="https://nuget.org/packages/Nortal.Utilities.AssemblyVersioning.MsBuildTask/">Nuget</a>, run the following command in the  Package Manager Console 
```
PM> Install-Package Nortal.Utilities.AssemblyVersioning.MsBuildTask
```
On each build the file AssemblyInformationalVersion.gen.cs will be automatically populated with versioning info similar to this:

```
// NB! this file is automatically generated. All manual changes will be lost on build.
// Check ~/Properties/Nortal.Utilities.AssemblyVersioning.MsBuildTask.props file for other available algorithms and supported attributes.

// Generated based on assembly version: 0.9.0.0
[assembly: AssemblyInformationalVersion("0.9.0")] // algorithm: NugetSemanticVersionGenerator
[assembly: AssemblyFileVersion("0.9.30708.1208")] // algorithm: HumanReadable2SlotTimestampGenerator
[assembly: AssemblyConfiguration("Release (on UTC2013-07-08T12:08:13 by imrep at DELL472)")] // algorithm: HumanReadableBuildInfoGenerator
```

