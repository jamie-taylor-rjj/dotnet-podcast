using dotnet.podcast.builders;
using dotnet.podcast.helpers;

namespace dotnet.podcast.tests.handlers;

public class CreateHandlerTests
{
    private readonly ILogger<CreateHandler> _mockedLogger = Substitute.For<ILogger<CreateHandler>>();
    private readonly IJsonSerializerHelpers _mockedSerializer = Substitute.For<IJsonSerializerHelpers>();
    private readonly IProjectBuilder _mockedProjectBuilder = Substitute.For<IProjectBuilder>();

    private static MockFileSystem GenerateFileSystem(string fileName) =>
        new(new Dictionary<string, MockFileData>
        {
            { fileName, new MockFileData("this string represents the content of a file") }
        });

    [Fact]
    public async Task Create_Returns_Error_When_FileExistsAndOverwriteSetToFalse()
    {
        // Arrange
        const string targetFileName = "file.json";
        var mockedFileSystem = GenerateFileSystem(targetFileName);
        var handler = new CreateHandler(_mockedLogger, mockedFileSystem, _mockedSerializer, _mockedProjectBuilder);
        var options = new CreateOptions { FileName = targetFileName };
        
        // Act
        await handler.HandleCreate(options);
        
        // Assert
    }
    
    [Fact]
    public async Task Create_Returns_Success_When_FileExistsAndOverwriteSetToTrue()
    {
        // Arrange
        const string targetFileName = "file.json";
        var mockedFileSystem = GenerateFileSystem(targetFileName);
        var handler = new CreateHandler(_mockedLogger, mockedFileSystem, _mockedSerializer, _mockedProjectBuilder);
        var options = new CreateOptions { FileName = targetFileName, Overwrite = true};
        
        // Act
        await handler.HandleCreate(options);
        
        // Assert
        
    }
}