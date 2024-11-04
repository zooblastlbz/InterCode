using System;

public class ReferenceCode
{
    public static string Puzzle(int n, int m)
    {
        if (m < n)
        {
            return "-1";
        }
        int summation = 0;
        for (int i = n; i <= m; i++)
        {
            summation += i;
        }
        return "0b"+Convert.ToString((int)Math.Round((double)summation / (m - n + 1)), 2);
    }
}