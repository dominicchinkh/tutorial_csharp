#!/usr/bin/env dotnet

int[] numbers = [1, 2, 3, 4, 5, 6, 7, 8, 9, 10];
List<string> names = ["Alice", "Bob", "Charlie", "David"];
names.Add("Dominic");

IEnumerable<int> moreNumbers = [.. numbers, 11, 12, 13];
IEnumerable<string> empty = [];

string second = names[1];           // 0-based index
string last = names[^1];            // ^1 is the last element
int[] smallNumbers = numbers[0..5]; // elements at indexes 0 to 4

// A set that prevents duplicates
HashSet<int> uniqueIds = [1, 2, 3, 1, 2];
Console.WriteLine($"Unique count: {uniqueIds.Count}"); // 3

// A FIFO queue
Queue<string> tasks = new();
tasks.Enqueue("Build");
tasks.Enqueue("Test");
Console.WriteLine($"Next task: {tasks.Dequeue()}"); // Build
