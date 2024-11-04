using System;
using System.Linq;
using System.Collections.Generic;
public class ReferenceCode
{
    public static string[] Puzzle(string[] lst)
    {
        Array.Sort(lst);
        List<string> new_lst = new List<string>();
        foreach (string i in lst)
        {
            if (i.Length % 2 == 0)
            {
                new_lst.Add(i);
            }
        }
        return new_lst.OrderBy(s => s.Length).ToArray();
    }
}