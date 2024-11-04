using System;
using System.Linq;

public class ReferenceCode
{
    public static int[] Puzzle(int[] arr, int k)
    {
        if (k == 0)
        {
            return new int[0];
        }
        Array.Sort(arr);
        return arr.Skip(arr.Length - k).ToArray();
    }
}