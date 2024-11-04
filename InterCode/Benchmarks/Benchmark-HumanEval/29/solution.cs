using System.Linq;

public class ReferenceCode
{
    public static string[] Puzzle(string[] strings, string prefix)
    {
        return strings.Where(s => s.StartsWith(prefix)).ToArray();
    }
}