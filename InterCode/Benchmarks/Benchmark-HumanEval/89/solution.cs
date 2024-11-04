using System;
using System.Linq;

public class ReferenceCode
{
    public static string Puzzle(string s)
    {
        string d = "abcdefghijklmnopqrstuvwxyz";
        string output = "";
        foreach (char c in s)
        {
            if (d.Contains(c))
            {
                output += d[(d.IndexOf(c) + 2 * 2) % 26];
            }
            else
            {
                output += c;
            }
        }
        return output;
    }
}