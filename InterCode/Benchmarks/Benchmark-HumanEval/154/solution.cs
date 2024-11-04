using System;

public class ReferenceCode
{
    public static bool Puzzle(string a, string b)
    {
        int l = b.Length;
        string pat = b + b;
        for (int i = 0; i <= a.Length - l; i++)
        {
            for (int j = 0; j <= l; j++)
            {
                if (a.Substring(i, l) == pat.Substring(j, l))
                {
                    return true;
                }
            }
        }
        return false;
    }
}