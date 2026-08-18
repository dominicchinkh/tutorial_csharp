#!/usr/bin/env dotnet

// The Task based asynchronous programming model enables you to write code that reads 
// as though it runs synchronously, even though it runs asynchronously

// 1. Executable top-level logic
string url = "https://example.com";

Console.WriteLine($"Fetching content length for: {url}...");
int length = await GetPageLengthAsync(url);
Console.WriteLine($"Page length: {length} bytes");

// 2. Async local function (must sit below or alongside top-level code)
static async Task<int> GetPageLengthAsync(string endpoint)
{
    using var client = new HttpClient();
    byte[] content = await client.GetByteArrayAsync(endpoint);
    return content.Length;
}
