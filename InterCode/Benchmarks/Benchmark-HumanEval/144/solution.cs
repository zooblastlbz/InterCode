using System;

public class ReferenceCode
{
    public static bool Puzzle(string x, string n)
    {
        string[] partsX = x.Split('/');
        string[] partsN = n.Split('/');
        int numerator = Int32.Parse(partsX[0]) * Int32.Parse(partsN[0]);
        int denominator = Int32.Parse(partsX[1]) * Int32.Parse(partsN[1]);
        if (numerator % denominator == 0)
        {
            return true;
        }
        return false;
    }
}