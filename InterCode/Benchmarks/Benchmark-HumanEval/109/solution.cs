using System;
using System.Linq;

public class ReferenceCode
{
    public static bool Puzzle(int[] arr)
    {
        if (arr.Length == 0)
        {
            return true;
        }

        int[] sortedArray = arr.OrderBy(x => x).ToArray();

        int minValue = arr.Min();
        int minIndex = Array.IndexOf(arr, minValue);

        int[] myArr = new int[arr.Length];
        Array.Copy(arr, minIndex, myArr, 0, arr.Length - minIndex);
        Array.Copy(arr, 0, myArr, arr.Length - minIndex, minIndex);

        for (int i = 0; i < arr.Length; i++)
        {
            if (myArr[i] != sortedArray[i])
            {
                return false;
            }
        }

        return true;
    }
}