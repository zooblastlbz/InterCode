using System.Linq;

public class ReferenceCode
{
    public static int[] Puzzle(int[] xs)
    {
        return xs.Select((x, i) => i * x).Skip(1).ToArray();
    }
}