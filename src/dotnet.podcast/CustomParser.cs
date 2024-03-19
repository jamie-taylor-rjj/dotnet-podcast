using CommandLine;
using dotnet.podcast.handlers;
using dotnet.podcast.options;

namespace dotnet.podcast;

public class CustomParser : ICustomParser
{
    private readonly ICreateHandler _createHandler;
    private readonly IErrorHandler _errorHandler;

    public CustomParser(ICreateHandler createHandler, IErrorHandler errorHandler)
    {
        _createHandler = createHandler;
        _errorHandler = errorHandler;
    }

    public int Parse(string[] args)
    {
        return Parser.Default.ParseArguments<CreateOptions>(args)
            .MapResult(
                (CreateOptions opts) => _createHandler.HandleCreate(opts),
                errs => _errorHandler.HandleErrors(errs)
            );
    }
}