using System.Linq;

public class ReferenceCode
{
    public static bool Puzzle(int[] l)
    {
        return l.SequenceEqual(l.OrderBy(x => x)) || l.SequenceEqual(l.OrderByDescending(x => x));
    }
}