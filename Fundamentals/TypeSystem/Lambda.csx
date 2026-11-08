#!/usr/bin/env dotnet

//--------
// Lambda

// A lambda expression is a compact, inline function that you write without giving
// it a name. You use the arrow operator => to separate the parameter list from the 
// body:

Func<int, int> func = x => x * 2;
Console.WriteLine(func(5));

//----------
// Delegate

// A delegate type is a type that represents a method signature. A variable of a 
// delegate type can hold any matching method such as a lambda expression or a named 
// method, as long as its parameter types and return type match

Transform doubler = x => x * 2;    // assign a lambda expression
Transform squarer = Square;         // assign a named method

Console.WriteLine(doubler(5));      // 10
Console.WriteLine(squarer(5));      // 25

static int Square(int value) => value * value;

//-----------------
// Func and Action

/*
 *  System.Func<T,TResult> (and Func<T1, T2, TResult>, and so on):
 *    Represent a method that returns a value. The last type parameter is always 
 *    the return type; all earlier ones are input types
 *
 *  System.Action<T> (and Action<T1, T2>, and so on):
 *    Represent a method that returns nothing (void). All type parameters are input 
 *    types. System.Action with no type parameters represents a method with no inputs 
 *    and no return value
 */

Func<int, int, int> add = (left, right) => left + right;
Action<string> report = message => Console.WriteLine($"Report: {message}");

int total = add(5, 9);
report($"5 + 9 = {total}");

//--------------------------------------
// Pass a lambda expression to a method

int[] Filter(int[] numbers, Func<int, bool> predicate)
{
    return numbers.Where(predicate).ToArray();
}

int[] numbers = [1, 2, 3, 4, 5, 6];
int[] evenNumbers = Filter(numbers, value => value % 2 == 0).ToArray();

Console.WriteLine(string.Join(", ", evenNumbers));

//----------------------------------------
// Keep lambda expressions self-contained

// A lambda expression can reference variables from the surrounding code. Capturing 
// means the lambda holds a reference to a variable declared outside its own body. 
// The combination of the lambda and the variables it captures is called a closure

// When you don't need to capture anything, add the static modifier to the lambda

Func<int, bool> isEven = static value => value % 2 == 0;

Console.WriteLine(isEven(14));
Console.WriteLine(isEven(15));

//---------------------------------------------------
// Use discard parameters when inputs are irrelevant

// Sometimes a delegate signature includes parameters you don't need. Use the discard 
// _ to signal that choice explicitly

Action<int, int, string> statusUpdate = (_, _, message) => Console.WriteLine(message);
statusUpdate(200, 42, "Operation completed");

//---------------------------------------
// Events provide optional notifications

/*
 *  Events are built on delegates. An event is a delegate field with extra restrictions 
 *  enforced by the event keyword: 
 *
 *    - Outside code can only subscribe (+=) or unsubscribe (-=) from the event
 *    - Only the class that declares the event can invoke (raise) it
 */

MessagePublisher publisher = new();
publisher.MessagePublished += (_, message) => Console.WriteLine($"Subscriber 1 received: {message}");
publisher.MessagePublished += (_, message) => Console.WriteLine($"Subscriber 2 received: {message}");

publisher.Publish("Records updated");

public sealed class MessagePublisher
{
    /*
     *  Note: this code fully supports multiple subscribers
     *
     *  When you use the += operator to subscribe to an event, C# adds your handler 
     *  to an internal invocation list rather than replacing existing ones
     *
     *  When MessagePublished?.Invoke(...) is called, it iterates through that list 
     *  and invokes every registered handler sequentially
     */

    public event EventHandler<string>? MessagePublished;

    public void Publish(string message) => MessagePublished?.Invoke(this, message);
}

//----------

delegate int Transform(int value);
