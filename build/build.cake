//////////////////////////////////////////////////////////////////////
// ARGUMENTS
//////////////////////////////////////////////////////////////////////

var buildVersion = Argument("buildVersion", "1.0.0-dev");
var configuration = Argument("configuration", "Debug");

if (buildVersion == null)
{
  Warning($"'buildVersion' argument was NULL");
}
else
{
  Information($"'buildVersion'='{buildVersion}'");
}
Information($"'configuration'='{configuration}'");

//////////////////////////////////////////////////////////////////////
// VARIABLES
//////////////////////////////////////////////////////////////////////

var solutionPath = MakeAbsolute(File("../src/GuardAgainstLib.sln")).FullPath;

//////////////////////////////////////////////////////////////////////
// TASKS
//////////////////////////////////////////////////////////////////////

Task("Clean")
    .Does(() =>
{ 
    var binFolders = GetDirectories("../src/**/bin");
    var objFolders = GetDirectories("../src/**/obj");
    var foldersToDelete = binFolders.Concat(objFolders);
    
    DeleteDirectories(foldersToDelete, new DeleteDirectorySettings {
        Recursive = true,
        Force = true,
    });

    DotNetCoreClean(solutionPath);
});

Task("Build")
    .Does(() =>
{                           
    var settings = new DotNetCoreBuildSettings
    {
        Configuration = configuration,
        Verbosity = DotNetCoreVerbosity.Minimal,

    };
    
    if (!string.IsNullOrWhiteSpace(buildVersion)) {
        settings.ArgumentCustomization = args => args.Append($"-p:Version={buildVersion} -p:WarningLevel=4 -p:TreatWarningsAsErrors=true -p:NoWarn=\"\" -p:WarningsAsErrors=\"\"");
    }
    
    DotNetCoreBuild(solutionPath, settings);
});

Task("Test")
    .Does(() =>
{       
        var projects = GetFiles("../src/**/*Test.csproj");

        foreach(var project in projects)
        {
            DotNetCoreTest(
                project.FullPath,
                new DotNetCoreTestSettings()
                {
                    Configuration = configuration,
                    NoBuild = true,
                    Verbosity = DotNetCoreVerbosity.Minimal
                });
        }
});

//////////////////////////////////////////////////////////////////////
// EXECUTION
//////////////////////////////////////////////////////////////////////

RunTarget("Clean");
RunTarget("Build");
RunTarget("Test");
