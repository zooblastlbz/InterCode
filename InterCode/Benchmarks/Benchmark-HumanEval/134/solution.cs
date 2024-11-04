using System;
using System.Linq;

public class ReferenceCode
{
    public static bool Puzzle(string txt)
    {
        string check = txt.Split(' ').Last();
        return check.Length == 1 && Char.IsLetter(check[0]);
    }
}