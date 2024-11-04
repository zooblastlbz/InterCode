using System;
using System.Collections.Generic;

public class ReferenceCode
{
    public static string Puzzle(string word)
    {
        if (word.Length < 3)
        {
            return "";
        }

        HashSet<char> vowels = new HashSet<char> { 'a', 'e', 'i', 'o', 'u', 'A', 'E', 'O', 'U', 'I' };
        for (int i = word.Length - 2; i > 0; i--)
        {
            if (vowels.Contains(word[i]))
            {
                if (!vowels.Contains(word[i + 1]) && !vowels.Contains(word[i - 1]))
                {
                    return word[i].ToString();
                }
            }
        }
        return "";
    }
}