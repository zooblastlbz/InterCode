using System;

public class ReferenceCode
{
    public static int Puzzle(string s)
    {
        int count = 0;
        for (int i = 0; i < s.Length; i += 2)
        {
            
            if ("AEIOU".Contains(s[i].ToString()))
            {
                count++;
            }
        }
        return count;
    }
}