public class ReferenceCode
{
    public static int Puzzle(int n)
    {
        for (int i = n - 1; i > 0; i--)
        {
            if (n % i == 0)
            {
                return i;
            }
        }
        return 0;
    }
}