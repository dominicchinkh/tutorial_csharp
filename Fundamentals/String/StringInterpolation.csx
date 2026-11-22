#!/usr/bin/env dotnet

using System.Globalization;

// C# evaluates the expression, converts the result to a string by calling its 
// ToString() method, and substitutes the text into the result

// The string interpolation for a null expression is the empty string

{
    double a = 3;
    double b = 4;

    Console.WriteLine(
        $"Area of the right triangle with legs of {a} and {b} is {0.5 * a * b}"
    );
    Console.WriteLine(
        $"Length of the hypotenuse of the right triangle with legs of {a} and {b} is {CalculateHypotenuse(a, b)}"
    );

    double CalculateHypotenuse(double leg1, double leg2) => Math.Sqrt(leg1 * leg1 + leg2 * leg2);

    // To include a literal { or } character in the result, double it ({{ or }})
}

//-----------------------
// Apply a format string

// To control how an expression result is formatted, follow the expression with a 
// colon and a standard or custom format string

{
    var date = new DateTime(1731, 11, 25);
    Console.WriteLine($"On {date:dddd, MMMM dd, yyyy} L. Euler introduced the letter e to denote {Math.E:F5}.");
    // => On Sunday, November 25, 1731 L. Euler introduced the letter e to denote 2.71828.
}

//-----------------------------------
// Set the field width and alignment

// To produce aligned output, follow the expression with a comma and a minimum field 
// width. Positive widths right-align the value, and negative widths left-align it

{
    var titles = new Dictionary<string, string>()
    {
        ["Doyle, Arthur Conan"]  = "Hound of the Baskervilles, The",
        ["London, Jack"]         = "Call of the Wild, The",
        ["Shakespeare, William"] = "Tempest, The"
    };

    Console.WriteLine("Author and Title List");
    Console.WriteLine();
    Console.WriteLine($"|{"Author", -25}|{"Title", 30}|");

    foreach (var title in titles)
    {
        Console.WriteLine($"|{title.Key, -25}|{title.Value, 30}|");
    }

    // When you need both alignment and a format string, put alignment first
    //   {<expression>,<width>:<formatString>}
}

//------------------------------
// Use a conditional expression

{
    var rand = new Random(42);
    for (int i = 0; i < 3; i++)
    {
        // The colon has special meaning inside an interpolation expression, so wrap a 
        // conditional expression in parentheses

        Console.WriteLine($"Coin flip: {(rand.NextDouble() < 0.5 ? "heads" : "tails")}");
    }
}

//--------------------------------
// Format with a specific culture

{
    CultureInfo[] cultures =
    [
        CultureInfo.GetCultureInfo("en-US"),
        CultureInfo.GetCultureInfo("en-GB"),
        CultureInfo.GetCultureInfo("nl-NL"),
        CultureInfo.InvariantCulture
    ];

    var date = new DateTime(2026, 5, 21, 12, 35, 31);
    var number = 31_415_926.536;
    foreach (var culture in cultures)
    {
        var cultureSpecificMessage = string.Create(culture, $"{date,23}{number,20:N3}");
        Console.WriteLine($"{culture.Name,-10}{cultureSpecificMessage}");
    }
}
