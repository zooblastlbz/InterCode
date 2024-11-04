using System;

public class ReferenceCode
{
    public static bool Puzzle(int n)
    {
        if (n < 2)
        {
            return false;
        }
        for (int k = 2; k < n; k++)
        {
            if (n % k == 0)
            {
                return false;
            }
        }
        return true;
    }
}