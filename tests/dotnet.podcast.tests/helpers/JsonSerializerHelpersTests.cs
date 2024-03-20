using dotnet.podcast.helpers;
using dotnet.podcast.models;

namespace dotnet.podcast.tests.helpers;

public class JsonSerializerHelpersTests
{
    private readonly ILogger<JsonSerializerHelpers> _mockedLogger = Substitute.For<ILogger<JsonSerializerHelpers>>();
    private readonly IJsonSerializerOptionsHelpers _mockedOptionHelper = Substitute.For<IJsonSerializerOptionsHelpers>();
    
    [Fact]
    public void Returns_String_For_Valid_Object()
    {
        // Arrange
        var projectName = Guid.NewGuid().ToString();
        var helper = new JsonSerializerHelpers(_mockedLogger, _mockedOptionHelper);
        var proj = new Project { ProjectName = projectName };

        // Act
        var response = helper.Serialise(proj, nameof(Project));
        
        // Assert
        Assert.NotNull(response);
        Assert.NotEmpty(response);
        Assert.Contains(projectName, response);
    }
    
    [Fact]
    public void Raises_Exception_When_Object_Is_Null()
    {
        // Arrange
        var helper = new JsonSerializerHelpers(_mockedLogger, _mockedOptionHelper);
        var proj = (object)null!;

        // Act
        var response = Record.Exception(() => helper.Serialise(proj, nameof(Project)));
        
        // Assert
        Assert.NotNull(response);
        Assert.IsType<ArgumentNullException>(response);
        Assert.Contains(nameof(Project), response.Message);
    }
}