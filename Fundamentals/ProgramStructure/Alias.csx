#!/usr/bin/env dotnet

// A using alias creates a shorthand name for a type or namespace
using CustomerList = System.Collections.Generic.List<Customer>;

// You can alias any type, including tuples and pointer types
using Point = (double X, double Y);

CustomerList customers = [new() { Name = "Alice" }, new() { Name = "Bob" }];

double distance = CalculateDistance((1, 2), (3, 4));
Console.WriteLine($"Distance is {distance}");

double CalculateDistance(Point a, Point b)
{
    var dx = a.X - b.X;
    var dy = a.Y - b.Y;
    return Math.Sqrt(dx * dx + dy * dy);
}

class Customer
{
    /*
     *  Readable anytime (get): Code outside the class can read the value whenever it
     *  wants (e.g., customer.Name)
     *
     *  Settable only during initialization (init): You can assign a value when the 
     *  object is instantiated using an object initializer or a constructor, but never
     *  again afterwards
     *
     *  Immutable afterwards: Once the object is created, the property becomes read-only
     */
    public required string Name { get; init; }

    public string? Email { get; init; }

    public override string ToString() => $"{Name} ({Email ?? "no email"})";
}
