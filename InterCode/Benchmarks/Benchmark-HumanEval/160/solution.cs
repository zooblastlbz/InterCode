
using System;
using System.Data;

public class ReferenceCode
{
    public static double Puzzle(string[] operators, int[] operands)
    {
        string expression = operands[0].ToString();
        for (int i = 0; i < operators.Length; i++)
        {
            expression += operators[i] + operands[i + 1].ToString();
        }
        DataTable dt = new DataTable();
        var result = dt.Compute(expression, "");
        return Convert.ToDouble(result);
    }
}