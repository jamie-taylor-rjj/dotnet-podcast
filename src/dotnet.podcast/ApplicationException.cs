namespace dotnet.podcast;

/// <summary>
/// Represents an exception from within the application
/// </summary>
public class ApplicationException : Exception
{
    public ApplicationException(string message)
        : base(message) { }

    public ApplicationException(string message, Exception innerException)
        : base(message, innerException) { }
}