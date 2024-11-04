using System;
using System.Linq;

public class ReferenceCode
{
    public static int Puzzle(int[] lst)
    {
        int[] result = new int[lst.Length];
        for (int i = 0; i < lst.Length; i++)
        {
            if (i % 3 == 0)
            {
                result[i] = (int)Math.Pow(lst[i], 2);
            }
            else if (i % 4 == 0 && i % 3 != 0)
            {
                result[i] = (int)Math.Pow(lst[i], 3);
            }
            else
            {
                result[i] = lst[i];
            }
        }
        return result.Sum();
    }
}