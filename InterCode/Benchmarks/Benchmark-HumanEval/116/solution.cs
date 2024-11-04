using System;
using System.Linq;

public class ReferenceCode
{
    public static int[] Puzzle(int[] arr)
    {
        return arr.OrderBy(x => Convert.ToString(x, 2).Count(c => c == '1')).ThenBy(x => x).ToArray();
    }
}