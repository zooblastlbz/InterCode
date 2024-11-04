using System;
using System.Collections.Generic;

public class ReferenceCode
{
    public static bool Puzzle(string str)
    {
        List<int> openingBracketIndex = new List<int>();
        List<int> closingBracketIndex = new List<int>();
        for (int i = 0; i < str.Length; i++)
        {
            if (str[i] == '[')
            {
                openingBracketIndex.Add(i);
            }
            else
            {
                closingBracketIndex.Add(i);
            }
        }
        closingBracketIndex.Reverse();
        int cnt = 0;
        int j = 0;
        int l = closingBracketIndex.Count;
        foreach (int idx in openingBracketIndex)
        {
            if (j < l && idx < closingBracketIndex[j])
            {
                cnt++;
                j++;
            }
        }
        return cnt >= 2;
    }
}