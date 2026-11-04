#!/usr/bin/env dotnet

{
#pragma warning disable CS0219 // The variable is assigned but its value is never used

    //---------------
    // Numeric types

    // Integer literals — Decimal (42), hexadecimal (0x2A), and binary (0b_0010_1010)

    // Place the _ digit separator anywhere within a number to make it easier to read. 
    // Common patterns include thousand separators in decimal literals (1_000_000_000), 
    // byte or word boundaries in hexadecimal (0xFF_FF), and nibble boundaries in binary 
    // (0b_0010_1010)

    int population = 67_000_000;
    long distance = 384_400_000L;
    short temperature = -40;
    byte red = 255;

    double pi = 3.141592653589793;
    double scientific = 1.5e6; // 1,500,000
    float gravity = 9.81f;
    decimal price = 19.99m;

    //----------------
    // Unsigned types

    //  Append U for uint, or UL for ulong

    uint fileSize = 4_294_967_295;
    ulong totalBytes = 18_446_744_073_709_551_615;
    ushort port = 443;

    //-----------------------
    // Native-sized integers
    //   Represent integers whose size matches the platform's native pointer size: 32 
    //   bits on a 32-bit platform, 64 bits on a 64-bit platform

    nint bufferSize = 1024;
    nuint elementCount = 256;

    //------
    // bool
    bool isValid = true;

    //------
    // char

    // Character literals use single quotes and support escape sequences (\n, \t, \u)

    char grade = 'A'; // Stores a single Unicode character (UTF-16 code unit)
    char unicode = '\u0041'; // 'A'

    //--------
    // string

    // String literals use double quotes. Note: Strings are immutable

    // Use verbatim strings (@"...") for simple file paths (@C:\temp) or short strings 
    // with backslashes. Use raw string literals ("""...""") for multi-line blocks, 
    // JSON, XML, HTML, SQL queries, or any text containing lots of quotation marks

    string greeting = "Hello, world!";          // Regular string

    string message = $"Found {elementCount} items";      // interpolated string

    string path = @"C:\Users\docs\file.txt";    // verbatim string

    string json = """
        { "name": "Alice", "age": 30 }
        """;                                    // raw string literal

    string raw = $"""
        Found {elementCount} items in "{greeting}"
        """;                                    // raw + interpolated

    //--------------------
    // default expression

    // The default expression is most useful in generic code, where you don't know the 
    // concrete type and can't hard-code a specific value like 0 or null. Write default 
    // (without a type argument) when the compiler can infer the type from context, or 
    // default(T) when the type isn't obvious

    int defaultInt = default;          // 0
    bool defaultBool = default;        // false
    string? defaultString = default;   // null

    // Use default in a conditional:
    var limit = (args.Length > 0) ? int.Parse(args[0]) : default(int);

    //-------------------------------------
    // Implicitly typed variables with var

    var count = 10;              // compiler infers int
    var name = "C#";             // compiler infers string
    var items = new List<int>(); // compiler infers List<int>

    // var requires an initializer — the compiler needs a value to infer the type.
    // The following line wouldn't compile:
    // var unknown;

    //------------------------------
    // Target-typed new expressions

    // When you already know the target type from context, such as a variable 
    // declaration or a method parameter, you can omit the type name from the new 
    // expression

    List<string> names = new() { "Alice", "Bob", "Charlie" };

    Dictionary<string, int> scores = new()
    {
        ["Alice"] = 95,
        ["Bob"] = 87
    };

    //------------------
    // The dynamic type

    // The dynamic type bypasses compile-time type checking. The compiler resolves 
    // operations on a dynamic variable at run time instead

    // Use dynamic when interacting with COM APIs, dynamic languages, or reflection-heavy 
    // scenarios where types aren't known at compile time

    dynamic value = 42;
    Console.WriteLine(value.GetType()); // System.Int32

    value = "Now I'm a string";
    Console.WriteLine(value.GetType()); // System.String

    // The compiler doesn't check operations on dynamic at compile time.
    // Errors surface at run time instead.

#pragma warning restore CS0219
}

// The minimum and maximum limits
{
    int max = int.MaxValue;
    int min = int.MinValue;
    Console.WriteLine($"The range of integers is {min} to {max}");
}

{
    double max = double.MaxValue;
    double min = double.MinValue;
    Console.WriteLine($"The range of double is {min} to {max}");
}

{
    decimal min = decimal.MinValue;
    decimal max = decimal.MaxValue;
    Console.WriteLine($"The range of the decimal type is {min} to {max}");

    // The M suffix on the numbers indicates that a constant should use the decimal 
    // type. Otherwise, the compiler assumes the double type
    
    decimal c = 1.0M;
    decimal d = 3.0M;
    Console.WriteLine(c / d);
}
