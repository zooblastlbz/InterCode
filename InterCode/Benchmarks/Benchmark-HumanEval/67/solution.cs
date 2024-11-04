using System.Linq;

public class ReferenceCode
{
    public static int Puzzle(string s, int n)
    {
        var numbers = s.Split(' ')
                       .Where(word => int.TryParse(word, out _))
                       .Select(word => int.Parse(word))
                       .ToList();
        return n - numbers.Sum();
    }
}