using System;
using System.Collections.Generic;

public class ReferenceCode
{
    public static string[] Puzzle(string s, int n)
    {
        List<string> result = new List<string>();
        foreach (string word in s.Split(' '))
        {
            int n_consonants = 0;
            foreach (char c in word)
            {
                if (!"aeiou".Contains(c.ToString().ToLower()))
                {
                    n_consonants += 1;
                }
            }
            if (n_consonants == n)
            {
                result.Add(word);
            }
        }
        return result.ToArray();
    }
}