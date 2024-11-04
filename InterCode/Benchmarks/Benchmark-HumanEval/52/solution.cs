using System.Collections.Generic;

public class ReferenceCode
{
    public static bool Puzzle(int[] l, int t)
    {
        foreach (var e in l)
        {
            if (e >= t)
            {
                return false;
            }
        }
        return true;
    }
}