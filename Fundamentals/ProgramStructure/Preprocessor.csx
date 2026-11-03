#!/usr/bin/env dotnet

// ↑ Enable executing the file directly on Unix. This requires the execute permission
// to be set on the file (chmod +x <file>)

// Use #:package to add a NuGet package
#:package Spectre.Console@*

// You can specify an exact version with @, or use @* to pull the latest version
#:package Serilog@3.1.1

// Reference projects, set MSBuild properties, or change the SDK:
#:project ./SharedLibrary/SharedLibrary.csproj
#:property PublishAot=false
#:sdk Microsoft.NET.Sdk.Web

ConfigureLogging();
ShowPlatformInfo();
ProcessData();

// You can combine symbols with logical operators: && (and), || (or), and ! (not)
static void ConfigureLogging()
{
#if DEBUG
    // dotnet Preprocessor.csx --configuration Debug
    Console.WriteLine("Debug logging enabled — verbose output active.");
#else
    // dotnet Preprocessor.csx --configuration Release
    Console.WriteLine("Release logging — errors only.");
#endif
}

static void ShowPlatformInfo()
{
#if NET10_0_OR_GREATER
    Console.WriteLine("Running on .NET 10 or later.");
#elif NET8_0_OR_GREATER
    Console.WriteLine("Running on .NET 8 or 9.");
#else
    Console.WriteLine("Running on an older .NET version.");
#endif
}

static void ProcessData()
{
    try
    {
        // Some operation that might fail
        var data = File.ReadAllText("config.json");
        Console.WriteLine($"Config loaded: {data.Length} characters");
    }

    // Always specify the warning number, such as CS0168, rather than disabling all
    // warnings. This approach keeps the suppression targeted and makes it clear why 
    // a warning is being suppressed

#pragma warning disable CS0168 // Variable is declared but never used
    catch (FileNotFoundException ex)
#pragma warning restore CS0168
    {
        // Fall back to defaults — the exception details aren't needed here
        Console.WriteLine("Config file not found, using defaults.");
    }
}
