using System.IO.Abstractions;
using dotnet.podcast.options;
using Microsoft.Extensions.Logging;

namespace dotnet.podcast.handlers;

public class CreateHandler : ICreateHandler
{
    private readonly ILogger<CreateHandler> _logger;
    private readonly IFileSystem _fileSystem;

    public CreateHandler(ILogger<CreateHandler> logger,
        IFileSystem fileSystem)
    {
        _logger = logger;
        _fileSystem = fileSystem;
    }

    public int HandleCreate(CreateOptions opt)
    {
        _logger.LogInformation("Creating project file with name {FileName}", opt.FileName);

        if (_fileSystem.File.Exists(opt.FileName))
        {
            _logger.LogInformation("File already exists. Checking value of {Overwrite} field",
                nameof(opt.Overwrite));

            if (!opt.Overwrite)
            {
                _logger.LogInformation("{overwrite} field set to false. File not overwritten;  exiting",
                    nameof(opt.Overwrite));
                return -1;
            }
        }

        _fileSystem.File.WriteAllText(opt.FileName, "contents");
        return 0;
    }
}