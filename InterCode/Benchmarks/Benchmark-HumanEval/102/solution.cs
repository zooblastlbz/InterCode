using System;

public class ReferenceCode
{
    public static int Puzzle(int x, int y)
    {
        if (x > y)
        {
            return -1;
        }
        if (y % 2 == 0)
        {
            return y;
        }
        if (x == y)
        {
            return -1;
        }
        return y - 1;
    }
}