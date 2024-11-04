using System;
using System.Linq;

public class ReferenceCode
{
    public static int Puzzle(int[] lst)
    {
        return lst.Where(i => i > 0 && i % 2 != 0).Sum(i => i * i);
    }
}