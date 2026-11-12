#!/usr/bin/env dotnet

using System.Diagnostics.CodeAnalysis;

//--------------------------
// Nullable reference types

// Reference types, such as string, arrays, and class instances, can hold null at 
// runtime

/*
 *  By using the ? annotation, you declare your intent:
 *
 *    string? — this reference might be null; the compiler warns if you dereference 
 *              it without checking first
 *    string — this reference should not be null; the compiler warns if you assign 
 *             null to it
 */

{
    // string? means this reference might be null
    string? nullableName = null;

    // string means this reference should not be null
    string nonNullName = "Alice";

    // ?. safely accesses a member when the reference might be null
    string display = nullableName?.ToUpper() ?? "(no name)";
    Console.WriteLine(display);         // (no name)

    display = nonNullName.ToUpper();    // Safe: nonNullName is never null
    Console.WriteLine(display);         // ALICE
}

//---------------------------------
// Express intent with annotations

// Every reference type variable is non-nullable by default. Append ? to declare a 
// nullable reference type

{
    Person p1 = new("Ada", "Lovelace") { MiddleName = "King" };
    Console.WriteLine(p1);
    // Output: Ada King Lovelace

    Person p2 = new("Grace", "Hopper");
    Console.WriteLine(p2);
    // Output: Grace Hopper
}

//------------------------------
// Override the warnings with !

// The null-forgiving operator ! declares that an expression is not-null, even when 
// the analysis says otherwise

// Note: Use ! sparingly. Prefer adding a null check, restructuring the code, or 
//       annotating the relevant API so the compiler reaches the right conclusion on
//       its own

{
    // "ada" matches a switch arm that returns a non-null string,
    // but the return type is string? so the compiler treats the
    // result as maybe-null.
    string? maybeName = LookUpName("ada");

    // The ! tells the compiler "trust me, this isn't null." We just
    // passed "ada", which the switch maps to "Ada Lovelace".
    int length = maybeName!.Length;
    Console.WriteLine(length); // => 12
}

// Returns string? because the wildcard arm yields null.
string? LookUpName(string id) => id switch
{
    "ada" => "Ada Lovelace",
    _ => null,
};

//----------------------------------------
// Attributes that describe API contracts

string? ReadInput() => "hello";

bool IsPresent(

    // Tell the compiler that when `IsPresent` returns true, `value` is not-null
    [NotNullWhen(true)] 
     string? value

    ) => !string.IsNullOrEmpty(value);

void NullAnalysisAttributes()
{
    string? input = ReadInput();

    if (IsPresent(input))
    {
        // No null-forgiving operator needed: the attribute tells the compiler
        // input is not-null when IsPresent returns true.
        Console.WriteLine(input.Length);
    }
}

NullAnalysisAttributes();

//---------------------------------

public sealed class Person(string firstName, string lastName)
{
    public string FirstName { get; } = firstName;
    public string? MiddleName { get; init; }
    public string LastName { get; } = lastName;

    public override string ToString() => MiddleName is null
        ? $"{FirstName} {LastName}"
        : $"{FirstName} {MiddleName} {LastName}";
}
