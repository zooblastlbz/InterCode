using System;

public class ReferenceCode
{
    public static int Puzzle(int a, int b)
    {
        return Math.Abs(a % 10) * Math.Abs(b % 10);
    }
}