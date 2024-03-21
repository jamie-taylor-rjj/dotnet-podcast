using dotnet.podcast.verbs;

namespace dotnet.podcast.handlers;

public interface ICreateHandler
{
    Task HandleCreate(CreateVerb opt);
}