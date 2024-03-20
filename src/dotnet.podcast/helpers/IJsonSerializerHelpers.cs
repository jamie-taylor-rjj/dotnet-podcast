namespace dotnet.podcast.helpers;

public interface IJsonSerializerHelpers
{
    string Serialise(object obj, string nameOfThing);
}