using CommandLine;
using dotnet.podcast.handlers;
using dotnet.podcast.options;

namespace dotnet.podcast;

public class CustomParser : ICustomParser
{
    private readonly ILogger<CustomParser> _logger;
    private readonly ICreateHandler _createHandler;
    private readonly IErrorHandler _errorHandler;

    public CustomParser(ICreateHandler createHandler,
        IErrorHandler errorHandler,
        ILogger<CustomParser> logger)
    {
        _createHandler = createHandler;
        _errorHandler = errorHandler;
        _logger = logger;
    }

    public int Parse(string[] args)
    {
        _logger.LogInformation("Using args {arguments}", args);
        
        return Parser.Default.ParseArguments<CreateOptions>(args)
            .MapResult(
                (CreateOptions opts) => _createHandler.HandleCreate(opts),
                errs => _errorHandler.HandleErrors(errs)
            );
    }
}