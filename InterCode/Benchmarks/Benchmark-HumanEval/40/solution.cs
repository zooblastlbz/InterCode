using System.Collections.Generic;

public class ReferenceCode
{
    public static bool Puzzle(int[] l)
    {
        for (int i = 0; i < l.Length; i++)
        {
            for (int j = i + 1; j < l.Length; j++)
            {
                for (int k = j + 1; k < l.Length; k++)
                {
                    if (l[i] + l[j] + l[k] == 0)
                    {
                        return true;
                    }
                }
            }
        }
        return false;
    }
}