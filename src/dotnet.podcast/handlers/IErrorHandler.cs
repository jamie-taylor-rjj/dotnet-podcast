using CommandLine;

namespace dotnet.podcast.handlers;

public interface IErrorHandler
{
    int HandleErrors(IEnumerable<Error> errors);
}