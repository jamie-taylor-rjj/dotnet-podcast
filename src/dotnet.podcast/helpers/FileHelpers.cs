using System.IO.Abstractions;

namespace dotnet.podcast.helpers;

public class FileHelpers : IFileHelpers
{
    private readonly IFileSystem _fileSystem;
    private readonly ILogger<FileHelpers> _logger;
    private readonly string[] _targetExtensions;

    public FileHelpers(IFileSystem fileSystem,
        ILogger<FileHelpers> logger)
    {
        _fileSystem = fileSystem;
        _logger = logger;
        
        // TODO: inject this list from config?
        _targetExtensions = new[] { "*.mp3", "*.wav" };
    }

    public List<string> GetAllRelevantFiles()
    {
        var currentDirectory = _fileSystem.Directory.GetCurrentDirectory();
        _logger.LogInformation("Looking in current directory {Directory} for media files", currentDirectory);

        // The LINQ is adapted from this Stack Overflow answer: https://stackoverflow.com/a/19961761
        var returnData =
            // Look for all files which match on the globs found in _targetExtensions
            _targetExtensions .SelectMany(tex =>
                _fileSystem.Directory.EnumerateFiles(currentDirectory, tex))
            // Directory.EnumerateFiles returns the absolute paths of the files, but
            // we want the paths relative to the current directory (i.e. "here")
            .Select(file => _fileSystem.Path.GetRelativePath(currentDirectory, file))
            .ToList();

        _logger.LogInformation("Found {Count} media files", returnData.Count);
        return returnData;
    }
}