using System;

public class ReferenceCode
{
    public static int Puzzle(int n)
    {
        if (n == 1) 
        {
            return 1;
        }
        return 18 * (int)Math.Pow(10, n - 2);
    }
}