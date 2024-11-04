using System.Collections.Generic;

public class ReferenceCode
{
    public static int Puzzle(int n)
    {
        List<int> results = new List<int> { 0, 0, 2, 0 };
        if (n < 4)
        {
            return results[n];
        }

        for (int i = 4; i <= n; i++)
        {
            results.Add(results[3] + results[2] + results[1] + results[0]);
            results.RemoveAt(0);
        }

        return results[3];
    }
}