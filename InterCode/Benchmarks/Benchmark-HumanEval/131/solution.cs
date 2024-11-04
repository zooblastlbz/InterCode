using System;

public class ReferenceCode
{
    public static int Puzzle(int n)
    {
        int product = 1;
        int oddCount = 0;
        foreach (char digit in n.ToString())
        {
            int intDigit = int.Parse(digit.ToString());
            if (intDigit % 2 == 1)
            {
                product *= intDigit;
                oddCount++;
            }
        }
        if (oddCount == 0)
        {
            return 0;
        }
        else
        {
            return product;
        }
    }
}