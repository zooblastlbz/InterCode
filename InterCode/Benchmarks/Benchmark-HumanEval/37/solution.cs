using System;
using System.Linq;
using System.Collections.Generic;
public class ReferenceCode
{
    public static int[] Puzzle(int[] l)
    {
        List<int> evens = new List<int>();
        List<int> odds = new List<int>();
        for (int i = 0; i < l.Length; i++)
        {
            if (i % 2 == 0)
            {
                evens.Add(l[i]);
            }
            else
            {
                odds.Add(l[i]);
            }
        }
        evens.Sort();
        List<int> ans = new List<int>();
        for (int i = 0; i < odds.Count; i++)
        {
            ans.Add(evens[i]);
            ans.Add(odds[i]);
        }
        if (evens.Count > odds.Count)
        {
            ans.Add(evens.Last());
        }
        return ans.ToArray();
    }
}