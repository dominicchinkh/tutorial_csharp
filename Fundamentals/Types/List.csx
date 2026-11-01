#!/usr/bin/env dotnet

List<string> names = ["<name>", "Ana", "Felipe"];

names.Add("Bill");
names.Remove("Ana");

foreach (var name in names)
{
    Console.WriteLine($"Hello {name.ToUpper()}!");
}

Console.WriteLine($"My name is {names[1]}.");
Console.WriteLine($"The list has {names.Count} people in it");
