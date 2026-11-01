#!/usr/bin/env dotnet

var pt1 = new Point(1, 1);

// Records support `with` expressions
var pt2 = pt1 with { Y = 10 };
Console.WriteLine($"The two points are {pt1} and {pt2}");

double slopeResult = pt2.Slope();
Console.WriteLine($"The slope of {pt2} is {slopeResult}");

// CS8803: Top-level statements must precede namespace and type declarations

// public record Point(int X, int Y);

public record Point(int X, int Y) {
    public double Slope() => (double)Y / (double)X;
}
