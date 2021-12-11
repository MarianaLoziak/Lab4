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

        public void hashPasswords(List<String> passwords)
        {
            StreamWriter sw =
                new StreamWriter("../../../HashedPasswords/HashedSHA1.csv");
            for (int i = 0; i < passwords.Count; i++)
            {
                byte[] hash = sha1.ComputeHash(Encoding.UTF8.GetBytes(passwords[i]));
                sw.WriteLine(Convert.ToHexString(hash));
            }
            sw.Close();
        }
    }
}