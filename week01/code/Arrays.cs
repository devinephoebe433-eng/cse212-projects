using System;
using System.Collections.Generic;

public static class Arrays
{
    // FIXED: return type and parameter type
    public static double[] MultiplesOf(double start, int count)
    {
        double[] result = new double[count];

        for (int i = 0; i < count; i++)
        {
            result[i] = start * (i + 1);
        }

        return result;
    }

    // FIXED: correct method name
    public static void RotateListRight(List<int> list, int rotations)
    {
        int n = list.Count;

        // Handle rotations bigger than list size
        rotations = rotations % n;

        for (int i = 0; i < rotations; i++)
        {
            int last = list[n - 1];
            list.RemoveAt(n - 1);
            list.Insert(0, last);
        }
    }
}