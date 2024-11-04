using System;
using System.Linq;

public class ReferenceCode
{
    public static int Puzzle(int[] arr)
    {
        return arr.Count(i => DigitsSum(i) > 0);
    }

    private static int DigitsSum(int n)
    {
        int neg = 1;
        if (n < 0)
        {
            n = -1 * n;
            neg = -1;
        }
        int[] digits = n.ToString().Select(c => int.Parse(c.ToString())).ToArray();
        digits[0] = digits[0] * neg;
        return digits.Sum();
    }
}