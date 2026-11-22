#!/usr/bin/env dotnet

// The opening and closing delimiters are each at least three double quotes, and the
// closing delimiter must use the same number of quotes as the opening delimiter

{
    //-------------------------
    // Single line raw strings
    
    string message = """She said "hi" and left.""";
    Console.WriteLine(message);   // She said "hi" and left.

    //-----------------------
    // Multiline raw strings
    //   * The newline immediately after the opening """ and the newline immediately 
    //     before the closing """ aren't part of the value
    //   * The compiler strips any whitespace to the left of the closing """ from every
    //     content line, so you can indent the literal to match its enclosing code block
    //     without that indentation appearing in the string
    
    string sql = """
        SELECT id, name
        FROM customers
        WHERE active = 1
        """;
    Console.WriteLine(sql);

    //--------------------------
    // Raw interpolated strings

    string name = "Ada";
    int    score = 95;

    string report = $"""
        Player:  {name}
        Score:   {score}
        Updated: {DateTime.UtcNow:yyyy-MM-dd}
        """;

    Console.WriteLine(report);

}
