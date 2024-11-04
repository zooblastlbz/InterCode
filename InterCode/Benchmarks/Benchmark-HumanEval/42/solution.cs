using System.Linq;

public class ReferenceCode
{
    public static int[] Puzzle(int[] l)
    {
        return l.Select(e => e + 1).ToArray();
    }
}