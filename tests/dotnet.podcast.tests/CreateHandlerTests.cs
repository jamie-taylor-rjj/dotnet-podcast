using System.IO.Abstractions.TestingHelpers;
using dotnet.podcast.handlers;
using dotnet.podcast.options;
using Microsoft.Extensions.Logging;
using NSubstitute;

namespace dotnet.podcast.tests;

public class CreateHandlerTests
{
    private readonly ILogger<CreateHandler> _mockedLogger = Substitute.For<ILogger<CreateHandler>>();

    private static MockFileSystem GenerateFileSystem(string fileName) =>
        new(new Dictionary<string, MockFileData>
        {
            { fileName, new MockFileData("this string represents the content of a file") }
        });

    [Fact]
    public void Create_Returns_Error_When_FileExistsAndOverwriteSetToFalse()
    {
        // Arrange
        const string targetFileName = "file.json";
        var mockedFileSystem = GenerateFileSystem(targetFileName);
        var handler = new CreateHandler(_mockedLogger, mockedFileSystem);
        var options = new CreateOptions { FileName = targetFileName };
        
        // Act
        var response = handler.HandleCreate(options);
        
        // Assert
        Assert.Equal(-1, response);
    }
    
    [Fact]
    public void Create_Returns_Success_When_FileExistsAndOverwriteSetToTrue()
    {
        // Arrange
        const string targetFileName = "file.json";
        var mockedFileSystem = GenerateFileSystem(targetFileName);
        var handler = new CreateHandler(_mockedLogger, mockedFileSystem);
        var options = new CreateOptions { FileName = targetFileName, Overwrite = true};
        
        // Act
        var response = handler.HandleCreate(options);
        
        // Assert
        Assert.Equal(0, response);
    }
}