using System.Collections;
using System.Collections.Generic;

public static class Recursion
{
    /// <summary>
    /// #############
    /// # Problem 1 #
    /// #############
    /// Using recursion, find the sum of 1^2 + 2^2 + 3^2 + ... + n^2
    /// and return it.  Remember to both express the solution 
    /// in terms of recursive call on a smaller problem and 
    /// to identify a base case (terminating case).  If the value of
    /// n <= 0, just return 0.   A loop should not be used.
    /// </summary>
    public static int SumSquaresRecursive(int n)
    {
        // TODO Start Problem 1
        if (n <= 0)
            return 0;

        return n * n + SumSquaresRecursive(n - 1);
    }

    /// <summary>
    /// #############
    /// # Problem 2 #
    /// #############
    /// Using recursion, insert permutations of length
    /// 'size' from a list of 'letters' into the results list.  This function
    /// should assume that each letter is unique (i.e. the 
    /// function does not need to find unique permutations).
    /// </summary>
    public static void PermutationsChoose(List<string> results, string letters, int size, string word = "")
    {
        // TODO Start Problem 2
        if (word.Length == size)
        {
            results.Add(word);
            return;
        }

        foreach (char c in letters)
        {
            if (!word.Contains(c))
            {
                PermutationsChoose(results, letters, size, word + c);
            }
        }
    }

    /// <summary>
    /// #############
    /// # Problem 3 #
    /// #############
    /// </summary>
    public static decimal CountWaysToClimb(int s, Dictionary<int, decimal>? remember = null)
    {
        // Base Cases
        if (s == 0)
            return 0;
        if (s == 1)
            return 1;
        if (s == 2)
            return 2;
        if (s == 3)
            return 4;

        // TODO Start Problem 3
        if (remember == null)
        {
            remember = new Dictionary<int, decimal>();
        }

        if (remember.ContainsKey(s))
        {
            return remember[s];
        }

        decimal ways = CountWaysToClimb(s - 1, remember)
                     + CountWaysToClimb(s - 2, remember)
                     + CountWaysToClimb(s - 3, remember);

        remember[s] = ways;
        return ways;
    }

    /// <summary>
    /// #############
    /// # Problem 4 #
    /// #############
    /// </summary>
    public static void WildcardBinary(string pattern, List<string> results)
    {
        // TODO Start Problem 4
        int index = pattern.IndexOf('*');

        if (index == -1)
        {
            results.Add(pattern);
            return;
        }

        string withZero = pattern.Substring(0, index) + "0" + pattern.Substring(index + 1);
        string withOne = pattern.Substring(0, index) + "1" + pattern.Substring(index + 1);

        WildcardBinary(withZero, results);
        WildcardBinary(withOne, results);
    }

    /// <summary>
    /// Use recursion to insert all paths that start at (0,0) and end at the
    /// 'end' square into the results list.
    /// </summary>
    public static void SolveMaze(List<string> results, Maze maze, int x = 0, int y = 0, List<ValueTuple<int, int>>? currPath = null)
    {
        // If this is the first time running the function, then we need
        // to initialize the currPath list.
        if (currPath == null) {
            currPath = new List<ValueTuple<int, int>>();
        }
        
        // currPath.Add((1,2)); // Use this syntax to add to the current path

        // TODO Start Problem 5
        currPath.Add((x, y));

        if (maze.IsEnd(x, y))
        {
            results.Add(currPath.AsString());
            currPath.RemoveAt(currPath.Count - 1);
            return;
        }

        int[,] directions = new int[,]
        {
            {1, 0},   // down
            {0, 1},   // right
            {-1, 0},  // up
            {0, -1}   // left
        };

        for (int i = 0; i < 4; i++)
        {
            int newX = x + directions[i, 0];
            int newY = y + directions[i, 1];

            if (maze.IsValidMove(currPath, newX, newY))
            {
                SolveMaze(results, maze, newX, newY, currPath);
            }
        }

        currPath.RemoveAt(currPath.Count - 1);

        // results.Add(currPath.AsString()); // Use this to add your path to the results array keeping track of complete maze solutions when you find the solution.
    }
}