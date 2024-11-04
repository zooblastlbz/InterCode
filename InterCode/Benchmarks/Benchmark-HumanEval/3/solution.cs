using System;

public class ReferenceCode
{
    public static bool Puzzle(int[] operations)
    {
        int balance = 0;

        foreach (int op in operations)
        {
            balance += op;
            if (balance < 0)
            {
                return true;
            }
        }

        return false;
    }
}