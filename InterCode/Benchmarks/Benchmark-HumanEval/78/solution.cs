using System.Collections.Generic;
using System;
using System.Linq;
public class ReferenceCode
{
    public static int Puzzle(string num)
    {
        char[] primes = { '2', '3', '5', '7', 'B', 'D' };
        int total = 0;
        for (int i = 0; i < num.Length; i++)
        {
            if (primes.Contains(num[i]))
            {
                total += 1;
            }
        }
        return total;
    }
}