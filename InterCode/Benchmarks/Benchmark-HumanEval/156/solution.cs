using System;

public class ReferenceCode
{
    public static string Puzzle(int number)
    {
        int[] num = {1, 4, 5, 9, 10, 40, 50, 90, 100, 400, 500, 900, 1000};
        string[] sym = {"I", "IV", "V", "IX", "X", "XL", "L", "XC", "C", "CD", "D", "CM", "M"};
        int i = 12;
        string res = "";
        while (number > 0)
        {
            int div = number / num[i];
            number %= num[i];
            while (div > 0)
            {
                res += sym[i];
                div--;
            }
            i--;
        }
        return res.ToLower();
    }
}