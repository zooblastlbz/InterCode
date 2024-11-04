using System;
using System.Collections.Generic;

public class ReferenceCode
{
    public static int[] Puzzle(int[][] grid, int k)
    {
        int n = grid.Length;
        int val = n * n + 1;
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                if (grid[i][j] == 1)
                {
                    List<int> temp = new List<int>();
                    if (i != 0)
                    {
                        temp.Add(grid[i - 1][j]);
                    }

                    if (j != 0)
                    {
                        temp.Add(grid[i][j - 1]);
                    }

                    if (i != n - 1)
                    {
                        temp.Add(grid[i + 1][j]);
                    }

                    if (j != n - 1)
                    {
                        temp.Add(grid[i][j + 1]);
                    }

                    val = Math.Min(val, temp.Count > 0 ? temp[0] : val);
                }
            }
        }

        int[] ans = new int[k];
        for (int i = 0; i < k; i++)
        {
            if (i % 2 == 0)
            {
                ans[i] = 1;
            }
            else
            {
                ans[i] = val;
            }
        }

        return ans;
    }
}