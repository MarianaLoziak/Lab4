using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace Lab4.Part1
{
    public class SHA_1
    {
        SHA1 sha1 = SHA1.Create();
        
        public static string GenerateSalt(int nSalt)
        {
            var saltBytes = new byte[nSalt];

            using (var provider = new RNGCryptoServiceProvider())
            {
                provider.GetNonZeroBytes(saltBytes);
            }

            return Convert.ToBase64String(saltBytes);
        }
        
        public void hashPasswords(List<String> passwords)
        {
            StreamWriter sw =
                new StreamWriter("C:\\Users\\user\\RiderProjects\\Lab4\\Lab4\\HashedPasswords\\HashedSHA1.csv");
            for (int i = 0; i < passwords.Count; i++)
            {
                string salt = GenerateSalt(32);
                byte[] hash = sha1.ComputeHash(Encoding.UTF8.GetBytes(passwords[i] + salt));
                sw.WriteLine(Convert.ToHexString(hash)+"\t"+salt);
            }
            sw.Close();
        }
    }
}