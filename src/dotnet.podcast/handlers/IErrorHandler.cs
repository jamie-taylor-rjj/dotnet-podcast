using CommandLine;

namespace dotnet.podcast.handlers;

public interface IErrorHandler
{
    void HandleErrors(List<Error> errors);
}