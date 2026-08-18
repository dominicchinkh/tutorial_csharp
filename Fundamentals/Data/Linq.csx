#!/usr/bin/env dotnet

// Note: Top-level statements must precede namespace and type declarations

// 2. Define "Students" as a queryable collection (e.g., List or Array)
List<Student> Students = [
    new("Alice",   3.8),
    new("Bob",     3.2),
    new("Charlie", 3.9),
    new("David",   2.8)
];

// 3. Your LINQ query
var honorRoll = from student in Students
                where student.GPA > 3.5
                select student;

// Display the results
foreach (var student in honorRoll)
{
    Console.WriteLine($"{student.Name}: {student.GPA}");
}

// 1. Define the model with a GPA property
record Student(string Name, double GPA);
