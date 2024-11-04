using System;
using System.Collections.Generic;

public class ReferenceCode
{
    public static int[] Puzzle(int n)
    {
        int[] result = new int[n];
        for (int i = 0; i < n; i++)
        {
            result[i] = n + 2 * i;
        }
        return result;
    }
}