using System;
using System.Linq;

public class ReferenceCode
{
    public static bool Puzzle(int[] q, int w)
    {
        if (q.Sum() > w)
        {
            return false;
        }

        int i = 0, j = q.Length - 1;
        while (i < j)
        {
            if (q[i] != q[j])
            {
                return false;
            }
            i++;
            j--;
        }
        return true;
    }
}