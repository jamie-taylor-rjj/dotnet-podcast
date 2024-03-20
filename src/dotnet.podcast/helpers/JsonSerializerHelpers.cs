using System.Text.Json;
using Ardalis.GuardClauses;

namespace dotnet.podcast.helpers;

public class JsonSerializerHelpers : IJsonSerializerHelpers
{
    private readonly ILogger<JsonSerializerHelpers> _logger;
    private readonly IJsonSerializerOptionsHelpers _serializerOptionsHelpers;

    public JsonSerializerHelpers(ILogger<JsonSerializerHelpers> logger,
        IJsonSerializerOptionsHelpers serializerOptionsHelpers)
    {
        _logger = logger;
        _serializerOptionsHelpers = serializerOptionsHelpers;
    }

    public string Serialise(object obj, string nameOfType)
    {
        Guard.Against.Null(obj, parameterName: nameOfType);
        _logger.LogInformation("Serialising {NameOfType} to string", nameOfType);
        var contents = JsonSerializer.Serialize(obj, _serializerOptionsHelpers.Default());
        _logger.LogInformation("Project serialized as {contents}", contents);
        return contents;
    }
}