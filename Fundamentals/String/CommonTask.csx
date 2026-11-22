#!/usr/bin/env dotnet

using System.Text.RegularExpressions;

//------------------------------
// Join a collection of strings

{
    string[] words = ["The", "quick", "brown", "fox"];

    // Concat joins the sequence with no separator.
    string runTogether = string.Concat(words);
    Console.WriteLine(runTogether);

    // Join places a separator between each element.
    string sentence = string.Join(' ', words);
    Console.WriteLine(sentence);
}

//--------------------
// Replace known text

{
    string source = "The mountains are behind the clouds today.";

    // Replace returns a new string; the original is unchanged.
    string updated = source.Replace("mountains", "peaks");

    Console.WriteLine(source);
    Console.WriteLine(updated);

    // Replace every occurrence of one character with another.
    updated = source.Replace(' ', '_');

    Console.WriteLine(updated);
}

//-----------------
// Trim whitespace

{
    string source = "    I'm wider than I need to be.      ";

    // Each method returns a new string with whitespace removed.
    Console.WriteLine($"<{source.Trim()}>");
    Console.WriteLine($"<{source.TrimStart()}>");
    Console.WriteLine($"<{source.TrimEnd()}>");
}

//-----------------------------
// Remove a span of characters

    {
    string source = "Many mountains are behind many clouds today.";
    string toRemove = "many ";

    // Find the text, then remove that span by index and length.
    int index = source.IndexOf(toRemove);

    string result = index >= 0
        ? source.Remove(index, toRemove.Length)
        : source;

    Console.WriteLine(result);
}

//-------------------------------------
// Replace text that matches a pattern

{
    string source = "The mountains are still there behind the clouds today.";

    // Replace "the" or "The" followed by whitespace, preserving the original case.
    // The \s in the pattern keeps "there" from matching.
    string result = Regex.Replace(
        source,
        """the\s""",
        match => char.IsUpper(match.Value[0]) ? "Many " : "many ",
        RegexOptions.IgnoreCase);

    Console.WriteLine(result);
}

//----------------------
// Compare for equality

{
    string root = @"C:\users";
    string root2 = @"C:\Users";

    // Equals and == both perform a case-sensitive, ordinal comparison.
    Console.WriteLine(root.Equals(root2));
    Console.WriteLine(root == root2);

    // Pass a StringComparison value to state the intent explicitly.
    Console.WriteLine(root.Equals(root2, StringComparison.Ordinal));

    // OrdinalIgnoreCase compares the binary values but ignores case.
    bool equalIgnoringCase = string.Equals(root, root2, StringComparison.OrdinalIgnoreCase);
    Console.WriteLine(equalIgnoringCase);
}

//------------------------
// Compare for sort order

// Note: Compare and CompareTo default to a culture-aware comparison, while Equals 
// and == default to ordinal

{
    string first = "Avocado";
    string second = "Banana";

    // Compare returns a negative number, zero, or a positive number
    // to indicate sort order. Specify the comparison type explicitly
    int order = string.Compare(first, second, StringComparison.Ordinal);

    Console.WriteLine(order < 0
        ? $"'{first}' sorts before '{second}'."
        : $"'{first}' sorts at or after '{second}'.");
}

//--------------------------------------------------------------
// Compare against constants with pattern matching is or switch

{
    string status = "Ready";

    // When the right operand is a constant, the is operator and a
    // constant pattern read as an alternative to ==.
    if (status is "Ready")
    {
        Console.WriteLine("The system is ready.");
    }

    foreach (string heading in new[] { "North", "South", "East", "West", "NE" })
    {
        // A switch expression matches each constant pattern in turn and
        // returns the first match. The discard (_) handles every other value.
        string instruction = heading switch
        {
            "North" => "Travel due North for 10 km.",
            "South" => "Travel due South for 10 km.",
            "East"  => "Travel due East for 10 km.",
            "West"  => "Travel due West for 10 km.",
            _       => $"Unknown heading: {heading}.",
        };
        Console.WriteLine(instruction);
    }
}

//--------------------------------------
// Check whether a string contains text

{
    string factMessage = "Extension methods have all the capabilities of regular static methods.";

    // Write the string and include the quotation marks.
    Console.WriteLine($"\"{factMessage}\"");

    // Default comparisons are case sensitive.
    bool containsSearchResult = factMessage.Contains("extension");
    Console.WriteLine($"""Contains "extension"? {containsSearchResult}""");

    // For user-facing searches, pass a StringComparison value to control case and culture.
    bool ignoreCaseSearchResult = factMessage.StartsWith("extension", StringComparison.CurrentCultureIgnoreCase);
    Console.WriteLine($"""Starts with "extension"? {ignoreCaseSearchResult} (ignoring case)""");

    bool endsWithSearchResult = factMessage.EndsWith(".", StringComparison.Ordinal);
    Console.WriteLine($"Ends with '.'? {endsWithSearchResult}");
}

//-------------------------------------
// Locate the position of text

{
    string factMessage = "Extension methods have all the capabilities of regular static methods.";

    Console.WriteLine($"\"{factMessage}\"");

    // Extract the text between the first and last occurrence of "methods".
    int first = factMessage.IndexOf("methods") + "methods".Length;
    int last = factMessage.LastIndexOf("methods");

    string between = factMessage.Substring(first, last - first);
    Console.WriteLine($"""Substring between "methods" and "methods": '{between}'""");
}

//---------------------------
// Split a string into words

{
    string phrase = "The quick brown fox jumps over the lazy dog.";
    string[] words = phrase.Split(' ');

    foreach (var word in words)
    {
        Console.WriteLine($"<{word}>");
    }
}

// Split on multiple separator characters
{
    char[] delimiters = [' ', ',', '.', ':', '\t'];

    string text = "one\ttwo three:four,five six seven";
    Console.WriteLine($"Original text: '{text}'");

    string[] words = text.Split(delimiters);
    Console.WriteLine($"{words.Length} words in text:");

    foreach (var word in words)
    {
        Console.WriteLine($"<{word}>");
    }
}

// Split on multi-character separators
{
    string[] separators = ["<<", "..."];

    string text = "one<<two......three<four";
    Console.WriteLine($"Original text: '{text}'");

    string[] words = text.Split(separators, StringSplitOptions.RemoveEmptyEntries);
    Console.WriteLine($"{words.Length} substrings in text:");

    foreach (var word in words)
    {
        Console.WriteLine(word);
    }
}

// Limit how many substrings you get back
{
    string phrase = "The quick brown fox jumps over the lazy dog.";
    string[] words = phrase.Split(' ', 4, StringSplitOptions.None);

    foreach (var word in words)
    {
        Console.WriteLine($"<{word}>");
    }
}

// Trim whitespace from each entry
{
    string numerals = "1, 2, 3, 4, 5, 6, 7, 8, 9, 10";
    string[] trimmed = numerals.Split(',', StringSplitOptions.TrimEntries);

    Console.WriteLine("Trimmed entries:");
    foreach (var word in trimmed)
    {
        Console.WriteLine($"<{word}>");
    }
}