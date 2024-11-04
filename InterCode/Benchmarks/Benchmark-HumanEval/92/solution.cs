using System;

public class ReferenceCode
{
    public static bool Puzzle(int x, int y, int z)
    {
        if ((x + y == z) || (x + z == y) || (y + z == x))
        {
            return true;
        }
        return false;
    }
}