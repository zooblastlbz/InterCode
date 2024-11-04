using System;
using System.Linq;

public class ReferenceCode
{
    public static int Puzzle(int[] lst)
    {
        var primes = lst.Where(IsPrime);
        if(primes.Count() > 0) {
            int maxPrime = primes.Max();
            return maxPrime.ToString().Sum(c => c - '0');
        }
        else
            return 0;
        
    }

    private static bool IsPrime(int n)
    {
        if (n <= 1)
        {
            return false;
        } 

        for (int i = 2; i * i <= n; i++)
        {
            if (n % i == 0)
            {
                return false;
            }
        }

        return true;
    }
}