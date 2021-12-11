using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using BCrypt.Net;
using BCryptH = BCrypt.Net.BCrypt;

namespace Lab4.Part1
{
    public class HasherBCrypt
    {
        

        public void hashPasswords(List<string> passwords)
        {
            StreamWriter sw =
                new StreamWriter("../../../HashedPasswords/HashedBCrypt.csv");
            for (int i = 0; i < passwords.Count; i++)
            {
                string hash = BCryptH.HashPassword(passwords[i], BCryptH.GenerateSalt());
                sw.WriteLine(hash);
            }
            sw.Close();
        }
    }
}