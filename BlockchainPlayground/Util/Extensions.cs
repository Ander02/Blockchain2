using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace BlockchainPlayground.Util
{
    public static class Extensions
    {
        public static byte[] GetSHA256(this byte[] data)
        {
            using (var sha = SHA256.Create())
            {
                var bytes = sha.ComputeHash(data);
                return bytes;
            }
        }
        
        public static string GetSHA256String(this byte[] data)
        {
            var bytes = GetSHA256(data);
            string result = "";
            foreach (var b in bytes)
                result += b.ToString("x");

            return result;
        }

        public static byte[] GetSHA256(this string data) => Encoding.UTF8.GetBytes(data).GetSHA256();
        public static string GetSHA256String(this string data) => GetSHA256String(GetSHA256(data));

        public static byte[] From64(this string data) => Convert.FromBase64String(data);

        public static string From64String(this string data) => Encoding.UTF8.GetString(From64(data));
        public static string To64(this byte[] data) => Convert.ToBase64String(data);

        public static string To64(this string data) => Convert.ToBase64String(Encoding.UTF8.GetBytes(data));

    }
}

