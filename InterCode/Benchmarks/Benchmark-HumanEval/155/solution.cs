using System;

public class ReferenceCode
{
    public static int[] Puzzle(int num)
    {
        int evenCount = 0;
        int oddCount = 0;
        foreach (char i in Math.Abs(num).ToString())
        {
            if (int.Parse(i.ToString()) % 2 == 0)
            {
                evenCount += 1;
            }
            else
            {
                oddCount += 1;
            }
        }
        int[] result = new int[2];
        result[0] = evenCount;
        result[1] = oddCount;
        return result;
    }
}