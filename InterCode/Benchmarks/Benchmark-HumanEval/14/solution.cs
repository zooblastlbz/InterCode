using System;

public class ReferenceCode
{
    public static string[] Puzzle(string s)
    {
        string[] result = new string[s.Length];

        for (int i = 0; i < s.Length; i++)
        {
            result[i] = s.Substring(0, i + 1);
        }

        return result;
    }
}