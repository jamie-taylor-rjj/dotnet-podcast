using dotnet.podcast.helpers;

namespace dotnet.podcast.tests.helpers;

public class FileHelpersTests
{
    private readonly ILogger<FileHelpers> _mockedLogger = Substitute.For<ILogger<FileHelpers>>();
    private static MockFileSystem GenerateFileSystem(string directoryName) =>
        new(new Dictionary<string, MockFileData>
        {
            { "jamie.mp3", new MockFileData("this is the file contents") }
        }, directoryName);
    
    [Fact]
    public void GetAllRelevantFiles_Returns_ListOfStrings_RepresentingAllRelevantMediaFiles_WhenFilesPresent()
    {
        // arrange
        var mockedFileSystem = GenerateFileSystem("/temp");
        mockedFileSystem.Directory.SetCurrentDirectory("/temp");
        var fileHelpers = new FileHelpers(mockedFileSystem, _mockedLogger);

        // act
        var listOfFiles = fileHelpers.GetAllRelevantFiles();
        
        // assert
        Assert.NotNull(listOfFiles);
        Assert.NotEmpty(listOfFiles);
        Assert.Single(listOfFiles);
    }
    
    [Fact]
    public void GetAllRelevantFiles_Returns_EmptyListOfStrings_RepresentingAllRelevantMediaFiles_WhenNoFilesPresent()
    {
        // arrange
        var mockedFileSystem = GenerateFileSystem("/temp");
        mockedFileSystem.Directory.SetCurrentDirectory("/");
        var fileHelpers = new FileHelpers(mockedFileSystem, _mockedLogger);

        // act
        var listOfFiles = fileHelpers.GetAllRelevantFiles();
        
        // assert
        Assert.NotNull(listOfFiles);
        Assert.Empty(listOfFiles);
    }
}