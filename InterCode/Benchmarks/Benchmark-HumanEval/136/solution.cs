using System;
using System.Linq;

public class ReferenceCode
{
    public static int[] Puzzle(int[] lst)
    {
        var smallest = lst.Where(x => x < 0).ToList();
        var largest = lst.Where(x => x > 0).ToList();
        int[] result = new int[2];
        result[0] = smallest.Any() ? smallest.Max() : 0;
        result[1] = largest.Any() ? largest.Min() : 0;
        return result;
    }
}