using System;
using System.Linq;

public class ReferenceCode
{
    public static string[] Puzzle(string[] lst1, string[] lst2)
    {
        int l1 = lst1.Sum(st => st.Length);
        int l2 = lst2.Sum(st => st.Length);

        if (l1 <= l2)
        {
            return lst1;
        }
        else
        {
            return lst2;
        }
    }
}