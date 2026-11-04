#!/usr/bin/env dotnet

/*
 *  Execute your file-based app as normal:
 *    dotnet Main.csx --verbose
 *
 *  Check the return value
 *    echo $?
 */

class Program
{
    static async Task<int> Main(string[] args)
    {
        // args[0] is "--verbose"
        Console.WriteLine($"First arg: {args[0]}"); 

        // Environment.GetCommandLineArgs()[0] is the path to the program
        string exePath = Environment.GetCommandLineArgs()[0];
        Console.WriteLine($"Program path: {exePath}");

        return await AsyncConsoleWork();
    }

    private static async Task<int> AsyncConsoleWork()
    {
        return 1;
    }
}

/*
 *  The following list shows permutations of Main declarations:
 *
 *    static void            Main() { }
 *    static int             Main() { }
 *    static void            Main(string[] args) { }
 *    static int             Main(string[] args) { }
 *    static async Task      Main() { }
 *    static async Task<int> Main() { }
 *    static async Task      Main(string[] args) { }
 *    static async Task<int> Main(string[] args) { }
 *
 */
