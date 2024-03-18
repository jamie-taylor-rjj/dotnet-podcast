# Original Notes

The following are the original notes, typed up in a hurry when [Narrativium](https://wiki.lspace.org/Narrativium) struck.

## Notes Content

dotnet-podcast global tool.

### Verbs

- create
- prepare
- secrets
- transcribe
- upload

### Create

Creates a number of files and folders on disc which will help with managing the planning, recording, and show notes. All are markdown.

Might be handy to create a project file, but will need to plan out what that looks like.

### Prepare

Needs a better name. This will take any media files found in a Sources directory, convert them all to flac (ar 44100, ac 1, sample_fmt 16, but can be controlled via the project file or config), then zip them up. The file name for the zip should be taken from the project file.

If there's a readme present in the directory, it should include that, too.

### Secrets

Used to get and set secrets for the installed version of the app. Secrets can be API keys and such.

Will need to research the different way to do this.

### Transcribe

Takes a single mp3 found in the directory (can be named anything) and puts it through either a local installation of "insanely fast whisper", "Mac Whisper", or an Azure OpenAI Whisper service.

This is controlled by a setting in the project file.

API keys will need to be set in a global config using a separate verb (Secrets, perhaps).

### Upload

Uploads the single mp3 to a cloud storage system (which represents the podcast host, but won't be, because that'a non-trivial to do). This will use the settings in the project file to determine where to upload to.

For my local testing, I can create a webapi which takes an mp3 upload.

### Testing

All tests which tough the filesystem will use the System.Io.Abstractions library. That way, we're not actually touching the file system. This will mean that we'll need to use IFileSystem in the code.

Can we use dependency injection in a global tool?

Testing uploads will use a faked HttpClient class.

### Implementation

Which CLI library do I use, and can I test the code that I've written? Will I need a test harness app?

When "finished" create versions in Python, go, Rust, and Node. Could be a fun exercise to practise those languages.

### Questions

Can we use dependency injection in a global tool?

How do I mock ffmpeg? Do I even use ffmpeg? Is there a smaller library that I can use to convert ang audio format to flac with those settings?

How do I test the secrets bit?

How do I test thr transcribe functionality? An interface called ITranscriber which is implemented in classes for each of the known transcribers, with a mocked version for testing?
