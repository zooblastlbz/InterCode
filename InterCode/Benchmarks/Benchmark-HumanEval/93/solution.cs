using System;
using System.Linq;
using System.Collections.Generic;

public class ReferenceCode
{
    public static string Puzzle(string message)
    {
        string vowels = "aeiouAEIOU";
        Dictionary<char, char> vowelsReplace = vowels.ToDictionary(v => v, v => (char)(v + 2));
        message = SwapCase(message);
        return new string(message.Select(c => vowelsReplace.ContainsKey(c) ? vowelsReplace[c] : c).ToArray());
    }

    private static string SwapCase(string s)
    {
        return new string(s.Select(c => char.IsLetter(c) ? (char.IsUpper(c) ? char.ToLower(c) : char.ToUpper(c)) : c).ToArray());
    }
}