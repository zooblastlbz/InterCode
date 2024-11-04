using System.Collections.Generic;
using System.Linq;

public class ReferenceCode
{
    public static int Puzzle(int[] lst)
    {
        int sum = 0;
        for (int i = 1; i < lst.Length; i += 2)
        {
            if (lst[i] % 2 == 0)
            {
                sum += lst[i];
            }
        }
        return sum;
    }
}