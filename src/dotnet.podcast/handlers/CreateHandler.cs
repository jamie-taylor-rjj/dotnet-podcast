using System.IO.Abstractions;
using Ardalis.GuardClauses;
using dotnet.podcast.builders;
using dotnet.podcast.helpers;
using dotnet.podcast.models;
using dotnet.podcast.verbs;

namespace dotnet.podcast.handlers;

public class CreateHandler : ICreateHandler
{
    private readonly ILogger<CreateHandler> _logger;
    private readonly IFileSystem _fileSystem;
    private readonly IJsonSerializerHelpers _jsonSerializerHelpers;
    private readonly IProjectBuilder _projectBuilder;

    public CreateHandler(
        ILogger<CreateHandler> logger,
        IFileSystem fileSystem,
        IJsonSerializerHelpers jsonSerializerHelpers,
        IProjectBuilder projectBuilder)
    {
        _logger = logger;
        _fileSystem = fileSystem;
        _jsonSerializerHelpers = jsonSerializerHelpers;
        _projectBuilder = projectBuilder;
    }

    public async Task HandleCreate(CreateVerb opt)
    {
        Guard.Against.Null(opt);
        
        _logger.LogInformation("Creating project file with name {FileName}", opt.FileName);

        if (_fileSystem.File.Exists(opt.FileName))
        {
            _logger.LogInformation("File already exists. Checking value of {Overwrite} field",
                nameof(opt.Overwrite));

            if (!opt.Overwrite)
            {
                _logger.LogInformation("{overwrite} field set to false. File not overwritten; Exiting",
                    nameof(opt.Overwrite));
                return;
            }
        }

        _logger.LogInformation(
            "Creating new project, using {FileName} as {ProjectName} field",
            opt.FileName,
            nameof(Project.ProjectName));

        var project = _projectBuilder.WithName(opt.FileName);

        await _fileSystem.File.WriteAllTextAsync(opt.FileName,
            _jsonSerializerHelpers.Serialise(project, nameof(Project)));
        
        _logger.LogInformation("Written project out to {FileName}", opt.FileName);
    }
}