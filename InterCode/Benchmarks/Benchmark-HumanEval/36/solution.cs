using System;
using System.Collections.Generic;
using System.Linq;

public class ReferenceCode
{
    public static int Puzzle(int n)
    {
        List<int> ns = new List<int>();
        for (int i = 0; i < n; i++)
        {
            if (i % 11 == 0 || i % 13 == 0)
            {
                ns.Add(i);
            }
        }
        string s = string.Join("", ns.Select(x => x.ToString()));
        int ans = 0;
        foreach (char c in s)
        {
            if (c == '7')
            {
                ans++;
            }
        }
        return ans;
    }
}