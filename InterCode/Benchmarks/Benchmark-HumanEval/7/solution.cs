using System;
using System.Linq;

public class ReferenceCode
{
    public static string[] Puzzle(string[] strings, string substring)
    {
        return strings.Where(x => x.Contains(substring)).ToArray();
    }
}