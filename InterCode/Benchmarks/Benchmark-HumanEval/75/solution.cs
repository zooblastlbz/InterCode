public class ReferenceCode
{
    public static bool IsPrime(int n)
    {
        for (int i = 2; i < n; i++)
        {
            if (n % i == 0)
            {
                return false;
            }
        }
        return true;
    }
    public static bool Puzzle(int a)
    {
        for (int i = 2; i <= 100; i++)
        {
            if (!IsPrime(i)) continue;
            for (int j = 2; j <= 100; j++)
            {
                if (!IsPrime(j)) continue;
                for (int k = 2; k <= 100; k++)
                {
                    if (!IsPrime(k)) continue;
                    if (i * j * k == a) return true;
                }
            }
        }
        return false;
    }
}