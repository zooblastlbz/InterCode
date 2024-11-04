public class ReferenceCode
{
    public static bool Puzzle(string brackets)
    {
        int depth = 0;
        foreach (char b in brackets)
        {
            if (b == '<')
            {
                depth += 1;
            }
            else
            {
                depth -= 1;
            }
            if (depth < 0)
            {
                return false;
            }
        }
        return depth == 0;
    }
}