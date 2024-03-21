using System.IO.Abstractions;
using dotnet.podcast.extensions;
using dotnet.podcast.helpers;
using Microsoft.Extensions.DependencyInjection;
using Serilog;

namespace dotnet.podcast.tests.extensions;

public class ServiceCollectionExtensionsTests
{
    [Fact]
    public void AddFileSystem_Adds_IFileSystem_To_ServiceCollection()
    {
        // Arrange
        var services = new ServiceCollection();

        // Act
        services.AddFileSystem();

        // Assert
        var sp = services.BuildServiceProvider();
        var fileSystem = sp.GetService<IFileSystem>();
        Assert.NotNull(fileSystem);
    }
    
    [Fact]
    public void AddHelpers_Adds_IJsonSerializerHelpers_To_ServiceCollection()
    {
        // Arrange
        var services = new ServiceCollection().AddLogging(conf => conf.AddSerilog());

        // Act
        services.AddHelpers();

        // Assert
        var sp = services.BuildServiceProvider();
        var jsonSerializerHelpers = sp.GetService<IJsonSerializerHelpers>();
        Assert.NotNull(jsonSerializerHelpers);
    }
    
    [Fact]
    public void AddHelpers_Adds_IJsonSerializerOptionsHelpers_To_ServiceCollection()
    {
        // Arrange
        var services = new ServiceCollection().AddLogging(conf => conf.AddSerilog());

        // Act
        services.AddHelpers();

        // Assert
        var sp = services.BuildServiceProvider();
        var jsonSerializerOptionsHelpers = sp.GetService<IJsonSerializerOptionsHelpers>();
        Assert.NotNull(jsonSerializerOptionsHelpers);
    }
    
    [Fact]
    public void AddHandlers_Adds_ICreateHandler_To_ServiceCollection()
    {
        // Arrange
        var services = new ServiceCollection()
            .AddLogging(conf => conf.AddSerilog())
            .AddFileSystem()
            .AddHelpers();

        // Act
        services.AddHandlers();

        // Assert
        var sp = services.BuildServiceProvider();
        var createHandler = sp.GetService<ICreateHandler>();
        Assert.NotNull(createHandler);
    }
    
    [Fact]
    public void AddHandlers_Adds_IErrorHandler_To_ServiceCollection()
    {
        // Arrange
        var services = new ServiceCollection()
            .AddLogging(conf => conf.AddSerilog());

        // Act
        services.AddHandlers();

        // Assert

        var sp = services.BuildServiceProvider();
        var errorHandler = sp.GetService<IErrorHandler>();
        Assert.NotNull(errorHandler);
    }
    
    [Fact]
    public void AddCustomParser_Adds_ICustomParser_To_ServiceCollection()
    {
        // Arrange
        var services = new ServiceCollection()
            .AddLogging(conf => conf.AddSerilog())
            .AddFileSystem()
            .AddHelpers()
            .AddHandlers();

        // Act
        services.AddCustomParser();

        // Assert
        var sp = services.BuildServiceProvider();
        var customParser = sp.GetService<ICustomParser>();
        Assert.NotNull(customParser);
    }
}