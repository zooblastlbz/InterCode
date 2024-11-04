using System.Linq;

public class ReferenceCode
{
    public static int[] Puzzle(int[] l)
    {
        return l.Distinct().OrderBy(x => x).ToArray();
    }
}