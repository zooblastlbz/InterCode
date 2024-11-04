public class ReferenceCode
{
    public static int[] Puzzle(int number, int need, int remaining)
    {
        if (need <= remaining)
        {
            return new int[] { number + need, remaining - need };
        }
        else
        {
            return new int[] { number + remaining, 0 };
        }
    }
}