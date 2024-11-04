using System;
using System.Linq;
using System.Text.RegularExpressions;

public class ReferenceCode
{
    public static int Puzzle(string S)
    {
        string[] sentences = Regex.Split(S, @"[.?!]\s*");
        return sentences.Count(sentence => sentence.StartsWith("I "));
    }
}