#!/usr/bin/env dotnet

//-----------------------------------
// Null-conditional member access ?.

{
    string? name = null;

    // Without ?., accessing a member on null throws NullReferenceException:
    // int len = name.Length; // throws if name is null

    // ?. returns null instead of throwing:
    int? len = name?.Length;
    Console.WriteLine(len.HasValue); // False

    name = "C#";
    Console.WriteLine(name?.Length); // 2

    // You can chain multiple ?. operators in a single expression. The chain stops 
    // at the first null it encounters

    string? input = null;

    // Chain ?. across multiple method calls — short-circuits at the first null:
    string? upper = input?.Trim()?.ToUpperInvariant();
    Console.WriteLine(upper ?? "(none)"); // (none)

    input = "  hello  ";
    Console.WriteLine(input?.Trim()?.ToUpperInvariant()); // HELLO

    // You can use ?. and ?[] as assignment targets. The assignment runs only when the
    // left-hand object is non-null

    AppConfig? config = new AppConfig();

    // Assigns only when config is non-null (C# 14)
    config?.Theme = "dark";
    Console.WriteLine(config?.Theme); // dark

    AppConfig? missing = null;
    missing?.Theme = "light";                           // no-op: missing is null
    Console.WriteLine(missing?.Theme ?? "(no config)"); // (no config)
}

//-------------------------------------
// Null-conditional indexer access ?[]

// The ?[] operator applies the same short-circuit behavior to indexer and array access

{
    string[]? tags = null;

    // ?[] accesses an element only when the collection is non-null
    string? first = tags?[0];
    Console.WriteLine(first ?? "(none)"); // (none)

    tags = ["csharp", "dotnet", "nullable"];
    Console.WriteLine(tags?[0]);          // csharp
}

//---------------------------------
// Thread-safe delegate invocation

// ?. provides a clean, thread-safe way to invoke a delegate or raise an event. The 
// delegate expression is evaluated only once, so there's no window for another thread
// to unsubscribe between the null check and the invocation

{
    EventHandler? clicked = null;

    // No subscribers — ?.Invoke does nothing
    clicked?.Invoke(null, EventArgs.Empty);

    clicked += (_, _) => Console.WriteLine("Button clicked!");

    // With a subscriber — ?.Invoke calls the handler
    clicked?.Invoke(null, EventArgs.Empty);
    // Output: Button clicked!
}

//--------------------
// Null-coalescing ??

// The ?? operator returns its left-hand operand when it's non-null, and its 
// right-hand operand when the left is null

// ?? is right-associative, so a ?? b ?? c evaluates as a ?? (b ?? c). The first 
// non-null value wins

{
    string? username = null;

    // ?? returns the right-hand value when the left-hand is null
    string display = username ?? "Guest";
    Console.WriteLine(display); // Guest

    username = "alice";
    display  = username ?? "Guest";
    Console.WriteLine(display); // alice
}

//--------------------------------
// Null-coalescing assignment ??=

{
    List<string>? cache = null;

    // ??= assigns only when the variable is null
    cache ??= LoadData();
    Console.WriteLine(cache.Count); // 3

    // cache is already non-null, so LoadData() isn't called again
    cache ??= ["1", "2"];
    Console.WriteLine(cache.Count); // 3

    static List<string> LoadData() => ["alpha", "beta", "gamma"];
}

//------------------------------------------------
// Null pattern matching: is null and is not null

{
    string? input = null;

    // is null is the preferred test — unaffected by operator overloading
    if (input is null)
    {
        Console.WriteLine("No input provided.");
    }

    // == null also works, but a custom == operator can change its behavior
    if (input == null)
    {
        Console.WriteLine("Still no input.");
    }
}

//------------------------------------------------

class AppConfig
{
    public string? Theme { get; set; }
}
