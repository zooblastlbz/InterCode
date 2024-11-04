using System;

public class ReferenceCode
{
    public static int Puzzle(string s, string sub)
    {
        int count = 0;
        int index = 0;

        while ((index = s.IndexOf(sub, index)) != -1)
        {
            count++;
            index++;
        }

        return count;
    }
}