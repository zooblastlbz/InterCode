using System.Linq;

public class ReferenceCode
{
    public static int[] Puzzle(int[] numbers)
    {
        var counts = numbers.GroupBy(x => x)
                            .ToDictionary(g => g.Key, g => g.Count());

        return numbers.Where(n => counts[n] <= 1).ToArray();
    }
}