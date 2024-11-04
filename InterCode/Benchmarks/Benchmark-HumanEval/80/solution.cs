using System;

public class ReferenceCode
{
    public static bool Puzzle(string s)
    {
        if (s.Length < 3)
        {
            return false;
        }

        for (int i = 0; i < s.Length - 2; i++)
        {
            if (s[i] == s[i+1] || s[i+1] == s[i+2] || s[i] == s[i+2])
            {
                return false;
            }
        }
        return true;
    }
}