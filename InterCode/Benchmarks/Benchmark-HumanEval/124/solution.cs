using System;
using System.Collections.Generic;
using System.Linq;
public class ReferenceCode
{
    public static bool Puzzle(string date)
    {
        try
        {
            date = date.Trim();
            string[] parts = date.Split('-');
            int month = int.Parse(parts[0]);
            int day = int.Parse(parts[1]);
            int year = int.Parse(parts[2]);
            if (month < 1 || month > 12)
            {
                return false;
            }
            if ((new int[] { 1, 3, 5, 7, 8, 10, 12 }).Contains(month) && (day < 1 || day > 31))
            {
                return false;
            }
            if ((new int[] { 4, 6, 9, 11 }).Contains(month) && (day < 1 || day > 30))
            {
                return false;
            }
            if (month == 2 && (day < 1 || day > 29))
            {
                return false;
            }
        }
        catch
        {
            return false;
        }

        return true;
    }
}