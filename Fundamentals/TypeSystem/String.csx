#!/usr/bin/env dotnet

{
    // String interpolation
    string aFriend = "Maria";
    Console.WriteLine($"Hello {aFriend}");

    // String length
    Console.WriteLine($"The name {aFriend} has {aFriend.Length} letters.");
}

// Remove whitespace from strings
{
    string greeting = "      Hello World!       ";
    Console.WriteLine($"[{greeting}]");

    string trimmedGreeting = greeting.TrimStart();
    Console.WriteLine($"[{trimmedGreeting}]");

    trimmedGreeting = greeting.TrimEnd();
    Console.WriteLine($"[{trimmedGreeting}]");

    trimmedGreeting = greeting.Trim();
    Console.WriteLine($"[{trimmedGreeting}]");
}

{
    // Search and replace text in strings
    string sayHello = "Hello World!";
    Console.WriteLine(sayHello);
    sayHello = sayHello.Replace("Hello", "Greetings");
    Console.WriteLine(sayHello);

    // To upper/lower case
    Console.WriteLine(sayHello.ToUpper());
    Console.WriteLine(sayHello.ToLower());
}

// Find text in a string
{
    string songLyrics = "You say goodbye, and I say hello";
    Console.WriteLine(songLyrics.Contains("goodbye"));
    Console.WriteLine(songLyrics.Contains("greetings"));
}
