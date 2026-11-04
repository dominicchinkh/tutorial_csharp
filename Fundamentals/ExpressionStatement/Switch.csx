#!/usr/bin/env dotnet

Console.WriteLine(GetGreeting("dominic", 2));

static string GetGreeting(string name, int visitCount)
{
    return visitCount switch
    {
        1 => $"Welcome, {name}!",
        _ => $"Welcome back, {name}! Visit #{visitCount}."
    };
}
