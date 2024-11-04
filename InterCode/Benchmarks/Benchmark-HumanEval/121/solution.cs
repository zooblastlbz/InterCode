using System;
using System.Linq;

public class ReferenceCode
{
    public static int Puzzle(int[] lst)
    {
        return lst.Where((x, idx) => idx % 2 == 0 && x % 2 == 1).Sum();
    }
}