using System;

public class ReferenceCode
{
    public static int Puzzle(int[] arr)
    {
        int ind = -1;
        for (int i = 1; i < arr.Length; i++)
        {
            if (arr[i] < arr[i - 1])
            {
                ind = i;
            }
        }
        return ind;
    }
}