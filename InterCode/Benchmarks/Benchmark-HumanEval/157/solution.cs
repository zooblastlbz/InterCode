using System;

public class ReferenceCode
{
    public static bool Puzzle(int a, int b, int c)
    {
        return a*a == b*b + c*c || b*b == a*a + c*c || c*c == a*a + b*b;
    }
}