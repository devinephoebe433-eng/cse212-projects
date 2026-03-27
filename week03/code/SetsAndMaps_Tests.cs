using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        Console.WriteLine("==== W03: Sets and Maps Assignment ====\n");
        
        // ------------------------------
        // Problem 1: Finding Pairs
        // ------------------------------
        Console.WriteLine("Problem 1: FindPairs");
        var pair = SetsAndMaps.FindPairs(new int[] { 2, 7, 11, 15 }, 9);
        Console.WriteLine("Result: " + string.Join(", ", pair));
        
        // ------------------------------
        // Problem 2: Degree Summary
        // ------------------------------
        Console.WriteLine("\nProblem 2: DegreeSummary");
        var summary = SetsAndMaps.DegreeSummary(new int[] { 1, 2, 2, 3, 3, 3 });
        foreach (var item in summary)
        {
            Console.WriteLine($"{item.Key}: {item.Value}");
        }

        // ------------------------------
        // Problem 3: Group Anagrams
        // ------------------------------
        Console.WriteLine("\nProblem 3: GroupAnagrams");
        var anagrams = SetsAndMaps.GroupAnagrams(new string[] { "eat", "tea", "tan", "ate", "nat", "bat" });
        foreach (var group in anagrams)
        {
            Console.WriteLine(string.Join(", ", group));
        }

        // ------------------------------
        // Problem 4: Maze Exit
        // ------------------------------
        Console.WriteLine("\nProblem 4: CanExitMaze");
        int[,] maze = {
            {0, 1, 0},
            {0, 0, 0},
            {1, 0, 1}
        };
        bool canExit = SetsAndMaps.CanExitMaze(maze, (0, 0), (1, 2));
        Console.WriteLine("Can exit maze: " + canExit);

        // ------------------------------
        // Problem 5: Earthquake Summary
        // ------------------------------
        Console.WriteLine("\nProblem 5: EarthquakeSummary");
        var earthquakeData = new List<string> { "California", "Alaska", "California" };
        var result = SetsAndMaps.EarthquakeSummary(earthquakeData);
        foreach (var item in result)
        {
            Console.WriteLine($"{item.Key}: {item.Value}");
        }

        Console.WriteLine("\n==== End of Program ====");
    }
}