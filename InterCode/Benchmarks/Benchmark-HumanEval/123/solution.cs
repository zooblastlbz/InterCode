using System;
using System.Collections.Generic;

public class ReferenceCode
{
    public static int[] Puzzle(int n)
    {
        List<int> oddCollatz = new List<int>();
        if (n % 2 != 0)
        {
            oddCollatz.Add(n);
        }
        while (n > 1)
        {
            if (n % 2 == 0)
            {
                n = n / 2;
            }
            else
            {
                n = n * 3 + 1;
            }
            if (n % 2 == 1)
            {
                oddCollatz.Add(n);
            }
        }
        oddCollatz.Sort();
        return oddCollatz.ToArray();
    }
}