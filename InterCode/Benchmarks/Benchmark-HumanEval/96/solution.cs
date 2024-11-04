using System;
using System.Collections.Generic;

public class ReferenceCode
{
    public static int[] Puzzle(int n)
    {
        List<int> primes = new List<int>();
        for (int i = 2; i < n; i++)
        {
            bool isPrime = true;
            for (int j = 2; j * j <= i; j++)
            {
                if (i % j == 0)
                {
                    isPrime = false;
                    break;
                }
            }
            if (isPrime)
            {
                primes.Add(i);
            }
        }
        return primes.ToArray();
    }
}