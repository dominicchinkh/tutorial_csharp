#!/usr/bin/env dotnet

// Use enums when a value must be one of a fixed set of options, such as days of 
// the week, HTTP status codes, log levels, or directions

//---------------------------------
// Use enums in switch expressions

var today = Season.Autumn;
Console.WriteLine(DescribeSeason(today));

//-----------
// Bit flags

// Combine values by using the | operator and test for individual flags by using
// HasFlag
var permissions = FileAccess.Read | FileAccess.Write;

Console.WriteLine(permissions);                             // ReadWrite
Console.WriteLine(permissions.HasFlag(FileAccess.Read));    // True
Console.WriteLine(permissions.HasFlag(FileAccess.Execute)); // False

//------------------------------------
// Convert between enums and integers

var status = HttpStatus.NotFound;

ushort code = (ushort)status;
Console.WriteLine($"Status: {status} ({code})"); // Status: NotFound (404)

// Be aware that casting an integer to an enum doesn't validate whether the value 
// matches a defined member. Use Enum.IsDefined to check validity when you accept 
// numeric input from external sources

var fromCode = (HttpStatus)200;
Console.WriteLine(fromCode); // OK

//----------------------------------
// Parse strings and iterate values

var parsed = Enum.Parse<Season>("Winter");
Console.WriteLine(parsed); // Winter

// Try to parse safely. It returns false only when the input can't be parsed. Call Enum.IsDefined to validate named members:
if (Enum.TryParse<Season>("Monsoon", out var unknown))
{
    Console.WriteLine(unknown);
}
else
{
    Console.WriteLine("'Monsoon' is not a valid Season"); // 'Monsoon' is not a valid Season
}

// Iterate over all values in an enum:
foreach (var season in Enum.GetValues<Season>())
{
    Console.WriteLine($"{season} = {(int)season}");
}

//------------------------------------

static string DescribeSeason(Season season) => season switch
{
    Season.Spring => "Flowers bloom and temperatures rise.",
    Season.Summer => "Long days and warm weather.",
    Season.Autumn => "Leaves change color and fall.",
    Season.Winter => "Short days and cold temperatures.",

    // The discard pattern (_) handles any value not explicitly listed
    _ => throw new ArgumentOutOfRangeException(nameof(season))
};

// When an enum represents a combination of choices rather than a single choice, 
// define each member as a power of two and apply the FlagsAttribute

[Flags]
enum FileAccess
{
    None = 0,
    Read = 1,
    Write = 2,
    Execute = 4,
    ReadWrite = Read | Write,
    All = Read | Write | Execute
}

enum Season
{
    Spring,
    Summer,
    Autumn,
    Winter
}

// By default, the underlying type is int, and values start at 0 and increment by 
// one. You can choose a different integral type and assign explicit values to control
// the numeric representation

enum HttpStatus : ushort
{
    OK = 200,
    NotFound = 404,
    InternalServerError = 500
}
