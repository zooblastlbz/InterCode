using System.Collections.Generic;
using System;
using System.Linq;
public class ReferenceCode
{
    public static string Puzzle(int x, int shift)
    {
        string s = x.ToString();
        if (shift > s.Length)
        {
            return new string(s.Reverse().ToArray());
        }
        else
        {
            return s.Substring(s.Length - shift) + s.Substring(0, s.Length - shift);
        }
    }
}