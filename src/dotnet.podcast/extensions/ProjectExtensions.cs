using Ardalis.GuardClauses;
using dotnet.podcast.models;

namespace dotnet.podcast.extensions;

public static class ProjectExtensions
{
    public static Project WithName(this Project project, string targetName)
    {
        Guard.Against.NullOrWhiteSpace(targetName, $"{nameof(targetName)} cannot be null or empty");
    
        project.ProjectName = targetName;
        return project;
    }
    
    public static Project WithFiles(this Project project, List<string> fileNames)
    {
        Guard.Against.NullOrEmpty(fileNames, $"{nameof(fileNames)} cannot be null or empty");

        project.FilesToInclude = fileNames;
        return project;
    }

    public static Project WithTargetArchiveName(this Project project, string targetArchiveName)
    {
        Guard.Against.NullOrWhiteSpace(targetArchiveName, $"{nameof(targetArchiveName)} cannot be null or empty");

        project.TargetArchiveName = targetArchiveName;
        return project;
    }
}