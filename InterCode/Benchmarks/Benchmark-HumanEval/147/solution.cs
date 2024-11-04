using System;
using System.Collections.Generic;

public class ReferenceCode
{
    public static int Puzzle(int n)
    {
        List<int> A = new List<int>();
        for (int i = 1; i <= n; i++)
        {
            A.Add(i * i - i + 1);
        }
        int count = 0;
        for (int i = 0; i < n; i++)
        {
            for (int j = i + 1; j < n; j++)
            {
                for (int k = j + 1; k < n; k++)
                {
                    if ((A[i] + A[j] + A[k]) % 3 == 0)
                    {
                        count++;
                    }
                }
            }
        }
        return count;
    }
}