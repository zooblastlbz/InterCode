using System;
using System.Linq;

public class ReferenceCode
{
    public static int Puzzle(int[] lst)
    {
        int[] frq = new int[lst.Max() + 1];
        foreach (int i in lst)
        {
            frq[i]++;
        }
        int ans = -1;
        for (int i = 1; i < frq.Length; i++)
        {
            if (frq[i] >= i)
            {
                ans = i;
            }
        }
        return ans;
    }
}