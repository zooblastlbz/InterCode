using System;
using System.Linq;
// not consider the case that string is null
public class ReferenceCode
{
    public static string Puzzle(string[] strings)
    {
        int maxLength = strings.Max(s => s.Length);
        return strings.First(s => s.Length == maxLength);
    }
}