using System;
using System.Collections.Generic;
using System.IO;
using Lab4.Part1;

namespace Lab4
{
    class Program
    {
        public static void Main(string[]args)
        { /*StreamWriter sw = new StreamWriter("../../../Files/Passwords.txt");
            Generator gen = new Generator();
            List<string> passwords = gen.Generate();
            
            foreach (var password in passwords)
            {
                sw.WriteLine(password);
            }
        
            sw.Close();*/


            List<string> passwords = readPasswords("../../../Files/Passwords.txt");
            HasherMD5 md5 = new();
            md5.hashPasswords(passwords);

            SHA_1 sha = new SHA_1();
            sha.hashPasswords(passwords);

            /*HasherBCrypt bc = new HasherBCrypt();
            bc.hashPasswords(passwords);*/
        }

        public static List<string> readPasswords(string fileName)
        {
            List<string> passwords = new List<string>();
            StreamReader sr = new StreamReader(fileName);

            while (!sr.EndOfStream)
            {
                string password = sr.ReadLine();
                if (password.Length > 0)
                {
                    passwords.Add(password);
                }
            }

            sr.Close();
            return passwords;
        }
    }
}