#!/usr/bin/env dotnet

{
    List<int> scores = [95, 87, 72, 91];

    Dictionary<string, decimal> prices = new()
    {
        ["Widget"] = 19.99m,
        ["Gadget"] = 29.99m
    };

    Task<string> greeting = Task.FromResult("Hello, generics!");

    Func<int, bool> isPositive = n => n > 0;

    Console.WriteLine($"First score: {scores[0]}");
    Console.WriteLine($"Widget price: {prices["Widget"]:C}");
    Console.WriteLine($"Greeting: {await greeting}");
    Console.WriteLine($"Is 5 positive? {isPositive(5)}");
}

//-----------------
// Generic methods

{
    static void Print<T>(T value) => Console.WriteLine($"Value: {value}");

    // The compiler often infers the type argument from the values you pass, so you
    //  don't need to specify it explicitly

    Print(42);        // Compiler infers T as int
    Print("hello");   // Compiler infers T as string
    Print(3.14);      // Compiler infers T as double
}

//------------------
// Type constraints

// Constraints restrict which type arguments a generic type or method accepts

/*
 *  The most common constraints are
 *    where T : class	    T must be a reference type
 *    where T : struct	    T must be a non-nullable value type
 *    where T : new()	    T must have a public parameterless constructor
 *    where T : BaseClass	T must derive from BaseClass
 *    where T : IInterface	T must implement IInterface
 *
 *  You can combine constraints: where T : class, IComparable<T>, new()
 */

{
    static T Max<T>(T a, T b) where T : IComparable<T> => a.CompareTo(b) >= 0 ? a : b;

    Console.WriteLine(Max(3, 7));               // 7
    Console.WriteLine(Max("apple", "banana"));  // banana

    // Restrict T so that only types possessing a public, parameterless (default) 
    // constructor can be passed in
    static T CreateDefault<T>() where T : new() => new T();

    var list = CreateDefault<List<int>>(); // Creates an empty List<int>
    Console.WriteLine($"Empty list count: {list.Count}"); // 0
}

//-------------------------------
// Covariance and contravariance

{
    // Covariance: IEnumerable<Dog> can be used as IEnumerable<Animal> because
    // IEnumerable<out T> is covariant
    List<Dog> dogs = [new("Rex"), new("Buddy")];
    IEnumerable<Animal> animals = dogs; // Allowed because Dog derives from Animal

    foreach (var animal in animals)
    {
        Console.WriteLine(animal.Name);
    }

    // Contravariance: Action<Animal> can be used as Action<Dog> because Action<in T>
    // is contravariant
    Action<Animal> printAnimal = a => Console.WriteLine($"Animal: {a.Name}");

    // Allowed because any Animal handler can handle Dog
    Action<Dog> printDog = printAnimal; 

    printDog(new Dog("Spot"));
}

//-------------------------------
// Create your own generic types

{
    var list = new GenericList<int>();
    for (var i = 0; i < 5; i++)
    {
        list.AddHead(i);
    }

    foreach (var item in list)
    {
        Console.Write($"{item} ");
    }
    Console.WriteLine();
    // Output: 4 3 2 1 0
}

internal class Animal
{
    public string Name { get; init; }

    public Animal(string name) => Name = name;
}

internal class Dog : Animal
{
    // Chain up to the base constructor using ': base(name)'
    public Dog(string name) : base(name) {}
}

public class GenericList<T>
{
    private class Node(T data)
    {
        public T Data { get; set; } = data;
        public Node? Next { get; set; }
    }

    private Node? head;

    public void AddHead(T data)
    {
        var node = new Node(data) { Next = head };
        head = node;
    }

    public IEnumerator<T> GetEnumerator()
    {
        var current = head;
        while (current is not null)
        {
            yield return current.Data;
            current = current.Next;
        }
    }
}

