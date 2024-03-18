using CommandLine;
using Serilog;

namespace dotnet.podcast.handlers;

public class ErrorHandler
{
    // TODO replace with injected logger
    private readonly ILogger _logger = Log.ForContext<ErrorHandler>();

    public int HandleErrors(IEnumerable<Error> errors)
    {
        _logger.Error("Errors encountered.");
        foreach (var er in errors.ToList())
        {
            _logger.Error("Error: {er}", er);
        }
        return 1;
    }
}