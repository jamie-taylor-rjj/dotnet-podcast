using Ardalis.GuardClauses;
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

    public async Task Parse(string[] args)
    {
        Guard.Against.Null(args);
        
        _logger.LogInformation("Parsing args {arguments}", args);
        
        await Parser.Default.ParseArguments<CreateOptions>(args)
            .MapResult(
                (CreateOptions opts) => _createHandler.HandleCreate(opts),
                errs => Task.Run(() => _errorHandler.HandleErrors(errs))
            );
    }
}