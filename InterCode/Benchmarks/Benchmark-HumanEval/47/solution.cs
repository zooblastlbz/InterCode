using System;
using System.Linq;

public class ReferenceCode
{
    public static double Puzzle(int[] l)
    {
        Array.Sort(l);
        int n = l.Length;
        if (n % 2 == 1)
        {
            return l[n / 2];
        }
        else
        {
            return (l[n / 2 - 1] + l[n / 2]) / 2.0;
        }
    }
}