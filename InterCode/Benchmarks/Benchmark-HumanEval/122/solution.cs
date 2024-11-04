using System;
using System.Linq;

public class ReferenceCode
{
    public static int Puzzle(int[] arr, int k)
    {
        return arr.Take(k).Where(x => x >= 0 && x < 100).Sum();
    }
}