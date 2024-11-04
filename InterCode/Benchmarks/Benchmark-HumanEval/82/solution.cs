using System;

public class ReferenceCode
{
    public static bool Puzzle(string s)
    {
        int length = s.Length;
        if (length == 0 || length == 1)
        {
            return false;
        }
        for (int i = 2; i < length; i++)
        {
            if (length % i == 0)
            {
                return false;
            }
        }
        return true;
    }
}