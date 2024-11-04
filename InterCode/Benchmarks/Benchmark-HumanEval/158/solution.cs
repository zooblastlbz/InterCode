using System;
using System.Linq;

public class ReferenceCode
{
    public static string Puzzle(string[] words)
    {
        return words.OrderByDescending(word => word.Distinct().Count())
                    .ThenBy(word => word)
                    .First();
    }
}