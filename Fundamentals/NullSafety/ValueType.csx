#!/usr/bin/env dotnet

//----------------------
// Nullable value types

// Value types such as int, double, and bool can't hold null by default. Add ? to 
// the type name to create a nullable value type that holds either a value or null

// The default value of a nullable value type is null, not the underlying type's 
// default

{
    int? score = null;

    score = 95;
    Console.WriteLine(score.GetValueOrDefault());   // 95
    Console.WriteLine(score?? 0);                   // 95

    int? missing = null;
    Console.WriteLine(missing.GetValueOrDefault(-1));   // -1
    Console.WriteLine(missing?? -1);                    // -1
}

{
    int? temperature = 72;

    if (temperature is int degrees)
    {
        Console.WriteLine($"Temperature is {degrees}°F.");
    }
    else
    {
        Console.WriteLine("Temperature is not recorded.");
    }
    // Output: Temperature is 72°F.
}

{
    // Prefer the is T value pattern for new code

    int? count = 42;

    if (count.HasValue)
    {
        Console.WriteLine($"Count is {count.Value}.");
    }
    else
    {
        Console.WriteLine("Count has no value.");
    }
    // Output: Count is 42.

    int? quantity = null;

    if (quantity != null)
    {
        Console.WriteLine($"Quantity: {quantity.Value}");
    }
    else
    {
        Console.WriteLine("Quantity is not set.");
    }
    // Output: Quantity is not set.
}

// Arithmetic with nullable value types:
//   When either operand is null, the result is null rather than an error

{
    int? a = 10;
    int? b = 20;
    int? c = null;

    int? sum     = a + b;   // both non-null: result is 30
    int? product = a * c;   // one operand is null: result is null

    Console.WriteLine(sum);               // 30
    Console.WriteLine(product.HasValue);  // False — null propagates through arithmetic
}
