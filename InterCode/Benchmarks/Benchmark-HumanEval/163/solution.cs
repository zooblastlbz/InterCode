using System;
using System.Collections.Generic;
using System.Linq;

public class ReferenceCode
{
    public static int[] Puzzle(int a, int b)
    {
        int lower = Math.Max(2, Math.Min(a, b));
        int upper = Math.Min(8, Math.Max(a, b));

        List<int> result = new List<int>();
        for (int i = lower; i <= upper; i++)
        {
            if (i % 2 == 0)
            {
                result.Add(i);
            }
        }
        return result.ToArray();
    }
}
