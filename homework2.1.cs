using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Homework2._1
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] fruit = { "apple", "orange", "peach" };
            string[] veggies = { "tomatoes", "lettuce", "cabbage", "pepper", "cellery", "onion", "cucumber", "carrot", "raddish"};
            SeqSearch(fruit, "orange");
            BinSearch(veggies, "cellery");
            //to read all the lines of the appointed txt file
            string[] words = File.ReadAllLines("words.txt");
            Console.WriteLine("Input a word to be searched");
            //applies the users input into the method
            string userword = Console.ReadLine();
            SeqSearch(words, userword);
            BinSearch(words, userword);
        }

        static void SeqSearch(string[] values, string key)
        {
            //counter value
            int count = 0;
            //traverse the array
            for (int pos = 0; pos < values.Length; pos++)
            {

                //check if current value in the array is the same as key
                if (values[pos] == key)
                {
                    Console.WriteLine("Found at position:{0}", pos);
                    //every time this loop is run the counter will increase by 1
                    count++;
                    break;
                }
                else if (values[pos] != key)
                {
                    count++;
                }
                if (count >= 20845)
                {
                    //safety net if a value is not found
                    count++;
                    Console.WriteLine("Not found");
                }
                Console.WriteLine("Loop 1 was run " + count + " times");
                
            }
        }

        static void BinSearch(string[] arr, string key)
        {
            {
                int count = 0;
                int l = 0, r = arr.Length - 1;
                while (l <= r)
                {
                    int m = l + (r - l) / 2;

                    int res = key.CompareTo(arr[m]);

                    // Check if x is present at mid  
                    if (res == 0)
                    {
                        Console.WriteLine("Found by loop 2");
                        count++;
                    }

                    // If x greater, ignore left half  
                    if (res > 0)
                    {
                        l = m + 1;
                        count++;
                    }

                    // If x is smaller, ignore right half  
                    else
                    {
                        r = m - 1;
                        count++;
                    }
                    if (count > 17)
                    {
                        Console.WriteLine("Not found by loop 2");
                    }
                }
                Console.WriteLine("Loop 2 was run " + count + " times");
            }
        }
    }
}
