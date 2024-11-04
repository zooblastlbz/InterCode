using System;
using System.Linq;
using System.Text;

public class ReferenceCode
{
    public static string Puzzle(string x1, string x2)
    {
        int len1 = x1.Length;
        int len2 = x2.Length;

        if (len1 > len2)
        {
            x2 = x2.PadLeft(len1, '0');
        }
        else if (len2 > len1)
        {
            x1 = x1.PadLeft(len2, '0');
        }

        StringBuilder result = new StringBuilder();

        for (int i = 0; i < x1.Length; i++)
        {
            char xorResult = (x1[i] == x2[i]) ? '0' : '1';
            result.Append(xorResult);
        }

        return result.ToString();
    }

}
