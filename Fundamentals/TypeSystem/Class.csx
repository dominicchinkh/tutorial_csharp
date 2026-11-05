#!/usr/bin/env dotnet

var c1 = new Customer("Grace");
var c2 = c1; // Both variables reference the same object

c2.Name = "Hopper";
Console.WriteLine(c1.Name); // Hopper — c1 sees the change made through c2

// var missing = new Person(); // Error: required properties not set
var person = new Person { FirstName = "Grace", LastName = "Hopper" };
Console.WriteLine($"{person.FirstName} {person.LastName}"); // Grace Hopper

double circumference = MathHelpers.CircleCircumference(5.0);
Console.WriteLine($"Circumference: {circumference:F2}"); // Circumference: 31.42

var options = new ConnectionOptions
{
    Host = "db.example.com",
    Port = 5432,
    UseSsl = true
};
Console.WriteLine($"{options.Host}:{options.Port} (SSL: {options.UseSsl})");
// db.example.com:5432 (SSL: True)

// An optional access modifier controls visibility. The default is internal. Specify 
// public to allow callers from other assemblies to use your types

public class Customer
{
    public string Name { get; set; }

    public Customer(string name) => Name = name;
}

public class Person
{
    // Required properties enforce that callers set specific properties through an 
    // object initializer:
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
}

public class Container
{
    // Field initializers set a default value directly on the field declaration:
    private int _capacity = 10;

    // Constructor parameters require callers to provide values:
    public Container(int capacity) => _capacity = capacity;


}

// A static class can't be instantiated and contains only static members. Use static 
// classes to organize utility methods that don't operate on instance data

// Note: A static class is implicitly sealed. You can't derive from it or instantiate it

static class MathHelpers
{
    public static double CircleCircumference(double radius) =>
        2 * Math.PI * radius;
}

// Object initializers let you set properties when you create an object, without writing
// a constructor for every combination of values:

class ConnectionOptions
{
    // init is an accessor that creates an immutable-after-construction property
    public string Host { get; init; } = "localhost";
    public int Port { get; init; } = 80;
    public bool UseSsl { get; init; }
}
