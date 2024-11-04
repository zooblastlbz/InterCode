using System;
using System.Linq;

public class ReferenceCode
{
    public static int Puzzle(int[][] grid, int capacity)
    {
        return grid.Sum(arr => (int)Math.Ceiling((double)arr.Sum() / capacity));
    }
}