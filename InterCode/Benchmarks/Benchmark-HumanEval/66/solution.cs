using System.Linq;

public class ReferenceCode
{
    public static int Puzzle(string s)
    {
        if (string.IsNullOrEmpty(s))
        {
            return 0;
        }
        return s.Where(char.IsUpper).Sum(c => (int)c);
    }
}