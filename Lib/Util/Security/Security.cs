using System;
using System.Security.Cryptography;
using System.Text;

namespace OregoFramework.Tool
{
    public static class Security
    {
        public static string Encrypt(string input, string hash)
        {
            var utf8 = UTF8Encoding.UTF8;
            var data = utf8.GetBytes(input);
            using (var md5 = new MD5CryptoServiceProvider())
            {
                var key = md5.ComputeHash(utf8.GetBytes(hash));
                using (var trip = new TripleDESCryptoServiceProvider
                {
                    Key = key,
                    Mode = CipherMode.ECB,
                    Padding = PaddingMode.PKCS7
                })
                {
                    var tr = trip.CreateEncryptor();
                    var results = tr.TransformFinalBlock(data, 0, data.Length);
                    return Convert.ToBase64String(results, 0, results.Length);
                }
            }
        }

        public static string Decrypt(string input, string hash)
        {
            var data = Convert.FromBase64String(input);
            using (var md5 = new MD5CryptoServiceProvider())
            {
                var utf8 = UTF8Encoding.UTF8;
                var key = md5.ComputeHash(utf8.GetBytes(hash));
                using (var trip = new TripleDESCryptoServiceProvider
                {
                    Key = key,
                    Mode = CipherMode.ECB,
                    Padding = PaddingMode.PKCS7
                })
                {
                    var tr = trip.CreateDecryptor();
                    var results = tr.TransformFinalBlock(data, 0, data.Length);
                    return utf8.GetString(results);
                }
            }
        }
    }
}