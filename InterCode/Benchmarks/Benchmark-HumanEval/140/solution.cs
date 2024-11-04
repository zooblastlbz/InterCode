using System;
using System.Text;

public class ReferenceCode
{
    public static string Puzzle(string text)
    {
        StringBuilder new_text = new StringBuilder();
        int i = 0;
        int start = 0, end = 0;
        while (i < text.Length)
        {
            if (text[i] == ' ')
            {
                end += 1;
            }
            else
            {
                if (end - start > 2)
                {
                    new_text.Append("-" + text[i]);
                }
                else if (end - start > 0)
                {
                    new_text.Append(new String('_', end - start) + text[i]);
                }
                else
                {
                    new_text.Append(text[i]);
                }
                start = i + 1;
                end = i + 1;
            }
            i += 1;
        }
        if (end - start > 2)
        {
            new_text.Append("-");
        }
        else if (end - start > 0)
        {
            new_text.Append("_");
        }
        return new_text.ToString();
    }
}