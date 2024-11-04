using System;
using System.Collections.Generic;

public class ReferenceCode
{
    public static double[] Puzzle(int n)
    {
        if (n == 0)
        {
            return new double[] { 1 };
        }
        List<double> myTri = new List<double> { 1, 3 };
        for (int i = 2; i <= n; i++)
        {
            if (i % 2 == 0)
            {
                myTri.Add(i / 2.0 + 1);
            }
            else
            {
                myTri.Add(myTri[i - 1] + myTri[i - 2] + (i + 3) / 2.0);
            }
        }
        return myTri.ToArray();
    }
}