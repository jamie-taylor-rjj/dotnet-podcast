using System.IO.Abstractions;
using dotnet.podcast.handlers;
using Microsoft.Extensions.DependencyInjection;
using Serilog;

namespace dotnet.podcast;

public class Program
{
    // This is suboptimal, but it'll do for now
    private const string AppName = "dotnet.podcast";

    public static async Task Main(string[] args)
    {
        Log.Logger = new LoggerConfiguration()
            .WriteTo.Console()
            .WriteTo.File($"{AppName}.log", rollingInterval: RollingInterval.Day)
            .CreateLogger();
        
        try
        {
            Log.Information("{appname} has started", AppName);

            Log.Information("Setting up service collection");

            var services = new ServiceCollection()
                .AddSingleton<ICustomParser, CustomParser>()
                .AddSingleton<ICreateHandler, CreateHandler>()
                .AddSingleton<IErrorHandler, ErrorHandler>()
                .AddTransient<IFileSystem, FileSystem>()
                .AddLogging(conf => conf.AddSerilog())
                .BuildServiceProvider();

            var parser = services.GetService<ICustomParser>();
            if (parser is null)
            {
                throw new ApplicationException($"Couldn't instantiate instance of {nameof(ICustomParser)}");
            }

            await parser.Parse(args);
        }
        catch (Exception ex)
        {
            Log.Error(ex, "Something went wrong");
        }
        finally
        {
            Log.CloseAndFlush();
        }
    }
}