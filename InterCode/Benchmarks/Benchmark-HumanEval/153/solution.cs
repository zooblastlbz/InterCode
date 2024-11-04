using System;
using System.Linq;

public class ReferenceCode
{
    public static string Puzzle(string className, string[] extensions)
    {
        string strongest = extensions[0];
        int myVal = extensions[0].Count(char.IsUpper) - extensions[0].Count(char.IsLower);
        foreach (string s in extensions)
        {
            int val = s.Count(char.IsUpper) - s.Count(char.IsLower);
            if (val > myVal)
            {
                strongest = s;
                myVal = val;
            }
        }
        string ans = className+"."+strongest;
        return ans;
    }
}