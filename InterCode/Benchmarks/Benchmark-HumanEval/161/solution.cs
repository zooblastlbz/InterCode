using System;
using System.Linq;
using System.Text;

public class ReferenceCode
{
    public static string Puzzle(string s)
    {
        bool flag = false;
        StringBuilder newStr = new StringBuilder(s.Length);
        foreach (char c in s)
        {
            if (Char.IsLetter(c))
            {
                newStr.Append(Char.IsUpper(c) ? Char.ToLower(c) : Char.ToUpper(c));
                flag = true;
            }
            else
            {
                newStr.Append(c);
            }
        }
        if (!flag)
        {
            return new string(newStr.ToString().Reverse().ToArray());
        }
        return newStr.ToString();
    }
}