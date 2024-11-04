using System;
using System.Linq;

public class ReferenceCode
{
    public static int[] Puzzle(int[] l)
    {
        int[] sortedThirds = l.Where((x, i) => i % 3 == 0).OrderBy(x => x).ToArray();
        int[] result = (int[])l.Clone();
        int j = 0;
        for (int i = 0; i < result.Length; i += 3)
        {
            result[i] = sortedThirds[j++];
        }
        return result;
    }
}