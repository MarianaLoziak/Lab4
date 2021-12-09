using System;
using System.Collections.Generic;
using System.IO;
using Lab4.Part1;

namespace Lab4
{
    class Program
    {
        public static void Main(string[]args)
        {
            StreamWriter sw = new StreamWriter("C:\\Users\\user\\RiderProjects\\Lab4\\Lab4\\Files\\Passwords.txt");
            HumanPasswordGenerator gen = new ();
            List<string> passwords = new (); 
            Random random = new Random();
            for (int i = 0; i < 100000; i++)
            {
                string password = gen.Generate();
                sw.WriteLine(password);
                passwords.Add(password);

            }
            sw.Close();

            HasherMD5 md5 = new();
            md5.hashPasswords(passwords);

            SHA_1 sha = new SHA_1();
            sha.hashPasswords(passwords);

        }
    }
}