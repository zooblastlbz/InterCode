using System.Linq;

public class ReferenceCode
{
    public static string Puzzle(string text)
    {
        return new string(text.Where(c => !"aeiouAEIOU".Contains(c)).ToArray());
    }
}