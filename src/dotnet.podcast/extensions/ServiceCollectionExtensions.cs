using Microsoft.Extensions.DependencyInjection;
using System.IO.Abstractions;
using dotnet.podcast.handlers;
using dotnet.podcast.helpers;

namespace dotnet.podcast.extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddCustomParser(this IServiceCollection services)
    {
        return services.AddSingleton<ICustomParser, CustomParser>();
    }

    public static IServiceCollection AddHandlers(this IServiceCollection services)
    {
        return services.AddSingleton<ICreateHandler, CreateHandler>()
            .AddSingleton<IErrorHandler, ErrorHandler>();
    }

    public static IServiceCollection AddHelpers(this IServiceCollection services)
    {
        return services
            .AddSingleton<IFileHelpers, FileHelpers>()
            .AddSingleton<IJsonSerializerHelpers, JsonSerializerHelpers>()
            .AddSingleton<IJsonSerializerOptionsHelpers, JsonSerializerOptionsHelpers>();
    }

    public static IServiceCollection AddFileSystem(this IServiceCollection services)
    {
        return services.AddTransient<IFileSystem, FileSystem>();
    }
}