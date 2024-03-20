using Ardalis.GuardClauses;
using dotnet.podcast.models;

namespace dotnet.podcast.builders;

public class ProjectBuilder : IProjectBuilder
{
    private readonly ILogger<ProjectBuilder> _logger;
    private readonly Project _project;

    public ProjectBuilder(ILogger<ProjectBuilder> logger)
    {
        _logger = logger;
        _project = new Project();
    }

    public Project WithName(string targetName)
    {
        _logger.LogInformation("Setting {NameField} to {TargetName}", nameof(_project.ProjectName), targetName);
        Guard.Against.NullOrWhiteSpace(targetName, $"{nameof(targetName)} cannot be null or empty");
        
        _project.ProjectName = targetName;
        return _project;
    }
}