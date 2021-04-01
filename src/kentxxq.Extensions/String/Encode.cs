using System;
using System.Security.Cryptography;
using System.Text;

namespace kentxxq.Extensions.String
{
    public static class Encode
    {
        public static string Sha256(this string text)
        {
            using (var sha256 = SHA256.Create())
            {
                var textBytes = Encoding.UTF8.GetBytes(text);
                var textHash = sha256.ComputeHash(textBytes);
                var result = BitConverter.ToString(textHash).Replace("-", "").ToLower();
                return result;
            }
        }
    }
}