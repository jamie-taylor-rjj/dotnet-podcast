using dotnet.podcast.options;

namespace dotnet.podcast.handlers;

public interface ICreateHandler
{
    int HandleCreate(CreateOptions opt);
}