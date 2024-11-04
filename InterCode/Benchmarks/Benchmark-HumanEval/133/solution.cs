using System;
using System.Collections.Generic;

public class ReferenceCode
{
    public static double Puzzle(double[] lst)
    {
        double squared = 0;
        foreach (double i in lst)
        {
            squared += Math.Pow(Math.Ceiling(i), 2);
        }
        return squared;
    }
}