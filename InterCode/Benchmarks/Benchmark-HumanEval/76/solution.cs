public class ReferenceCode
{
    public static bool Puzzle(int x, int n)
    {
        if (n == 1)
        {
            return x == 1;
        }
        int power = 1;
        while (power < x)
        {
            power *= n;
        }
        return power == x;
    }
}