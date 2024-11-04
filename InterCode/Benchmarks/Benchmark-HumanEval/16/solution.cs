using System;
using System.Linq;

public class ReferenceCode
{
    public static int Puzzle(string s)
    {
        return s.ToLower().Distinct().Count();
    }
}