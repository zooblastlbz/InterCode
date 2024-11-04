using System;
using System.Linq;

public class ReferenceCode
{
    public static double[] Puzzle(double[] numbers)
    {
        double minNumber = numbers.Min();
        double maxNumber = numbers.Max();

        return numbers.Select(x => (x - minNumber) / (maxNumber - minNumber)).ToArray();
    }
}