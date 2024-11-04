using System;
using System.Linq;

public class ReferenceCode
{
    public static string Puzzle(int n)
    {
        return string.Join(" ", Enumerable.Range(0, n + 1));
    }
}