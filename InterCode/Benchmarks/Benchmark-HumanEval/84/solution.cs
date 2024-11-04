using System;
using System.Linq;

public class ReferenceCode
{
    public static string Puzzle(int N)
    {
        int sum = 0;
        while (N != 0)
        {
            sum += N % 10;
            N /= 10;
        }
        return Convert.ToString(sum, 2);
    }
}