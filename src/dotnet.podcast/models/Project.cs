namespace dotnet.podcast.models;

public class Project
{
    public string ProjectName { get; set; } = null!;
    public List<string> FilesToInclude { get; set; } = new();
    public string? TargetArchiveName { get; set;  }
}