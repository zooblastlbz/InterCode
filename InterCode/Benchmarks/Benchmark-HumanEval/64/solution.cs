using System.Linq;

public class ReferenceCode
{
    public static int Puzzle(string s)
    {
        string vowels = "aeiouAEIOU";
        int n_vowels = s.Count(c => vowels.Contains(c));
        if (s.Last() == 'y' || s.Last() == 'Y')
        {
            n_vowels += 1;
        }
        return n_vowels;
    }
}