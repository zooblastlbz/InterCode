using System;
using System.Linq;

public class ReferenceCode
{
    public static int[] Puzzle(int[] array)
    {
        if (array.Length == 0)
        {
            return new int[0];
        }
        else
        {
            bool isEven = (array[0] + array[array.Length - 1]) % 2 == 0;
            return isEven ? array.OrderByDescending(x => x).ToArray() : array.OrderBy(x => x).ToArray();
        }
    }
}