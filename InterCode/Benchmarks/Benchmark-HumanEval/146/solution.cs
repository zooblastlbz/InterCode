using System;
using System.Collections.Generic;

public class ReferenceCode
{
    public static int Puzzle(int[] nums)
    {
        int count = 0;
        foreach (int num in nums)
        {
            if (num > 10)
            {
                List<int> oddDigits = new List<int> { 1, 3, 5, 7, 9 };
                string numberAsString = num.ToString();
                int last = numberAsString.Length-1;
                if (oddDigits.Contains(int.Parse(numberAsString[0].ToString())) && oddDigits.Contains(int.Parse(numberAsString[last].ToString())))
                {
                    count += 1;
                }
            }
        }
        return count;
    }
}