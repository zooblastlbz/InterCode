using System;

public class ReferenceCode
{
    public static bool isPrime(int num){
        if (num == 1 || num == 0)
            {
                return false;
            }
            if (num == 2)
            {
                return true;
            }
            for (int i = 2; i * i <= num; i++)
            {
                if (num % i == 0)
                {
                    return false;
                }
            }
            return true;
    }
    public static string Puzzle(int[] interval1, int[] interval2)
    {
        int l = Math.Max(interval1[0], interval2[0]);
        int r = Math.Min(interval1[1], interval2[1]);
        int length = r - l;
        if (length > 0 && isPrime(length))
        {
            return "YES";
        }
        return "NO";
    }
}