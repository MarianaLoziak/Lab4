using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;

namespace Lab4.Part1
{
    public class Generator
    {
        
        private string SOURCE = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789_!.";
        private List<string> top100 = new List<string>();
        private List<string> top1M = new List<string>();
        private HumanPasswordGenerator hm = new HumanPasswordGenerator();

        public Generator()
        {
            top100 = FillPasswordsList("../../../Files/Top100.txt");
            top1M = FillPasswordsList("../../../Files/Top1M.txt");
        }

        
        private Random random = new Random();
        public List<string> Generate()
        {
            Dictionary<int, int> indexator =new Dictionary<int, int>();
            indexator.Add(1,5);
            indexator.Add(2,60);
            indexator.Add(3,10);
            indexator.Add(4,25);
            List<string> passwords = new List<string>();
            for (int i = 0; i < 100000; i++)
            {
                int passTypeInd = random.Next(99) + 1;

                double currentTypeInd = 0;
                int fileNum = 0;
                while (fileNum < indexator.Count && passTypeInd > currentTypeInd)
                {
                    fileNum++;
                    currentTypeInd += indexator[fileNum];
                }

                if (fileNum == 1)
                {
                    passwords.Add(PasswordRandom());
                }else if (fileNum == 2)
                {
                    passwords.Add(GenerateFromTop(top1M));
                }else if (fileNum == 3)
                {
                    passwords.Add(GenerateFromTop(top100));
                }
                else
                {
                    passwords.Add(hm.Generate());
                }
            }

            return passwords;
        }

        public string PasswordRandom()
        {
            string password = "";
            int length = random.Next(5, 12);
            for (int i = 0; i < length; i++)
            {
                password += SOURCE[random.Next(SOURCE.Length)];
            }

            return password;
        }
        
        private List<string> FillPasswordsList(string fileName)
        {
            List<string> passwordsTop = new List<string>();
            StreamReader sr = new StreamReader(fileName);

            while (!sr.EndOfStream)
            {
                string password = sr.ReadLine();
                if (password.Length > 0)
                {
                    passwordsTop.Add(password);
                }
            }

            sr.Close();

            return passwordsTop;
        }

        private string GenerateFromTop(List<string> fromTop)
        {
          
            return fromTop[random.Next(fromTop.Count)];

        }
    }
}