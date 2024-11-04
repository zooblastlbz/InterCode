using System;
using System.Collections.Generic;
using System.Linq;

public class ReferenceCode
{
    public static int[] Puzzle(int[] x)
    {
        List<int> oddDigitElements = new List<int>();
        foreach (int i in x)
        {
            if (i.ToString().All(c => (c - '0') % 2 == 1))
            {
                oddDigitElements.Add(i);
            }
        }
        oddDigitElements.Sort();
        return oddDigitElements.ToArray();
    }
}