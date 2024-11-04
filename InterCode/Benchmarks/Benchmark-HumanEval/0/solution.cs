using System;

public class ReferenceCode
{
    public static bool Puzzle(double[] numbers, double threshold)
    {
        for (int i = 0; i < numbers.Length; i++)
        {
            for (int j = 0; j < numbers.Length; j++)
            {
                if (i != j)
                {
                    double distance = Math.Abs(numbers[i] - numbers[j]);
                    if (distance < threshold)
                    {
                        return true;
                    }
                }
            }
        }
        return false;
    }
}