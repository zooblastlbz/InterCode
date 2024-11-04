using System;
using System.Collections.Generic;

public class ReferenceCode
{
    public static int[] Puzzle(int[] numbers, int delimeter)
    {
        if (numbers.Length == 0)
        {
            return new int[0];
        }

        List<int> result = new List<int>();

        for (int i = 0; i < numbers.Length - 1; i++)
        {
            result.Add(numbers[i]);
            result.Add(delimeter);
        }

        result.Add(numbers[numbers.Length - 1]);

        return result.ToArray();
    }
}