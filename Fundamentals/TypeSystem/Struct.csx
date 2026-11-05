#!/usr/bin/env dotnet

/*
 *  Use a struct when your type:
 *
 *    - Represents a single value or a small group of related values (roughly 16 
 *      bytes or less)
 *    - Has value semantics—two instances with the same data should be equal
 *    - Is primarily a data container rather than a model of behavior
 *    - Doesn't need inheritance from a base type (structs can't inherit from other 
 *      structs or classes, but they can implement interfaces)
 */

// Note: Supports value equality through ValueType.Equals because all structs inherit
//       from System.ValueType. But the default implementation uses reflection. 
//       Reflection means the program has to dynamically inspect the struct's layout, 
//       look up its fields, and compare them one by one while the code is running, 
//       which is slower. The default implementation doesn't generate ==/!= operators

var p1 = new Point { X = 3, Y = 4 };
var p2 = p1; // copies the data
p2.X = 10;

Console.WriteLine(p1); // (3, 4)  — p1 is unchanged
Console.WriteLine(p2); // (10, 4) — only p2 was modified

var custom = new ConnectionSettings();
Console.WriteLine($"{custom.Host}:{custom.Port} (retries: {custom.MaxRetries})");
// localhost:8080 (retries: 3)

// A parameterless constructor runs when you use new with no arguments. The default
// expression bypasses the constructor and sets all fields to their default values 
// (0, null, false). Be aware of the difference:
var defaults = default(ConnectionSettings);
Console.WriteLine($"{defaults.Host ?? "(null)"}:{defaults.Port} (retries: {defaults.MaxRetries})");
// (null):0 (retries: 0)

var tile = new GameTile(2, 5);
Console.WriteLine($"Tile ({tile.Row}, {tile.Column}), blocked: {tile.IsBlocked}");
// Tile (2, 5), blocked: False

var temp = new Temperature(100);
Console.WriteLine(temp); // 100.0°C (212.0°F)
// temp.Celsius = 50; // Error: property is read-only

struct Point
{
    public double X { get; set; }
    public double Y { get; set; }

    // DistanceTo method is marked readonly because it doesn't modify the struct's state
    public readonly double DistanceTo(Point other)
    {
        var dx = X - other.X;
        var dy = Y - other.Y;
        return Math.Sqrt(dx * dx + dy * dy);
    }

    public override string ToString() => $"({X}, {Y})";
}

struct ConnectionSettings
{
    public string Host { get; set; }
    public int Port { get; set; }
    public int MaxRetries { get; set; }

    // Parameterless constructors that set custom default values
    public ConnectionSettings()
    {
        Host = "localhost";
        Port = 8080;
        MaxRetries = 3;
    }
}

// The compiler automatically initializes any fields you don't explicitly set in 
// a constructor
struct GameTile
{
    public int Row { get; set; }
    public int Column { get; set; }
    public bool IsBlocked { get; set; }

    public GameTile(int row, int column)
    {
        Row = row;
        Column = column;
        // IsBlocked is automatically initialized to false
    }
}

// A readonly struct guarantees that no instance member modifies the struct's state
readonly struct Temperature
{
    public double Celsius { get; }

    public Temperature(double celsius) => Celsius = celsius;

    public double Fahrenheit => Celsius * 9.0 / 5.0 + 32.0;

    public override string ToString() => $"{Celsius:F1}°C ({Fahrenheit:F1}°F)";
}

// When you don't need the entire struct to be immutable, mark individual members as 
// readonly instead
struct Velocity
{
    public double X
    {
        readonly get;
        set;
    }

    public double Y
    {
        readonly get;
        set;
    }

    public readonly double Speed => Math.Sqrt(X * X + Y * Y);

    public readonly override string ToString() => $"({X}, {Y}) speed={Speed:F2}";
}
