using System;
using System.Linq;
using System.Collections.Generic;

public class ReferenceCode
{
    public static int[] Puzzle(int[] lst)
    {
        List<int> result = new List<int>();
        bool switchFlag = true;
        List<int> lstList = lst.ToList();

        while (lstList.Count > 0)
        {
            if (switchFlag)
            {
                int minVal = lstList.Min();
                result.Add(minVal);
                lstList.Remove(minVal);
            }
            else
            {
                int maxVal = lstList.Max();
                result.Add(maxVal);
                lstList.Remove(maxVal);
            }
            switchFlag = !switchFlag;
        }
        return result.ToArray();
    }
}