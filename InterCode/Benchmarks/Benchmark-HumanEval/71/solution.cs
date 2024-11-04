using System;

public class ReferenceCode
{
    public static double Puzzle(double a, double b, double c)
    {
        if (a + b <= c || a + c <= b || b + c <= a)
        {
            return -1;
        }
        double s = (a + b + c) / 2;
        double area = Math.Sqrt(s * (s - a) * (s - b) * (s - c));
        area = Math.Round(area, 2);
        return area;
    }
}