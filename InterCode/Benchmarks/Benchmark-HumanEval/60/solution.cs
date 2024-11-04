using System.Collections.Generic;
using System;
using System.Linq;
public class ReferenceCode
{
    public static int Puzzle(int n)
    {
        return Enumerable.Range(1, n).Sum();
    }
}