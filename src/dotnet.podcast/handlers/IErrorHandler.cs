using CommandLine;

namespace dotnet.podcast.handlers;

public interface IErrorHandler
{
    Task HandleErrors(IEnumerable<Error> errors);
}