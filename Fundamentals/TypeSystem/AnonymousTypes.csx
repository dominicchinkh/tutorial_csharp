#!/usr/bin/env dotnet

// Anonymous types encapsulate a set of read-only properties into a single object 
// without defining a named type first

// For most new code, consider using tuples instead of anonymous types. As value types, 
// tuples provide better performance. They also provide deconstruction support and more 
// flexible syntax. Anonymous types remain the better choice when you need expression 
// tree support or reference-type semantics

// Because the compiler generates the type name and you can't access it in source 
// code, you must use var to declare the local variable
var person = new { Name = "Alice", Age = 30 };
Console.WriteLine($"{person.Name} is {person.Age} years old.");
// Output:
// Alice is 30 years old.

//-------------------------
// Inferred property names

string productName = "Laptop";
decimal price = 999.99m;
var product = new { productName, price };
Console.WriteLine($"{product.productName}: {product.price:C}");
// Output:
// Laptop: $999.99

//-------------------------------------
// Use anonymous types in LINQ queries

var words = new[] { "apple", "blueberry", "cherry" };

var results = words.Select(w => new { Word = w, Length = w.Length });

foreach (var item in results)
{
    Console.WriteLine($"{item.Word} has {item.Length} letters.");
}
// Output:
// apple has 5 letters.
// blueberry has 9 letters.
// cherry has 6 letters.

//----------
// Equality

// Two anonymous type instances that have the same property names and types in the
// same order share the same compiler-generated type

var a = new { Name = "Alice", Age = 30 };
var b = new { Name = "Alice", Age = 30 };
var c = new { Age = 30, Name = "Alice" };
var d = new { Name = "Bob", Age = 25 };

Console.WriteLine(a.Equals(b));  // True
Console.WriteLine(a.Equals(c));  // False
Console.WriteLine(a.Equals(d));  // False

//------------------------
// Nested anonymous types

var order = new
{
    OrderId = 1,
    Customer = new { Name = "Alice", City = "Seattle" },
    Total = 150.00m
};
Console.WriteLine($"Order {order.OrderId} for {order.Customer.Name} in {order.Customer.City}");
// Output:
// Order 1 for Alice in Seattle

