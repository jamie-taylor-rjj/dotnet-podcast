namespace dotnet.podcast;

public interface ICustomParser
{
    Task Parse(string[] args);
}