using CommandLine;

namespace dotnet.podcast.verbs;

[Verb("create",
       HelpText = "Used to create a podcast project file")]
public class CreateVerb
{
       [Option('f',
              "filename",
              Required = true,
              HelpText = "The target filename for our podcast project")]
       public string FileName { get; set; } = null!;
       
       [Option('o',
              "overwrite",
              Required = false,
              HelpText = "Used to force overwrite if the filename is already in use")]
       public bool Overwrite { get; set; }
}