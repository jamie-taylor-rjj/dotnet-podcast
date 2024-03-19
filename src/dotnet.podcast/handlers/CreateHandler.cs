using System.IO.Abstractions;
using System.Text.Json;
using dotnet.podcast.models;
using dotnet.podcast.options;

namespace dotnet.podcast.handlers;

public class CreateHandler : ICreateHandler
{
    private readonly ILogger<CreateHandler> _logger;
    private readonly IFileSystem _fileSystem;

    public CreateHandler(
        ILogger<CreateHandler> logger,
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

        _logger.LogInformation(
            "Creating new project, using {FileName} as {ProjectName} field",
            opt.FileName,
            nameof(Project.ProjectName));
        
        var project = new Project { ProjectName = opt.FileName };

        _logger.LogInformation("Serializing project to string");
        var jsonOptions = new JsonSerializerOptions
        {
            AllowTrailingCommas = true,
            WriteIndented = true,
            PropertyNameCaseInsensitive = false
        };
        var contents = JsonSerializer.Serialize(project, jsonOptions);
        
        _logger.LogInformation("Project serialized as {contents}", contents);

        _fileSystem.File.WriteAllText(opt.FileName, contents);
        _logger.LogInformation("Written project out to {FileName}", opt.FileName);
        
        return 0;
    }
}