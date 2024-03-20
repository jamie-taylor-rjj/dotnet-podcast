using System.Text.Json;
using dotnet.podcast.helpers;

namespace dotnet.podcast.tests.helpers;

public class JsonSerializerOptionsHelpersTests
{
    private readonly ILogger<JsonSerializerOptionsHelpers> _mockedLogger =
        Substitute.For<ILogger<JsonSerializerOptionsHelpers>>();

    [Fact]
    public void Test()
    {
        // Arrange
        var targetOptions = new JsonSerializerOptions
        {
            AllowTrailingCommas = true,
            WriteIndented = true,
            PropertyNameCaseInsensitive = false
        };
        var helper = new JsonSerializerOptionsHelpers(_mockedLogger);
        
        // Act
        var response = helper.Default();

        // Assert
        Assert.NotNull(response);
        Assert.Equal(targetOptions.AllowTrailingCommas, response.AllowTrailingCommas);
        Assert.Equal(targetOptions.WriteIndented, response.WriteIndented);
        Assert.Equal(targetOptions.PropertyNameCaseInsensitive, response.PropertyNameCaseInsensitive);
    }
}