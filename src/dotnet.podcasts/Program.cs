using CommandLine;
using dotnet.podcasts.options;
using Serilog;

namespace dotnet.podcasts;

public class Program
{
    // This is suboptimal, but it'll do for now
    private const string AppName = "dotnet.podcasts";
    public static int RunAddAndReturnExitCode(CreateOptions opts)
    {
        return 0;
    }

    public static int HandleErrors(IEnumerable<Error> errors)
    {
        // TODO log all the errors
        return 1;
    }

    public static int Main(string[] args)
    {
        using var log = new LoggerConfiguration()
            .WriteTo.Console()
            .WriteTo.File($"{AppName}.log", rollingInterval: RollingInterval.Day)
            .CreateLogger();
        
        log.Information("{appname} has started", AppName);
        log.Information("Using args {arguments}", args);

        try
        {
            return Parser.Default.ParseArguments<CreateOptions>(args)
                .MapResult(
                    (CreateOptions opts) => RunAddAndReturnExitCode(opts),
                    errs => HandleErrors(errs));
        }
        catch (Exception ex)
        {
            log.Error(ex, "Something went wrong");
        }
        finally
        {
            Log.CloseAndFlush();
        }

        return -1;
    }
}