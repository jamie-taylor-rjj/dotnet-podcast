using CommandLine;

namespace dotnet.podcast.handlers;

public class ErrorHandler : IErrorHandler
{
    private readonly ILogger<ErrorHandler> _logger;

    public ErrorHandler(ILogger<ErrorHandler> logger)
    {
        _logger = logger;
    }

    public void HandleErrors(List<Error> errors)
    {
        if (errors.Any(er => er.Tag is ErrorType.HelpRequestedError or ErrorType.VersionRequestedError))
        {
            _logger.LogInformation("Help or Version information requested; exiting");
            return;
        }

        _logger.LogError("Errors encountered.");
        foreach (var er in errors.ToList())
        {
            _logger.LogError("Error: {er}", er);
        }
    }
}