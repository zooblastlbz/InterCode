using System;
using System.Collections.Generic;

public class ReferenceCode
{
    public static int[] Puzzle(int n)
    {
        List<int> fact = new List<int>();
        int i = 2;
        while (i <= Math.Sqrt(n) + 1)
        {
            if (n % i == 0)
            {
                fact.Add(i);
                n /= i;
            }
            else
            {
                i += 1;
            }
        }

        if (n > 1)
        {
            fact.Add(n);
        }
        return fact.ToArray();
    }
}