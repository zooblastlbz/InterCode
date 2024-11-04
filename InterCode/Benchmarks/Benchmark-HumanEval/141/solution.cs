using System;
using System.Linq;

public class ReferenceCode
{
    public static string Puzzle(string fileName)
    {
        string[] validExtensions = { "txt", "exe", "dll" };
        string[] parts = fileName.Split('.');
        if (parts.Length != 2)
        {
            return "No";
        }
        if (!validExtensions.Contains(parts[1]))
        {
            return "No";
        }
        if (parts[0].Length == 0)
        {
            return "No";
        }
        if (!Char.IsLetter(parts[0][0]))
        {
            return "No";
        }
        int digitCount = parts[0].Count(char.IsDigit);
        if (digitCount > 3)
        {
            return "No";
        }
        return "Yes";
    }
}