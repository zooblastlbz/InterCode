using System;
using System.Linq;

public class ReferenceCode
{
    public static int[] Puzzle(int[] arr)
    {
        if (arr.Length == 0)
        {
            return new int[0];
        }
        var evens = arr.Where(x => x % 2 == 0).ToArray();
        if (evens.Length == 0)
        {
            return new int[0];
        }
        int minEven = evens.Min();
        return new int[] { minEven, Array.IndexOf(arr, minEven) };
    }
}