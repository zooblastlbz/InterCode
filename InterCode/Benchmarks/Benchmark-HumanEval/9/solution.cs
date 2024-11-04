using System;

public class ReferenceCode
{
    public static int[] Puzzle(int[] numbers)
    {
        int? runningMax = null;
        int[] result = new int[numbers.Length];
        int index = 0;

        foreach (int n in numbers)
        {
            if (runningMax == null)
            {
                runningMax = n;
            }
            else
            {
                runningMax = Math.Max(runningMax.Value, n);
            }

            result[index++] = runningMax.Value;
        }

        return result;
    }
}