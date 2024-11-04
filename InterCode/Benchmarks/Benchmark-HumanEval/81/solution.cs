using System.Collections.Generic;
using System;
public class ReferenceCode{
public static string[] Puzzle(double[] grades)
{
    List<string> letterGrades = new List<string>();
    foreach (double gpa in grades)
    {
        if (gpa == 4.0)
        {
            letterGrades.Add("A+");
        }
        else if (gpa > 3.7)
        {
            letterGrades.Add("A");
        }
        else if (gpa > 3.3)
        {
            letterGrades.Add("A-");
        }
        else if (gpa > 3.0)
        {
            letterGrades.Add("B+");
        }
        else if (gpa > 2.7)
        {
            letterGrades.Add("B");
        }
        else if (gpa > 2.3)
        {
            letterGrades.Add("B-");
        }
        else if (gpa > 2.0)
        {
            letterGrades.Add("C+");
        }
        else if (gpa > 1.7)
        {
            letterGrades.Add("C");
        }
        else if (gpa > 1.3)
        {
            letterGrades.Add("C-");
        }
        else if (gpa > 1.0)
        {
            letterGrades.Add("D+");
        }
        else if (gpa > 0.7)
        {
            letterGrades.Add("D");
        }
        else if (gpa > 0.0)
        {
            letterGrades.Add("D-");
        }
        else
        {
            letterGrades.Add("E");
        }
    }
    return letterGrades.ToArray();
}
}