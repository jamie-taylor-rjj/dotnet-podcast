# dotnet-podcast

A cross platform .NET global tool `dotnet-podcast` for managing files involved in recording, editing, and publishing audio-only podcasts

## Build Requirements

- [.NET SDK vLatest](https://get.dot.net/)
  - Make sure that you install the SDK, *NOT* the runtime
  - The SDK contains the runtime, but the runtime doesn't contain the SDK
- a compatible IDE:
  - [Visual Studio Code](https://code.visualstudio.com) (free) with the [C# Dev Kit](https://marketplace.visualstudio.com/items?itemName=ms-dotnettools.csdevkit) (requires a Visual Studio subscription)&ast;
  - [JetBrains Rider](https://www.jetbrains.com/rider/) (cross platform, requires a subscription)
  - [Visual Studio](https://visualstudio.com) (Windows only)

&ast; = Licensing is out of scope for this repo, but you may be eligible for a Community (free) subscription. See [https://visualstudio.microsoft.com/vs/pricing/](https://visualstudio.microsoft.com/subscriptions/) for details.

## Building The Code

Assuming that you have the above requirements installed, use either your IDE of choice to build the code, or run the following CLI command `dotnet build` in the root of the repo (i.e. where this README is found).

## Running The Tests

Either use your IDE of choice or run the following CLI command `dotnet test` in the root of the repo (i.e. where this README is found).
