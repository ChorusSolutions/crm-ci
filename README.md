# Overview
Chorus' standard CI build (+in future release) YAML template for projects producing NuGet packages.

# Usage
Please read the guidance on using our build templates [here](https://github.com/ChorusSolutions/chorus-yaml-ci).
Note especially the bit on targetting a specific version, not master!

You can see a summary of releases [here](releases.md).

## Creating Your Build
Call the template from your project's yml file like this:

```yaml
queue: Hosted VS2017

resources:
  repositories:
  - repository: nuget-lib-ci
    type: github
    endpoint: github-endpoint
    name: ChorusSolutions/nuget-lib-ci
    ref: refs/tags/{TAG NAME}

steps:

  - template: template/nuget-lib-ci.yml@nuget-lib-ci
    parameters:
      slnPath: demo/NuGetLibCI.Demo/NuGetLibCI.Demo.sln
      packagesToPack: '**/NuGetLibCI.Demo.csproj'
```

Making sure to set the slnPath and packagesToPack appropriately.
Typically you'll package the csproj file(s) which are packages, but not the associated tests, demo, etc. csproj file(s).
Replace {TAG NAME} with the tag in this GitHub repo you wish to target.

You can add other steps before/after the template call as needed.
But currently the template will pack and then publish artifacts, so we may need to change it as requirements become clear.

## Parameters
These params are optional:

| Parameter | Example | Description |
| --------- | ------- | ----------- |
| slnPath   | demo/NuGetLibCI.Demo/NuGetLibCI.Demo.sln | (Required) The path to the solution. Can use standard VSTS wildcards e.g. **\\*.sln |
| packagesToPack | '**/NuGetLibCI.Demo.csproj' | (Required) path(s) to packages to pack (either nuspec or csproj). Can have multiple and can use standard VSTS wildcards |
| nugetFeedGuid | '5733624b-8b6f-4e00-9220-90d2fb25000d' | (Optional) Guid (or name) of the VSTS NuGet feed to pull from. Defaults to the Chorus feed |
| artifactName | 'drop' | (Optional) Name of the artifact to create |
| versioningScheme | byPrereleaseNumber | (Optional) versioning scheme to use. Defaults to '', which uses assembly version number. VSTS names for these options are a bit weird, so best to use the UI and view yaml to get what you need! |


# Contributing
This GitHub repo requires PR and working CI build, as for normal Chorus repos in VSTS.

## Demo
A standard .NET project is provided as a demo showing a simple class library (the pretend package) and other projects, e.g. for tests.