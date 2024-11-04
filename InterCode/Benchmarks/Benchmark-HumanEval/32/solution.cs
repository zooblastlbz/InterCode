using System;
using System.Linq;

public class ReferenceCode
{
    public static double Poly(double[] xs, double x)
    {
        return xs.Select((coeff, i) => coeff * Math.Pow(x, i)).Sum();
    }

    public static double Puzzle(double[] xs)
    {
        double begin = -1.0, end = 1.0;
        while (Poly(xs, begin) * Poly(xs, end) > 0)
        {
            begin *= 2.0;
            end *= 2.0;
        }
        while (end - begin > 1e-10)
        {
            double center = (begin + end) / 2.0;
            if (Poly(xs, center) * Poly(xs, begin) > 0)
            {
                begin = center;
            }
            else
            {
                end = center;
            }
        }
        return Math.Round(begin, 2);
    }
}