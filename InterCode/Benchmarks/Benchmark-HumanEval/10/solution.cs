using System;
using System.Linq;
public class ReferenceCode
{
    public static bool IsPalindrome(string s)
    {
        int start = 0;
        int end = s.Length - 1;

        while (start < end)
        {
            if (s[start] != s[end])
                return false;

            start++;
            end--;
        }

        return true;
    }

    public static string Puzzle(string s)
    {
        if (string.IsNullOrEmpty(s))
        {
            return string.Empty;
        }

        int beginningOfSuffix = 0;

        while (!IsPalindrome(s.Substring(beginningOfSuffix)))
        {
            beginningOfSuffix += 1;
        }

        return s + new string(s.Substring(0, beginningOfSuffix).Reverse().ToArray());
    }
}
