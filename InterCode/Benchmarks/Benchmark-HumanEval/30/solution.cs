using System.Linq;

public class ReferenceCode
{
    public static int[] Puzzle(int[] numbers)
    {
        return numbers.Where(n => n > 0).ToArray();
    }
}