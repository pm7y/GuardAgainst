#tool "nuget:?package=OpenCover"
#tool "nuget:?package=XunitXml.TestLogger"
#tool "nuget:?package=OpenCoverToCoberturaConverter"
#tool "nuget:?package=ReportGenerator"
#tool "nuget:?package=GitVersion.CommandLine"

//////////////////////////////////////////////////////////////////////
// ARGUMENTS
//////////////////////////////////////////////////////////////////////

Information("blah");

var version = Argument("version", "");
var target = Argument("target", "Default");
var configuration = Argument("configuration", "Release");

Information(version);

//////////////////////////////////////////////////////////////////////
// VARIABLES
//////////////////////////////////////////////////////////////////////

var solutionPath = MakeAbsolute(File("./src/GuardAgainstLib.sln")).FullPath;
var codeArtifactsFolder = MakeAbsolute(Directory("./Artifacts/Code/"));
var testArtifactsFolder = MakeAbsolute(Directory("./Artifacts/TestOutput/"));
var xunitTestLoggerFolder = MakeAbsolute(Directory("./tools/XunitXml.TestLogger.2.0.0/build/_common"));

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

Task("Version")
    .IsDependentOn("Clean")
    .Does(() => {
        var versionInfo = GitVersion(new GitVersionSettings {
            Branch = "master",
            UpdateAssemblyInfo = true,
            OutputType = GitVersionOutput.BuildServer,
            NoFetch = true,
            //Url = "https://github.com/pmcilreavy/GuardAgainst.git"
        });
          
    
        Information(versionInfo.AssemblySemVer);
        //var versionInfo = GitVersion(new GitVersionSettings{ OutputType = GitVersionOutput.Json });
        // Update project.json
        //var updatedProjectJson = System.IO.File.ReadAllText(specifyProjectJson).Replace("1.0.0-*", versionInfo.NuGetVersion);

        //System.IO.File.WriteAllText(specifyProjectJson, updatedProjectJson);
    });

Task("Restore")
    .IsDependentOn("Version")
    .Does(() => 
{
    DotNetCoreRestore(solutionPath, new DotNetCoreRestoreSettings
    {
        Verbosity = DotNetCoreVerbosity.Minimal
    });
});

Task("Build")
    .IsDependentOn("Restore")
    .Does(() =>
{
    DotNetCoreBuild(solutionPath, new DotNetCoreBuildSettings
    {
        Configuration = configuration,
        NoRestore = true,
        Verbosity = DotNetCoreVerbosity.Minimal
    });
});
    
Task("TestAndCoverage")
    .IsDependentOn("Build")
    .Does(() =>
{       
        CreateDirectory(testArtifactsFolder);

        var relativeCoverageResultPath = $"{testArtifactsFolder}/OpenCover-Coverage.xml";
        var mergeCoverageOutput = false;
        var projects = GetFiles("./src/**/*Test.csproj");

        foreach(var project in projects)
        {
            var projectName = project.GetFilenameWithoutExtension().FullPath;
            var projectPath = project.GetDirectory();
            var relativePath = projectPath.GetRelativePath(testArtifactsFolder);
            var relativeTestResultPath = $"{relativePath}/{projectName}.xml";

            var openCoverArguments = new ProcessArgumentBuilder()
                    .Append("-target:\"c:\\Program Files\\dotnet\\dotnet.exe\"")
                    .Append($"-targetargs:\"test -c {configuration} \"{project.FullPath}\" --no-build --no-restore --logger \"xunit;LogFilePath={relativeTestResultPath}\" --test-adapter-path \"{xunitTestLoggerFolder}\"\"")
                    .Append($"-output:\"{relativeCoverageResultPath}\"")
                    .Append("-filter:\"+[GuardAgainst*]* -[*Test]*\"")
                    .Append($"-searchdirs:\"{xunitTestLoggerFolder}\"")
                    .Append("-register:user")
                    .Append("-oldStyle")
                    .Append("-hideskipped:All");
                    
            if (mergeCoverageOutput)
            {
              openCoverArguments = openCoverArguments.Append("-mergeoutput");
            }
            
            mergeCoverageOutput = true;
                
            StartProcess("./tools/OpenCover.4.6.519/tools/OpenCover.Console.exe", new ProcessSettings { Arguments = openCoverArguments });
        }
        
        var openCoverToCoberturaConverterArguments = new ProcessArgumentBuilder()
          .Append($"-input:\"{relativeCoverageResultPath}\"")
          .Append($"-output:\"{testArtifactsFolder}/Cobertura-Coverage.xml\"")
          .Append($"-sources:\"{xunitTestLoggerFolder}\"")
          .Append($"-includeGettersSetters:true");
                    
        StartProcess("./tools/OpenCoverToCoberturaConverter.0.3.3/tools/OpenCoverToCoberturaConverter.exe", new ProcessSettings { Arguments = openCoverToCoberturaConverterArguments });

        var reportGeneratorArguments = new ProcessArgumentBuilder()
          .Append($"-reports:\"{relativeCoverageResultPath}\"")
          .Append($"-targetdir:\"{testArtifactsFolder}/Coverage-Report/\"");
                    
        StartProcess("./tools/ReportGenerator.3.1.2/tools/ReportGenerator.exe", new ProcessSettings { Arguments = reportGeneratorArguments });
});

Task("Publish")
    .IsDependentOn("TestAndCoverage")
    .Does(() =>
{
    var projects = GetFiles("./src/**/*.csproj").Where(name => !name.FullPath.EndsWith("Test.csproj", StringComparison.OrdinalIgnoreCase));

    foreach(var project in projects)
    {
        var projectName = project.GetFilenameWithoutExtension().FullPath;
        var settings = new DotNetCorePublishSettings
        {
            Framework = "netstandard1.0",
            Configuration = "Release",
            OutputDirectory = $"{codeArtifactsFolder}/{projectName}/",
            NoRestore = true,
            SelfContained = false
        };

        DotNetCorePublish(project.FullPath, settings);

        Zip($"{codeArtifactsFolder}/{projectName}/", $"{codeArtifactsFolder}/{projectName}.zip");

        DeleteDirectory($"{codeArtifactsFolder}/{projectName}/", new DeleteDirectorySettings {
            Recursive = true,
            Force = true
        });
    }

});

//////////////////////////////////////////////////////////////////////
// TASK TARGETS
//////////////////////////////////////////////////////////////////////

Task("Default")
    .IsDependentOn("Publish");

//////////////////////////////////////////////////////////////////////
// EXECUTION
//////////////////////////////////////////////////////////////////////

RunTarget(target);