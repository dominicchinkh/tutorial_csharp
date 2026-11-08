#!/usr/bin/env dotnet

//--------------------
// Convert references

Mammal otter = new() { Name = "River otter" };
Animal animal = otter;  // Derived to base class: always safe.
INamed named = otter;   // Reference type to implemented interface: always safe.
object obj = otter;     // Any reference type to object: always safe.

Console.WriteLine(named.Name);

//----------------------------------------------------------------------------
// Going from a base type back to a derived type, requires an explicit check, 
// because the object might not actually be the derived type you expect

Animal knownAnimal = new Mammal { Name = "River otter" };

// Verify whether knownAnimal is actually an instance of Mammal. If the check is true, 
// it automatically casts knownAnimal to a Mammal and assigns it to a new local variable 
// named mammal

if (knownAnimal is Mammal mammal)
{
    Console.WriteLine($"Pattern match succeeded: {mammal.Name}");
}

Animal unknownAnimal = new Reptile { Name = "Crocodile" };
Console.WriteLine($"Can treat as mammal: {unknownAnimal is Mammal}");

//------------------------------------------------------------------------
// If you need a nullable result instead of a conditional branch, use as:

object boxedMammal = new Mammal { Name = "Sea lion" };

Mammal? maybeMammal = boxedMammal as Mammal;
Console.WriteLine(maybeMammal is null ? "Not a mammal" : maybeMammal.Name);

object boxedReptile = new Reptile { Name = "Crocodile" };
Mammal? noMammal = boxedReptile as Mammal;
Console.WriteLine(noMammal is null ? "Safe null result" : noMammal.Name);

//-----------------
// Boxing/unboxing

// Boxing converts a struct or other value type to object or to an implemented 
// interface type. Unboxing extracts the value type from that object reference

int temperature = 72;
object boxedTemperature = temperature; // Boxing.
int unboxedTemperature = (int)boxedTemperature; // Unboxing.

Packet packet = new(7);
ILabelled labelledPacket = packet; // Boxing through an interface reference.

Console.WriteLine($"Unboxed: {unboxedTemperature}, Label: {labelledPacket.Label}");

interface INamed
{
    string Name { get; }
}

class Animal : INamed
{
    public required string Name { get; init; }
}

class Mammal : Animal
{
}

class Reptile : Animal
{
}

// Interface definition
interface ILabelled
{
    int Label { get; }
}

// Concrete type implementing the interface
class Packet : ILabelled
{
    public int Label { get; }

    public Packet(int label)
    {
        Label = label;
    }
}
