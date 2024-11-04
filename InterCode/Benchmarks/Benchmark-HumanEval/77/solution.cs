using System;

public class ReferenceCode
{
    public static bool Puzzle(int a)
    {
        a = Math.Abs(a);
        return Math.Pow(Math.Round(Math.Pow(a, 1.0 / 3)), 3) == a;
    }
}