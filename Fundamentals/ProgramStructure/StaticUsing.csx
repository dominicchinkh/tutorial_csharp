#!/usr/bin/env dotnet

// A static using directive imports the static members of a type so you can call 
// them without the type name prefix
using static System.Math;

double CalculateArea(double radius) => PI * Pow(radius, 2);

double area = CalculateArea(2);
Console.WriteLine($"Area is {area}");;
