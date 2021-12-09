using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace Lab4.Part1
{
    
    public class HasherMD5
    {
        private MD5 md5 = MD5.Create();
        public void hashPasswords(List<String> passwords)
        {
            StreamWriter sw =
                new StreamWriter("C:\\Users\\user\\RiderProjects\\Lab4\\Lab4\\HashedPasswords\\HashedMD5.csv");
            for (int i = 0; i < passwords.Count; i++)
            {
                byte[] hash = md5.ComputeHash(Encoding.UTF8.GetBytes(passwords[i]));
                sw.WriteLine(Convert.ToHexString(hash));
            }
            sw.Close();
        }
        
    }
}