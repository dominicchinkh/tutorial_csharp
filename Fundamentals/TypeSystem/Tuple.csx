#!/usr/bin/env dotnet

// A tuple groups multiple values into a single, lightweight structure without 
// requiring you to define a named type

// Use tuples when you need a quick, temporary grouping of related values. For 
// example, when you return multiple results from a method or store a coordinate 
// pair

//-------------------------------
// Declare and initialize tuples

{
    // Tuple with named elements
    (string Name, int Age) person = ("Alice", 30);
    Console.WriteLine($"{person.Name} is {person.Age} years old");

    // Tuple with default element names (Item1, Item2)
    (string, int) unnamed = ("Bob", 25);
    Console.WriteLine($"{unnamed.Item1} is {unnamed.Item2} years old");

    // Tuple declared with var and inline names
    var city = (Name: "Seattle", Population: 749_256);
    Console.WriteLine($"{city.Name}: population {city.Population}");

    // A tuple type is defined by the number of members, referred to as arity, and the 
    // types of those members. The member names are for convenience. You can assign a 
    // tuple to a tuple with the same arity and types even if the members have different 
    // names
    var subscript = (A: "", B: 0);
    subscript = person;
    Console.WriteLine(person);
}

//------------------------
// Inferred element names

{
    var name = "Carol";
    var age = 28;

    // The compiler infers element names from the variable names
    var person = (name, age);
    Console.WriteLine($"{person.name} is {person.age}");
    // Output: Carol is 28
}

//--------------------------------------
// Return multiple values from a method

// Named tuple elements make the return values readable at both the call site and the 
// method signature

static (double Minimum, double Maximum, double Average) ComputeStats(List<double> values)
{
    var min = values.Min();
    var max = values.Max();
    var avg = values.Average();
    return (min, max, avg);
}

//--------------------
// Deconstruct tuples

{
    var point = (X: 3, Y: 7);

    // Deconstruct with var (infer all types)
    var (x, y) = point;
    Console.WriteLine($"x={x}, y={y}");

    // Deconstruct with explicit types
    (int px, int py) = point;
    Console.WriteLine($"px={px}, py={py}");

    // Deconstruct into existing variables
    int a, b;
    (a, b) = point;
    Console.WriteLine($"a={a}, b={b}");

    // Deconstruct a method return value directly
    List<double> data = [10.0, 20.0, 30.0];
    var (min, max, avg) = ComputeStats(data);
    Console.WriteLine($"Min: {min}, Max: {max}, Avg: {avg}");

    // You can deconstruct tuples directly in foreach loops
    List<(string Name, int Score)> results =
    [
        ("Alice", 92),
        ("Bob", 87),
        ("Carol", 95)
    ];

    foreach (var (name, score) in results)
    {
        Console.WriteLine($"{name}: {score}");
    }
}

{
    // When you don't need every element, use a discard (_) in place of each value 
    // you want to ignore
    List<double> values = [5.0, 10.0, 15.0];
    var (_, max, _) = ComputeStats(values);
    Console.WriteLine($"Only need the max: {max}");
    // Output: Only need the max: 15
}

//----------------
// Tuple equality

// Two tuples are equal when all their corresponding elements are equal

{
    var order1 = (Product: "Widget", Quantity: 5);
    var order2 = (Product: "Widget", Quantity: 5);
    var order3 = (Product: "Gadget", Quantity: 3);

    Console.WriteLine(order1 == order2); // True
    Console.WriteLine(order1 == order3); // False

    // Element names don't affect equality—only values matter
    var named = (X: 1, Y: 2);
    var different = (A: 1, B: 2);
    Console.WriteLine(named == different); // True
}

//-----------------------------------
// Nondestructive mutation with with

{
    var original = (Name: "Widget", Price: 19.99m, InStock: true);
    var discounted = original with { Price = 14.99m };

    Console.WriteLine($"Original: {original.Name} at {original.Price:C}");
    Console.WriteLine($"Discounted: {discounted.Name} at {discounted.Price:C}");
    // Output:
    // Original: Widget at $19.99
    // Discounted: Widget at $14.99
}

//------------------------------------
// Tuples in dictionaries and lookups

// Tuples work as dictionary keys, giving you a composite key without defining a 
// custom type

{
    var grid = new Dictionary<(int Row, int Column), string>
    {
        [(0, 0)] = "Origin",
        [(1, 3)] = "Sensor A",
        [(2, 5)] = "Sensor B"
    };

    var target = (Row: 1, Column: 3);
    if (grid.TryGetValue(target, out var label))
    {
        Console.WriteLine($"({target.Row}, {target.Column}): {label}");
    }
    // Output: (1, 3): Sensor A
}
