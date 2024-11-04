using System;

public class ReferenceCode
{
    public static int Puzzle(int n)
    {
        bool IsPrime(int k)
        {
            if (k < 2)
            {
                return false;
            }
            for (int i = 2; i < k; i++)
            {
                if (k % i == 0)
                {
                    return false;
                }
            }
            return true;
        }

        int largest = 1;
        for (int j = 2; j <= n; j++)
        {
            if (n % j == 0 && IsPrime(j))
            {
                largest = Math.Max(largest, j);
            }
        }
        return largest;
    }
}