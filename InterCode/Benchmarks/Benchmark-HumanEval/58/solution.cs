using System.Linq;

public class ReferenceCode
{
    public static int[] Puzzle(int[] l1, int[] l2)
    {
        return l1.Intersect(l2).OrderBy(x => x).ToArray();
    }
}