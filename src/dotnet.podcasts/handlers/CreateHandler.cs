using dotnet.podcasts.options;
using Serilog;

namespace dotnet.podcasts.handlers;

public class CreateHandler
{
    // TODO replace with injected logger
    private readonly ILogger _logger = Log.ForContext<CreateHandler>();

    public int HandleCreate(CreateOptions opt)
    {
        _logger.Information("Handling create");
        return 0;
    }
}