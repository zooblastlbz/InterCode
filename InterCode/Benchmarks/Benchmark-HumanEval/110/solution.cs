using System;
using System.Linq;

public class ReferenceCode
{
    public static string Puzzle(int[] lst1, int[] lst2)
    {
        int odd = 0;
        int even = 0;
        foreach (int i in lst1)
        {
            if (i % 2 == 1)
            {
                odd += 1;
            }
        }
        foreach (int i in lst2)
        {
            if (i % 2 == 0)
            {
                even += 1;
            }
        }
        if (even >= odd)
        {
            return "YES";
        }
        return "NO";
    }
}