using CommandLine;

namespace dotnet.podcasts.console
{
    public class Program
    {
        [Verb("create", HelpText = "Used to create a podcast project file")]
        public class CreateOptions
        {
            
        }

        public static int RunAddAndReturnExitCode(CreateOptions opts)
        {
            return 0;
        }

        public static int HandleErrors(IEnumerable<Error> errors)
        {
            // TODO log all the errors
            return 1;
        }

        public static int Main(string[] args)
        {
            return Parser.Default.ParseArguments<CreateOptions>(args)
                .MapResult(
                    (CreateOptions opts) => RunAddAndReturnExitCode(opts),
                    errs => HandleErrors(errs));
        }
    }
}