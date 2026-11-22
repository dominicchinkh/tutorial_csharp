#!/usr/bin/env dotnet

using System.Text;

//-----------------------
// Strings are immutable

// When you build a string from many small pieces in a loop:
{
    // For many sequential edits, StringBuilder avoids allocating a new string each time.
    var builder = new StringBuilder();
    for (int i = 1; i <= 3; i++)
    {
        builder.Append("item ").Append(i).Append(';');
    }

    string result = builder.ToString();
    Console.WriteLine(result);    // item 1;item 2;item 3;
}

//---------------------------------------

{
    // Regular literal:
    //   Use a regular literal when the text is short and contains only a handful of 
    //   escape sequences
    string twoLines = "line 1\nline 2";
    Console.WriteLine(twoLines);

    // Verbatim literals:
    //   Verbatim literals are the right choice when backslashes are part of the 
    //   content but you don't have many embedded quotes
    string winPath = @"C:\src\app\readme.md";
    Console.WriteLine(winPath);

    // Raw string literals:
    string json = """
        {
            "name": "Ada",
            "roles": ["admin", "editor"]
        }
        """;
    Console.WriteLine(json);

    // Interpolated strings:
    //   Interpolation is the recommended way to compose strings from values in 
    //   everyday code
    string name = "Ada";
    int score = 92;
    string report = $"""
    Report for {name}
    -----------------
    Score : {score}
    Grade : {(score >= 90 ? "A" : "B")}
    """;
    Console.WriteLine(report);
}

//-------------------
// Indexing and char

{
    // A string is a sequence of UTF-16 code units. s[i] returns one char.
    string word = "café";

    Console.WriteLine(word.Length); // 4
    Console.WriteLine(word[0]);     // c

    foreach (char c in word)
    {
        Console.Write($"{c} ");     // c a f é
    }
    Console.WriteLine();
}

//-----------------
// String equality

// Equality on string compares the character sequences, not references

{
    // String equality compares character sequences, not references.
    string left  = "hello";
    string right = string.Concat("hel", "lo");

    Console.WriteLine(left == right);                                      // True
    Console.WriteLine(left.Equals(right, StringComparison.Ordinal));       // True
}
