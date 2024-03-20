using dotnet.podcast.models;

namespace dotnet.podcast.builders;

public static class ProjectBuilder
{
    private static Project _project = new Project();

    public static Project WithName(string targetName)
    {
        _project.ProjectName = targetName;
        return _project;
    }

    public static Project Build(this Project project)
    {
        _project = project;
        return _project;
    }
}