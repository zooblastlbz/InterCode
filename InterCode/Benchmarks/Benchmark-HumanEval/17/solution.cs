using System;
using System.Collections.Generic;
using System.Linq;

public class ReferenceCode
{
    public static int[] Puzzle(string musicString)
    {
        Dictionary<string, int> noteMap = new Dictionary<string, int>
        {
            {"o", 4},
            {"o|", 2},
            {".|", 1}
        };

        return musicString.Split(' ')
                          .Where(x => !string.IsNullOrEmpty(x))
                          .Select(x => noteMap[x])
                          .ToArray();
    }
}