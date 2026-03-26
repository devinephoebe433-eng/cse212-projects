// ==========================================
// W03: Sets and Maps Assignment
// Name: Nabugobero Devine Phoebe
// ==========================================

using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        // Problem 1 Test
        Console.WriteLine("Problem 1:");
        var pair = FindPairs(new int[] { 2, 7, 11, 15 }, 9);
        Console.WriteLine(string.Join(", ", pair));

        // Problem 2 Test
        Console.WriteLine("\nProblem 2:");
        var summary = DegreeSummary(new int[] { 1, 2, 2, 3, 3, 3 });
        foreach (var item in summary)
        {
            Console.WriteLine($"{item.Key}: {item.Value}");
        }

        // Problem 3 Test
        Console.WriteLine("\nProblem 3:");
        var anagrams = GroupAnagrams(new string[] { "eat", "tea", "tan", "ate", "nat", "bat" });
        foreach (var group in anagrams)
        {
            Console.WriteLine(string.Join(", ", group));
        }

        // Problem 4 Test
        Console.WriteLine("\nProblem 4:");
        int[,] maze = {
            {0, 1, 0},
            {0, 0, 0},
            {1, 0, 1}
        };
        Console.WriteLine(CanExitMaze(maze, (0, 0), (1, 2)));

        // Problem 5 Test
        Console.WriteLine("\nProblem 5:");
        var earthquakeData = new List<string> { "California", "Alaska", "California" };
        var result = EarthquakeSummary(earthquakeData);
        foreach (var item in result)
        {
            Console.WriteLine($"{item.Key}: {item.Value}");
        }
    }


    // ------------------------------
    // Problem 1: Finding Pairs
    // ------------------------------
    static int[] FindPairs(int[] numbers, int target)
    {
        HashSet<int> seen = new HashSet<int>();

        foreach (int num in numbers)
        {
            int needed = target - num;

            if (seen.Contains(needed))
            {
                return new int[] { needed, num };
            }

            seen.Add(num);
        }

        return new int[] { };
    }


    // ------------------------------
    // Problem 2: Degree Summary
    // ------------------------------
    static Dictionary<int, int> DegreeSummary(int[] numbers)
    {
        Dictionary<int, int> map = new Dictionary<int, int>();

        foreach (int num in numbers)
        {
            if (map.ContainsKey(num))
            {
                map[num]++;
            }
            else
            {
                map[num] = 1;
            }
        }

        return map;
    }


    // ------------------------------
    // Problem 3: Anagrams
    // ------------------------------
    static List<List<string>> GroupAnagrams(string[] words)
    {
        Dictionary<string, List<string>> map = new Dictionary<string, List<string>>();

        foreach (string word in words)
        {
            char[] chars = word.ToCharArray();
            Array.Sort(chars);
            string key = new string(chars);

            if (!map.ContainsKey(key))
            {
                map[key] = new List<string>();
            }

            map[key].Add(word);
        }

        return map.Values.ToList();
    }


    // ------------------------------
    // Problem 4: Maze
    // ------------------------------
    static bool CanExitMaze(int[,] maze, (int, int) start, (int, int) end)
    {
        int rows = maze.GetLength(0);
        int cols = maze.GetLength(1);

        Queue<(int, int)> queue = new Queue<(int, int)>();
        HashSet<string> visited = new HashSet<string>();

        queue.Enqueue(start);

        int[][] directions = new int[][]
        {
            new int[] {0, 1},
            new int[] {1, 0},
            new int[] {0, -1},
            new int[] {-1, 0}
        };

        while (queue.Count > 0)
        {
            var (r, c) = queue.Dequeue();

            if (r == end.Item1 && c == end.Item2)
                return true;

            string key = $"{r},{c}";
            if (visited.Contains(key)) continue;

            visited.Add(key);

            foreach (var d in directions)
            {
                int nr = r + d[0];
                int nc = c + d[1];

                if (nr >= 0 && nc >= 0 && nr < rows && nc < cols && maze[nr, nc] == 0)
                {
                    queue.Enqueue((nr, nc));
                }
            }
        }

        return false;
    }


    // ------------------------------
    // Problem 5: Earthquake Summary
    // ------------------------------
    static Dictionary<string, int> EarthquakeSummary(List<string> places)
    {
        Dictionary<string, int> map = new Dictionary<string, int>();

        foreach (string place in places)
        {
            if (map.ContainsKey(place))
            {
                map[place]++;
            }
            else
            {
                map[place] = 1;
            }
        }

        return map;
    }
}