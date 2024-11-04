using System;
using System.Collections.Generic;
using System.Linq;

public class ReferenceCode
{
    public static string Puzzle(string numbers)
    {
        Dictionary<string, int> valueMap = new Dictionary<string, int>
        {
            {"zero", 0},
            {"one", 1},
            {"two", 2},
            {"three", 3},
            {"four", 4},
            {"five", 5},
            {"six", 6},
            {"seven", 7},
            {"eight", 8},
            {"nine", 9}
        };

        return string.Join(" ", numbers.Split(' ')
                                       .Where(x => !string.IsNullOrEmpty(x))
                                       .OrderBy(x => valueMap[x]));
    }
}