using CommandLine;
using Serilog;

namespace dotnet.podcast.handlers;

public class ErrorHandler : IErrorHandler
{
    private readonly ILogger _logger;

    public ErrorHandler(ILogger logger)
    {
        _logger = logger;
    }

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