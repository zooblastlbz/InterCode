using System;
using System.Linq;
using System.Collections.Generic;

public class ReferenceCode
{
    public static bool Puzzle(int[] lst)
    {
        Dictionary<int, int> count_digit = lst.Distinct().ToDictionary(i => i, i => 0);
        foreach (int i in lst)
        {
            count_digit[i]++;
        }
        if (count_digit.Any(i => i.Value > 2))
        {
            return false;
        }
        for (int i = 1; i < lst.Length; i++)
        {
            if (lst[i - 1] > lst[i])
            {
                return false;
            }
        }
        return true;
    }
}