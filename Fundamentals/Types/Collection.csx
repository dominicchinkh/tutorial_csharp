#!/usr/bin/env dotnet

int[] numbers = [1, 2, 3, 4, 5, 6, 7, 8, 9, 10];
List<string> names = ["Alice", "Bob", "Charlie", "David"];

IEnumerable<int> moreNumbers = [.. numbers, 11, 12, 13];
IEnumerable<string> empty = [];

string second = names[1];           // 0-based index
string last = names[^1];            // ^1 is the last element
int[] smallNumbers = numbers[0..5]; // elements at indexes 0 to 4
