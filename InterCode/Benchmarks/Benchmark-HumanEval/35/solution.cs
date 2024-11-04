using System.Linq;

public class ReferenceCode
{
    public static int Puzzle(int[] l)
    {
        int m = l[0];
        foreach (int e in l)
        {
            if (e > m)
            {
                m = e;
            }
        }
        return m;
    }
}