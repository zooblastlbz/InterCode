using System;

public class ReferenceCode
{
    public static string Puzzle(string[] lst)
    {
        Func<string, bool> check = s =>
        {
            int val = 0;
            foreach (char i in s)
            {
                if (i == '(')
                {
                    val = val + 1;
                }
                else
                {
                    val = val - 1;
                }
                if (val < 0)
                {
                    return false;
                }
            }
            return val == 0;
        };

        string S1 = lst[0] + lst[1];
        string S2 = lst[1] + lst[0];
        return check(S1) || check(S2) ? "Yes" : "No";
    }
}