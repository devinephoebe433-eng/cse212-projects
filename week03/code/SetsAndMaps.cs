using System;
using System.Collections.Generic;
using System.Linq;

public class SetsAndMaps
{
    // ------------------------------
    // Problem 1: Finding Pairs
    // ------------------------------
    public static int[] FindPairs(int[] numbers, int target)
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
    public static Dictionary<int, int> DegreeSummary(int[] numbers)
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
    // Problem 3: Group Anagrams
    // ------------------------------
    public static List<List<string>> GroupAnagrams(string[] words)
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
    public static bool CanExitMaze(int[,] maze, (int,int) start, (int,int) end)
    {
        int rows = maze.GetLength(0);
        int cols = maze.GetLength(1);

        Queue<(int,int)> queue = new Queue<(int,int)>();
        HashSet<string> visited = new HashSet<string>();

        queue.Enqueue(start);

        int[][] directions = new int[][]
        {
            new int[] {0,1},
            new int[] {1,0},
            new int[] {0,-1},
            new int[] {-1,0}
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

                if (nr >= 0 && nc >= 0 && nr < rows && nc < cols && maze[nr,nc] == 0)
                {
                    queue.Enqueue((nr,nc));
                }
            }
        }

        return false;
    }

    // ------------------------------
    // Problem 5: Earthquake Summary
    // ------------------------------
    public static Dictionary<string,int> EarthquakeSummary(List<string> places)
    {
        Dictionary<string,int> map = new Dictionary<string,int>();

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