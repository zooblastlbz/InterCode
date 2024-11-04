using System;
using System.Collections.Generic;
using System.Linq;

public class ReferenceCode
{
    public static string[] Puzzle(int[] arr)
    {
        Dictionary<int, string> dic = new Dictionary<int, string>()
        {
            {1, "One"},
            {2, "Two"},
            {3, "Three"},
            {4, "Four"},
            {5, "Five"},
            {6, "Six"},
            {7, "Seven"},
            {8, "Eight"},
            {9, "Nine"},
        };

        int[] sortedArr = arr.Where(n => n >= 1 && n <= 9).OrderByDescending(n => n).ToArray();
        List<string> newArr = new List<string>();

        foreach (int var in sortedArr)
        {
            if (dic.ContainsKey(var))
            {
                newArr.Add(dic[var]);
            }
        }

        return newArr.ToArray();
    }
}