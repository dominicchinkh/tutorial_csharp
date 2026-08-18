#!/usr/bin/env dotnet

// 1. Top-level execution code FIRST
await foreach (var number in ReadSequence())
{
    Console.WriteLine(number);
}

// 2. Async stream method
static async IAsyncEnumerable<int> ReadSequence()
{
    int index = 0;
    while (index < 100)
    {
        int[] nextChunk = await GetNextChunk(index);
        if (nextChunk.Length == 0)
        {
            yield break;
        }
        foreach (var item in nextChunk)
        {
            yield return item;
        }
        index++;
    }
}

// 3. Helper function supplying the chunks (simulates async data fetching)
static async Task<int[]> GetNextChunk(int index)
{
    await Task.Delay(1000); // Simulate async operation (e.g. database/API call)

    // Stop fetching chunks after index reaches 3 for demonstration
    if (index >= 3)
    {
        return [];
    }

    // Return a chunk of numbers
    return [index * 10 + 1, index * 10 + 2, index * 10 + 3];
}
