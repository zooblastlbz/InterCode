using System;
using System.Linq;

public class ReferenceCode
{
    public static int[] Puzzle(int[] nums)
    {
        return nums.OrderBy(n => DigitsSum(n)).ToArray();
    }

    private static int DigitsSum(int n)
    {
        int neg = 1;
        if (n < 0)
        {
            n = -1 * n;
            neg = -1;
        }
        int sum = 0;
        while (n != 0)
        {
            sum += n % 10;
            n /= 10;
        }
        return sum * neg;
    }
}