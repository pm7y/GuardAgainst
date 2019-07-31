//////////////////////////////////////////////////////////////////////
// ARGUMENTS
//////////////////////////////////////////////////////////////////////

var buildVersion = Argument("buildVersion", default(string));
var configuration = Argument("configuration", "Release");

if (buildVersion == null)
{
  Warning($"'buildVersion' argument was NULL");
}
else
{
  Information($"'buildVersion'='{buildVersion}'");
}

//////////////////////////////////////////////////////////////////////
// VARIABLES
//////////////////////////////////////////////////////////////////////

var solutionPath = MakeAbsolute(File("./src/GuardAgainstLib.sln")).FullPath;
var nuspecPath = MakeAbsolute(File("./src/GuardAgainst.nuspec")).FullPath;
var binariesArtifactsFolder = MakeAbsolute(Directory("./Artifacts/Binaries/"));
var nugetArtifactsFolder = MakeAbsolute(Directory("./Artifacts/NuGet/"));
var xunitTestLoggerFolder = MakeAbsolute(Directory("./tools/XunitXml.TestLogger.2.1.26/build/_common"));

//////////////////////////////////////////////////////////////////////
// TASKS
//////////////////////////////////////////////////////////////////////

Task("Clean")
    .Does(() =>
{
    var testResultFolders = GetDirectories("./**/TestResults");    
    var artifactsFolders = GetDirectories("./**/Artifacts");
    var binFolders = GetDirectories("./src/**/bin");
    var objFolders = GetDirectories("./src/**/obj");
    var foldersToDelete = testResultFolders.Concat(artifactsFolders).Concat(binFolders).Concat(objFolders);
    
    DeleteDirectories(foldersToDelete, new DeleteDirectorySettings {
        Recursive = true,
        Force = true
    });

    DotNetCoreClean(solutionPath);
});

Task("Restore")
    .Does(() => 
{
    DotNetCoreRestore(solutionPath, new DotNetCoreRestoreSettings
    {
        Verbosity = DotNetCoreVerbosity.Minimal
    });
});

Task("Build")
    .Does(() =>
{
    var settings = new DotNetCoreBuildSettings
    {
        Configuration = configuration,
        NoRestore = true,
        Verbosity = DotNetCoreVerbosity.Minimal
    };
    
    if (!string.IsNullOrWhiteSpace(buildVersion)) {
        settings.ArgumentCustomization = args => args.Append($"-p:Version={buildVersion}");
    }
    
    DotNetCoreBuild(solutionPath, settings);
});

Task("Test")
    .Does(() =>
{       
        var projects = GetFiles("./src/**/*Test.csproj");

        foreach(var project in projects)
        {
            DotNetCoreTest(
                project.FullPath,
                new DotNetCoreTestSettings()
                {
                    Configuration = configuration,
                    NoBuild = true
                });
        }
});

Task("Publish")
    .Does(() =>
{
    var projects = GetFiles("./src/**/GuardAgainstLib.csproj");

    foreach(var project in projects)
    {
        var projectName = project.GetFilenameWithoutExtension().FullPath;
        var settings = new DotNetCorePublishSettings
        {
            Framework = "netstandard2.0",
            Configuration = "Release",
            OutputDirectory = $"{binariesArtifactsFolder}/{projectName}/",
            NoRestore = true,
            SelfContained = false
        };
        
        if (!string.IsNullOrWhiteSpace(buildVersion)) {
            settings.ArgumentCustomization = args => args.Append($"-p:Version={buildVersion}");
        }

        DotNetCorePublish(project.FullPath, settings);

        DeleteFiles($"{binariesArtifactsFolder}/{projectName}/*.deps.json");
        DeleteFiles($"{binariesArtifactsFolder}/{projectName}/*.pdb");

        Zip($"{binariesArtifactsFolder}/{projectName}/", $"{binariesArtifactsFolder}/{projectName}.zip");

        DeleteDirectory($"{binariesArtifactsFolder}/{projectName}/", new DeleteDirectorySettings {
            Recursive = true,
            Force = true
        });
    }

});

Task("Pack")
    .Does(() =>
{
                  var nuGetPackSettings   = new NuGetPackSettings {
                                     Id                      = "GuardAgainst",
                                     Version                 = buildVersion ?? "1.0.0",
                                     Title                   = "GuardAgainst",
                                     Authors                 = new[] {"Paul Mcilreavy"},
                                     Owners                  = new[] {"Paul Mcilreavy"},
                                     Description             = "Useful guard clauses that simplify argument validity checking and make your code more readable.",
                                     ProjectUrl              = new Uri("https://github.com/pmcilreavy/GuardAgainst"),
                                     IconUrl                 = new Uri("http://cdn.rawgit.com/pmcilreavy/GuardAgainst/master/GuardAgainst.png"),
                                     LicenseUrl              = new Uri("https://github.com/pmcilreavy/GuardAgainst/blob/master/LICENSE"),
                                     Tags                    = new [] {"GuardAgainst", "guard", "dotnet", "contracts", "arguments", "validity"},
                                     RequireLicenseAcceptance= false,
                                     Symbols                 = false,
                                     NoPackageAnalysis       = true,
                                     Files                   = new [] { 
                                      new NuSpecContent {Source = "./GuardAgainstLib.dll", Target = "lib/netstandard2.0/GuardAgainstLib.dll"},
                                      new NuSpecContent {Source = "./GuardAgainstLib.xml", Target = "lib/netstandard2.0/GuardAgainstLib.xml"},
                                     },
                                     BasePath                = "./src/GuardAgainstLib/bin/release/netstandard2.0",
                                     OutputDirectory         = nugetArtifactsFolder.FullPath
                                 };

     NuGetPack(nuspecPath, nuGetPackSettings);
});

//////////////////////////////////////////////////////////////////////
// EXECUTION
//////////////////////////////////////////////////////////////////////

RunTarget("Clean");
RunTarget("Restore");
RunTarget("Build");
RunTarget("Test");
RunTarget("Publish");
RunTarget("Pack");