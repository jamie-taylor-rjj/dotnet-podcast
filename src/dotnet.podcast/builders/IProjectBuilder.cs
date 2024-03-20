using dotnet.podcast.models;

namespace dotnet.podcast.builders;

public interface IProjectBuilder
{
    Project WithName(string targetName);
}