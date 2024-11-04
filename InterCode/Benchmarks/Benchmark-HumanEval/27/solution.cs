using System.Linq;

public class ReferenceCode
{
    public static string Puzzle(string input)
    {
        return string.Concat(input.Select(c => char.IsUpper(c) ? char.ToLower(c) : char.ToUpper(c)));
    }
}