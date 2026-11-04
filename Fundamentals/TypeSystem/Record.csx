#!/usr/bin/env dotnet

using System;

//--------------
// Record class

// Supports inheritance and reference semantics
public record class Person(string Name, int Age);

// Record classes can inherit from other record classes:
public record class Employee(string Name, int Age, string Department) : Person(Name, Age);

//---------------
// Record struct

// Lightweight, value semantics, NO inheritance
public record struct Point(int X, int Y);


class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("=== 1. RECORD CLASS & INHERITANCE ===");
        Employee emp1 = new Employee("Alice", 30, "Engineering");
        
        // Inherited ToString() and value-based formatting out of the box:
        Console.WriteLine(emp1); 
        // Output: Employee { Name = Alice, Age = 30, Department = Engineering }

        Console.WriteLine("\n=== 2. RECORD STRUCT & VALUE SEMANTICS ===");
        Point pt1 = new Point(10, 20);
        Point pt2 = pt1; // Creates a completely independent copy of the data!

        // Modify pt2 using a 'with' expression (nondestructive mutation)
        Point pt3 = pt2 with { X = 99 };

        Console.WriteLine($"Original pt1: {pt1}"); // X = 10, Y = 20
        Console.WriteLine($"Copied pt2:   {pt2}"); // X = 10, Y = 20 (Unchanged by pt3)
        Console.WriteLine($"Modified pt3: {pt3}"); // X = 99, Y = 20


        Console.WriteLine("\n=== 3. EQUALITY COMPARISON ===");
        Point pointA = new Point(5, 5);
        Point pointB = new Point(5, 5);

        // Both record classes and record structs have built-in value-based equality:
        Console.WriteLine($"Are pointA and pointB equal? {pointA == pointB}"); 
        // Output: True (compared by value, even though they are distinct structs in memory)
    }
}
