public class ReferenceCode
{
    public static int Puzzle(int[] arr)
    {
        int ans = 0;
        for (int i = 0; i < arr.Length / 2; i++)
        {
            if (arr[i] != arr[arr.Length - i - 1])
            {
                ans += 1;
            }
        }
        return ans;
    }
}