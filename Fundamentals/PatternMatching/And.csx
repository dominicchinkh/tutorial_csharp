#!/usr/bin/env dotnet

static bool And(bool left, bool right) =>
(left, right) switch
{
    (true, true) => true,
    (_, _) => false,
};

Console.WriteLine(And(true, true));  // Outputs: True
Console.WriteLine(And(true, false)); // Outputs: False
