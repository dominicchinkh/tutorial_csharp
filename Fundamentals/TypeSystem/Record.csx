#!/usr/bin/env dotnet

/*
 *  The record keyword is a modifier you apply to either a class or a struct. It tells 
 *  the compiler to generate value equality, a formatted ToString, and nondestructive 
 *  mutation through with expressions
 *
 *  Use a record when all of the following conditions are true:
 *
 *    - The type's primary role is storing data
 *    - Two instances with the same values should be equal
 *    - You want immutability (especially for record class types)
 *    - You want a readable ToString without writing one manually
 *
 */

//--------------
// Record class

// Note: Writing record alone is shorthand for record class which is a reference type,
//       for example: `public record Person(string Name, int Age);`

// Note: Properties are init-only (immutable after construction)

// Supports inheritance and reference semantics
public record class Person(string Name, int Age);

/* 
 *  Record classes can inherit from other record classes:
 *
 *    - A record class can inherit from another record class. A record can't inherit
 *      from a regular class, and a class can't inherit from a record
 *    - Value equality checks include the run-time type, so a Person and a Student 
 *      with the same FirstName and LastName aren't considered equal
 */

public record class Employee(string Name, int Age, string Department) : Person(Name, Age)
{
    // public override string ToString() => $"{Name} ({Age}) - {Department}";
}

//---------------
// Record struct

// Lightweight, value semantics, NO inheritance

// Note: Properties are read-write by default. Add readonly (readonly record struct)
// to make them init-only

public record struct Point(int X, int Y);

class Program
{
    static void Main(string[] args)
    {
        Employee emp1 = new Employee("Alice", 30, "Engineering");
        
        // Inherited ToString() and value-based formatting out of the box:
        Console.WriteLine(emp1); 
        // Output: Employee { Name = Alice, Age = 30, Department = Engineering }

        Point pt1 = new Point(10, 20);
        Point pt2 = pt1; // Creates a completely independent copy of the data!

        // Modify pt2 using a 'with' expression (nondestructive mutation)
        Point pt3 = pt2 with { X = 99 };

        Console.WriteLine($"Original pt1: {pt1}"); // X = 10, Y = 20
        Console.WriteLine($"Copied pt2:   {pt2}"); // X = 10, Y = 20 (Unchanged by pt3)
        Console.WriteLine($"Modified pt3: {pt3}"); // X = 99, Y = 20

        Point pointA = new Point(5, 5);
        Point pointB = new Point(5, 5);

        // Both record classes and record structs have built-in value-based equality:
        Console.WriteLine($"Are pointA and pointB equal? {pointA == pointB}"); 
        // Output: True (compared by value, even though they are distinct structs in memory)

        // Positional records and deconstruction
        //   You can use it in assignments, foreach loops, and pattern matching
        var (name, age, department) = emp1;
        Console.WriteLine($"{name} ({age}) - {department}");
    }
}
