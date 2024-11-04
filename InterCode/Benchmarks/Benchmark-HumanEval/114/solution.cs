using System;
using System.Linq;

public class ReferenceCode
{
    public static int Puzzle(int[] nums)
    {
        int max_sum = 0;
        int s = 0;
        foreach (int num in nums)
        {
            s += -num;
            if (s < 0)
            {
                s = 0;
            }
            max_sum = Math.Max(s, max_sum);
        }
        if (max_sum == 0)
        {
            max_sum = nums.Max(i => -i);
        }
        int min_sum = -max_sum;
        return min_sum;
    }
}