#!/usr/bin/env dotnet

// The minimum and maximum limits
{
    int max = int.MaxValue;
    int min = int.MinValue;
    Console.WriteLine($"The range of integers is {min} to {max}");
}

{
    double max = double.MaxValue;
    double min = double.MinValue;
    Console.WriteLine($"The range of double is {min} to {max}");
}

{
    decimal min = decimal.MinValue;
    decimal max = decimal.MaxValue;
    Console.WriteLine($"The range of the decimal type is {min} to {max}");

    // The M suffix on the numbers indicates that a constant should use the decimal 
    // type. Otherwise, the compiler assumes the double type
    
    decimal c = 1.0M;
    decimal d = 3.0M;
    Console.WriteLine(c / d);
}
