using System;
using System.IO;
namespace Homework_1._3
{
    class Program
    {
        static void Main(string[] args)
        {
            //locate the txt file using the location
            using (StreamReader sr = new StreamReader(@"D:\Homeland\CSC 340\Homework 1.3\Homework 1.3\red.txt"))
            {
                //reads the file at given location
                String line = sr.ReadToEnd();
                
                //loop that will count vowels
                int count = 0;
                for (int i = 0; i < line.Length; i++)
                {
                    if (line[i] == 'a')
                        count++;
                    if (line[i] == 'A')
                        count++;
                    if (line[i] == 'e')
                        count++;
                    if (line[i] == 'E')
                        count++;
                    if (line[i] == 'i')
                        count++;
                    if (line[i] == 'I')
                        count++;
                    if (line[i] == 'o')
                        count++;
                    if (line[i] == 'O')
                        count++;
                    if (line[i] == 'u')
                        count++;
                    if (line[i] == 'U')
                        count++;
                }
                //displays total
                Console.WriteLine("Vowels found in text file: {0}", count);
            }
        }
    }
}
