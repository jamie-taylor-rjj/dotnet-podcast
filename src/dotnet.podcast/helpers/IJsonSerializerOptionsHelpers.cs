using System.Text.Json;

namespace dotnet.podcast.helpers;

public interface IJsonSerializerOptionsHelpers
{
    JsonSerializerOptions Default();
}