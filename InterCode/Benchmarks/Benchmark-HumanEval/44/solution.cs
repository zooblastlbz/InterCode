using System;

public class ReferenceCode
{
    public static string Puzzle(int x, int baseNum)
    {
        string ret = "";
        while (x > 0)
        {
            ret = (x % baseNum).ToString() + ret;
            x /= baseNum;
        }
        return ret;
    }
}