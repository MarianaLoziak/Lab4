using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Lab4.Part1
{
    public class HumanPasswordGenerator
    {
        private List<string> names = FillListFromFile("C:\\Users\\user\\RiderProjects\\Lab4\\Lab4\\Files\\Names.txt");
        private List<string> words = FillListFromFile("C:\\Users\\user\\RiderProjects\\Lab4\\Lab4\\Files\\Names.txt");
        private List<string> keyboard = FillListFromFile("C:\\Users\\user\\RiderProjects\\Lab4\\Lab4\\Files\\Keyboard.txt");
        private string symbols = "!@#$%^&*-_";
        private Dictionary<char, char> replace = new Dictionary<char, char>()
        {
            { 'o', '0' }, { 'e', '3' }, { 's', '5' }, { 'i', '1' }, { 'g', '9' },
            { 'O', '0' }, { 'E', '3' }, { 'S', '5' }, { 'I', '1' }, { 'B', '8' }, { 'G', '6' },
            { 'A', '4' }, { '0', 'O' }, { '5', 'S' }, { '8', 'B' }, { '9', 'g' }, { '1', 'I' },
        };
        private Random random = new();

        public string Generate()
        {
            string password = "";
            int r = random.Next(0, 100);
            if (r < 20)
            {
                password = PasswordWithDateOnly();
            }else if (r >= 20 && r < 40)
            {
                password = PasswordWithWords();
            }else if (r >= 40 && r < 60)
            {
                password = PasswordWithName();
            }else if (r >= 60 && r < 80)
            {
                password = PasswordWithNumberOnly();
            } else
            {
                password = PasswordWithKeyPattern();
            }

            return UpgradePassword(password);
        }


        private string PasswordWithWords()
        {
            string password = "";
            string word = words[random.Next(0, words.Count)];
            int flag = random.Next(0, 125);
            if (flag <= 25)
            {
                password = word + symbols[random.Next(0, symbols.Length)] + random.Next(0, 2022);
            } 
            if (flag > 25 && flag <= 50)
            {
                password = random.Next(0, 2022) + symbols[random.Next(0, symbols.Length)] + word;
            }

            if (flag > 50 && flag <= 75)
            {
                password = random.Next(0, 2022) + word;
            }

            if (flag > 75 && flag <= 100)
            {
                password =  word + random.Next(0, 2022) ;
            }

            if (flag > 100)
            {
                password = word + words[random.Next(0, words.Count)];
                if (password.Length < 10)
                {
                    password+= words[random.Next(0, words.Count)];
                }
            }
            password = ChangeLetterRegister(password);
            return password;
        }
        private string PasswordWithName()
        {
            string password = "";
            string name = names[random.Next(0,names.Count)];
            
            int flag = random.Next(0, 100);
            if (flag <= 25)
            {
                password = name + symbols[random.Next(0, symbols.Length)] + random.Next(0, 2022);
            } 
            if (flag > 25 && flag <= 50)
            {
                password = random.Next(0, 2022) + symbols[random.Next(0, symbols.Length)] + name;
            }

            if (flag > 50 && flag <= 75)
            {
                password = random.Next(0, 2022) + name;
            }

            if (flag > 75)
            {
                password =  name + random.Next(0, 2022) ;
            }

            password = ChangeLetterRegister(password);
            return password;
        }


        private string PasswordWithKeyPattern()
        {
            string password = "";
            string keyPattern = keyboard[random.Next(0, keyboard.Count)];
            string word = words[random.Next(0, words.Count)];
            int number = random.Next(0, 10000);

            if (random.NextDouble() > 0.5)
            {
                password = word + keyPattern;
            }
            else
            {
                password = keyPattern + number;
            }
            password = ChangeLetterRegister(password);
            return password;

        }

        public string PasswordWithNumberOnly()
        {
            string numbers = "0123456789";
            string password = "";
            int r = random.Next(6, 11);
            for (int i = 0; i < r; i++)
            {
                password += numbers[random.Next(0, numbers.Length)];
            }

            return password;
        }

        private string PasswordWithDateOnly()
        {
            string password = "";
            int r = random.Next(0, 4);
            int day = random.Next(1,31);
            int month = random.Next(1,13);
            int year = random.Next(1, 2021);
            if (r == 0)
            {
                password = day + "." + month + year;
            } else if (r == 1)
            {
                password = day + "." + month + "." + year;
            } else if (r == 2)
            {
                password =  day.ToString() + month.ToString() + year.ToString();
            }
            else
            {
                password = year + "." + month + "." + day;
            }
            return password;
        }

        private string UpgradePassword(string password)
        {
            string result = "";
            for (int i = 0; i < password.Length; i++)
            {
                if (replace.ContainsKey(password[i])&&random.NextDouble()<0.2)
                {
                    result += replace[password[i]];
                }
                else
                {
                    result += password[i];
                }

            }

            return result;
        }

        public string ChangeLetterRegister(string line)
        {
            string result = "";
            int r = random.Next(0, 4);
            switch (r)
            {
                case 0:
                {
                    result = line.ToUpper();
                    break;  
                }
                case 1:
                {
                    result = line.ToUpper();
                    break; 
                }
                case 2:
                {
                    for (int i = 0; i < line.Length; i++)
                    {
                        if (random.NextDouble() < 0.5)
                        {
                            result += line[i].ToString().ToUpper();
                        }
                        else
                        {
                            result += line[i].ToString().ToLower();
                        }
                    }
                    break;
                }
                case 3:
                {
                    result = line.First().ToString().ToLower() + string.Join("", line.Skip(1));
                    break;
                }
                    
            }

            return result;
        }
        private static List<string> FillListFromFile(string path)
        {
            List<string> output = new ();
            StreamReader sr = new (path,Encoding.Default);
            while(!sr.EndOfStream){
                output.Add(sr.ReadLine());
            }
            sr.Close();

            return output;
        }
    }
    
    
}