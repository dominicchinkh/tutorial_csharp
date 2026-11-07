#!/usr/bin/env dotnet

// A dictionary mapping string keys to int values
var inventory = new Dictionary<string, int>
{
    ["Apples"] = 50,
    ["Oranges"] = 30
};
inventory["Bananas"] = 25;

foreach (var (fruit, stock) in inventory)
{
    Console.WriteLine($"{fruit}: {stock}");
}

// You can merge dictionaries by copying one and applying overrides

Dictionary<string, int> defaults = new()
{
    ["Timeout"] = 30,
    ["Retries"] = 3
};

Dictionary<string, int> overrides = new()
{
    ["Timeout"] = 60
};

// Merge defaults and overrides into a new dictionary
Dictionary<string, int> config = new(defaults);
foreach (var (key, value) in overrides)
{
    config[key] = value;
}

Console.WriteLine($"Timeout: {config["Timeout"]}");  // 60
Console.WriteLine($"Retries: {config["Retries"]}");   // 3
