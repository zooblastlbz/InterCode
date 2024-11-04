using System;
using System.Linq;

public class ReferenceCode
{
    public static string Puzzle(string s)
    {
        return String.Join(" ", s.Split(' ').Select(word => String.Concat(word.OrderBy(c => c))));
    }
}