using dotnet.podcast.builders;

namespace dotnet.podcast.tests.builders;

public class ProjectBuilderTests
{
    private readonly ILogger<ProjectBuilder> _mockedLogger = Substitute.For<ILogger<ProjectBuilder>>();
    
    [Theory]
    [InlineData("My Awesome Name")]
    [InlineData("Some Other Awesome Name")]
    [InlineData("265DD682-BD3A-437C-BF2A-C210A3BE5762")]
    public void Sets_ProjectName_When_Valid_Name_Is_Supplied(string name)
    {
        // Arrange
        var builder = new ProjectBuilder(_mockedLogger);
        
        // Act
        var response = builder.WithName(name);
        
        // Assert
        Assert.NotNull(response);
        Assert.NotEmpty(response.ProjectName);
        Assert.Equal(name, response.ProjectName);
    }
    
    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData("   ")]
    public void Raises_ApplicationException_When_Invalid_Name_Is_Supplied(string name)
    {
        // Arrange
        var builder = new ProjectBuilder(_mockedLogger);
        
        // Act
        var exception = Record.Exception(() => builder.WithName(name));

        // Assert
        Assert.NotNull(exception);
        Assert.Contains("cannot be null or empty", exception.Message);
    }
}