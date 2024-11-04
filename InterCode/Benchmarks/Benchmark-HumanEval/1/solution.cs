using System;
using System.Collections.Generic;

public class ReferenceCode
{
    public static string[] Puzzle(string parenString)
    {
        List<string> result = new List<string>();
        List<char> currentString = new List<char>();
        int currentDepth = 0;

        foreach (char c in parenString)
        {
            if (c == '(')
            {
                currentDepth += 1;
                currentString.Add(c);
            }
            else if (c == ')')
            {
                currentDepth -= 1;
                currentString.Add(c);

                if (currentDepth == 0)
                {
                    result.Add(new string(currentString.ToArray()));
                    currentString.Clear();
                }
            }
        }

        return result.ToArray();
    }
}