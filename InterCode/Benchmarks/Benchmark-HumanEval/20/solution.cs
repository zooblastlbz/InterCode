using System;

public class ReferenceCode
{
    public static double[] Puzzle(double[] numbers)
    {
        double[] closestPair = new double[2];
        double distance = 1000000.0;
        double x1 = 0;
        double x2 = 0;
        for (int i = 0; i < numbers.Length; i++)
        {
            for (int j = 0; j < numbers.Length; j++)
            {
                if (i != j)
                {
                    double newDistance = Math.Abs(numbers[i] - numbers[j]);
                    if (distance == 1000000.0 || newDistance < distance)
                    {
                        distance = newDistance;
                        x1 = numbers[i];
                        x2 = numbers[j];
                    }
                }
            }
            if (x1 >= x2)
            {
                closestPair[0] = x2;
                closestPair[1] = x1;
            }
            else
            {
                closestPair[0] = x1;
                closestPair[1] = x2;
            }
        }
        return closestPair;
    }
}