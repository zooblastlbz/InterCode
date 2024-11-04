using System;
using System.Collections.Generic;

public class ReferenceCode
{
    public static int[] Puzzle(int n)
    {
        List<int> ret = new List<int>();
        for (int i = 1; i <= n; i++)
        {
            if (i % 2 == 0)
            {
                int x = 1;
                for (int j = 1; j <= i; j++)
                {
                    x *= j;
                }
                ret.Add(x);
            }
            else
            {
                int x = 0;
                for (int j = 1; j <= i; j++)
                {
                    x += j;
                }
                ret.Add(x);
            }
        }
        return ret.ToArray();
    }
}