using System;
using System.Linq;
public class ReferenceCode
{
    public static int[] Puzzle(int n)
    {
        int evenPalindromeCount = 0;
        int oddPalindromeCount = 0;

        for (int i = 1; i <= n; i++)
        {
            if (IsPalindrome(i))
            {
                if (i % 2 == 0)
                {
                    evenPalindromeCount++;
                }
                else
                {
                    oddPalindromeCount++;
                }
            }
        }
        int[] result = new int[2];
        result[0] = evenPalindromeCount;
        result[1] = oddPalindromeCount;
        return result;
    }

    private static bool IsPalindrome(int n)
    {
        string str = n.ToString();
        string reversedStr = new string(str.ToCharArray().Reverse().ToArray());
        return str == reversedStr;
    }
}