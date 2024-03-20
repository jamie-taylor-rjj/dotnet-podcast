using CommandLine;

namespace dotnet.podcast.handlers;

public class ErrorHandler : IErrorHandler
{
    private readonly ILogger<ErrorHandler> _logger;

    public ErrorHandler(ILogger<ErrorHandler> logger)
    {
        _logger = logger;
    }

    public void HandleErrors(IEnumerable<Error> errors)
    {
        _logger.LogError("Errors encountered.");
        foreach (var er in errors.ToList())
        {
            _logger.LogError("Error: {er}", er);
        }
    }
}