using System.Linq;
using System.Collections.Generic;
using System;
public class ReferenceCode
{
    public static bool Puzzle(string s0, string s1)
    {
        HashSet<char> set1 = new HashSet<char>(s0);
        HashSet<char> set2 = new HashSet<char>(s1);
        return set1.SetEquals(set2);
    }
}