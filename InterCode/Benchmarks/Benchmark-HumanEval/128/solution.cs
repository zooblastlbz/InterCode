using System;
using System.Linq;

public class ReferenceCode
{
    public static int Puzzle(int[] arr)
    {
        if (arr == null || arr.Length == 0) return 0;
        int prod = arr.Contains(0) ? 0 : (int)Math.Pow(-1, arr.Count(x => x < 0));
        return prod * arr.Sum(x => Math.Abs(x));
    }
}