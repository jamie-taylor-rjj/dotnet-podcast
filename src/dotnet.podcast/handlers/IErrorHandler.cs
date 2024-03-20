using CommandLine;

namespace dotnet.podcast.handlers;

public interface IErrorHandler
{
    void HandleErrors(IEnumerable<Error> errors);
}