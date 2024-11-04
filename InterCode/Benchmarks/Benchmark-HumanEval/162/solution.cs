using System;
using System.Security.Cryptography;
using System.Text;

public class ReferenceCode
{
    public static string Puzzle(string text)
    {
        if (string.IsNullOrEmpty(text))
        {
            return null;
        }

        using (MD5 md5 = MD5.Create())
        {
            byte[] inputBytes = Encoding.ASCII.GetBytes(text);
            byte[] hashBytes = md5.ComputeHash(inputBytes);

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < hashBytes.Length; i++)
            {
                sb.Append(hashBytes[i].ToString("x2"));
            }
            return sb.ToString();
        }
    }
}