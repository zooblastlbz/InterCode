public class ReferenceCode
{
    public static int Puzzle(int n)
    {
        if (n == 0)
        {
            return 0;
        }
        if (n == 1)
        {
            return 1;
        }
        return Puzzle(n - 1) + Puzzle(n - 2);
    }
}