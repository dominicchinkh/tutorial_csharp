#!/usr/bin/env dotnet

/*
 *  An interface defines a contract: a group of related methods, properties, events, and
 *  indexers that a class or struct must implement
 *
 *  An interface can't contain instance fields, instance constructors, or finalizers 
 *
 *  Members are public by default
 */

#pragma warning disable CS0168 // Variable is declared but never used
int i;
#pragma warning restore CS0168

interface IEquatable<T>
{
    bool Equals(T obj);
}

interface ILogger
{
    void Log(string message);
    string Name { get; }
}

public class Car : IEquatable<Car>
{
    public string? Make { get; set; }
    public string? Model { get; set; }
    public string? Year { get; set; }

    public bool Equals(Car? car) =>
        car is not null &&
        (Make, Model, Year) == (car.Make, car.Model, car.Year);
}

//-------------------------
// Explicit implementation

// Explicit implementation is useful when two interfaces declare members with the 
// same name, or when you want to keep the class's public surface clean

interface IMetric
{
    double GetDistance(); // Returns meters
}

interface IImperial
{
    double GetDistance(); // Returns feet
}

public class Runway(double meters) : IMetric, IImperial
{
    // Explicit implementation for IMetric
    double IMetric.GetDistance() => meters;

    // Explicit implementation for IImperial
    double IImperial.GetDistance() => meters * 3.28084;
}

//-----------------------
// Interface inheritance

interface IDrawable
{
    void Draw();
}

interface IShape : IDrawable
{
    double Area { get; }
}

// A class that implements a derived interface must implement all members from the 
// derived interface and all of its base interfaces

public class Circle(double radius) : IShape
{
    public double Area => Math.PI * radius * radius;

    public void Draw() =>
        Console.WriteLine($"Drawing circle with area {Area:F2}");
}
