using System;
using System.Collections.Generic;

public class ReferenceCode
{
    public static bool IsPrime(long p)
        {
            if (p < 2)
            {
                return false;
            }
            for (long k = 2; k * k <= p; k++)
            {
                if (p % k == 0)
                {
                    return false;
                }
            }
            return true;
        }
    public static long Puzzle(int n)
    {
        

        List<long> f = new List<long> { 0, 1 };
        while (true)
        {
            f.Add(f[f.Count - 1] + f[f.Count - 2]);
            if (IsPrime(f[f.Count - 1]))
            {
                n--;
            }
            if (n == 0)
            {
                return f[f.Count - 1];
            }
        }
    }
}