using System;
using System.Collections.Generic;
using System.Linq;

public class ReferenceCode
{
    public static string Puzzle(string sentence)
    {
        List<string> new_lst = new List<string>();
        foreach (string word in sentence.Split(' '))
        {
            bool flg = false;
            if (word.Length == 1)
            {
                flg = true;
            }
            for (int i = 2; i < word.Length; i++)
            {
                if (word.Length % i == 0)
                {
                    flg = true;
                }
            }
            if (flg == false || word.Length == 2)
            {
                new_lst.Add(word);
            }
        }
        return String.Join(" ", new_lst);
    }
}