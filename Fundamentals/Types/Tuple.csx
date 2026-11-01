#!/usr/bin/env dotnet

var pt = (X: 1, Y: 2);

var slope = (double)pt.Y / (double)pt.X;
Console.WriteLine($"A line from the origin to the point {pt} has a slope of {slope}.");

// Create a new tuple that's a modified copy of the original using a with expression
var pt2 = pt with { Y = 10 };
Console.WriteLine($"The point 'pt2' is at {pt2}.");

// A tuple type is defined by the number of members, referred to as arity, and the types
// of those members. The member names are for convenience. You can assign a tuple to a 
// tuple with the same arity and types even if the members have different names
var subscript = (A: 0, B: 0);
subscript = pt;
Console.WriteLine(subscript);

