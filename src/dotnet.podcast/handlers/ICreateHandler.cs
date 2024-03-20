using dotnet.podcast.options;

namespace dotnet.podcast.handlers;

public interface ICreateHandler
{
    Task HandleCreate(CreateOptions opt);
}