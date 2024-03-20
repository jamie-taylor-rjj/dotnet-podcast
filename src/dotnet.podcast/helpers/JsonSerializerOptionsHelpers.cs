using System.Text.Json;

namespace dotnet.podcast.helpers;

public class JsonSerializerOptionsHelpers : IJsonSerializerOptionsHelpers
{
    private readonly ILogger<JsonSerializerOptionsHelpers> _logger;

    public JsonSerializerOptionsHelpers(ILogger<JsonSerializerOptionsHelpers> logger)
    {
        _logger = logger;
    }

    public JsonSerializerOptions Default()
    {
        _logger.LogInformation("Generating default set of {TypeName}", nameof(JsonSerializerOptions));
        var options = new JsonSerializerOptions
        {
            AllowTrailingCommas = true,
            WriteIndented = true,
            PropertyNameCaseInsensitive = false
        };
        _logger.LogInformation("Generated {TypeName} as {Options}", nameof(JsonSerializerOptions), options);
        return options;
    }
}