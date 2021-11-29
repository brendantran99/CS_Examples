using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Homework_3
{
    class Program
    {
        static void Main(string[] args)
        {
            //establishing individual strings to contain the file text
            string[] myArr1 = File.ReadAllLines("input.txt");
            string[] myArr2 = File.ReadAllLines("input.txt");
            string[] myArr3 = File.ReadAllLines("input.txt");

            //calling each method to act upon the various strings
            BubbleReverseSort(myArr1); //O(n^2)
            SelectionReverseSort(myArr1); //O(n^2)
            MergeReverseSort(myArr1); //O(nlogn)

            BubbleReverseSort(myArr2); 
            SelectionReverseSort(myArr2);
            MergeReverseSort(myArr2);

            BubbleReverseSort(myArr3); 
            SelectionReverseSort(myArr3);
            MergeReverseSort(myArr3);  
        }
        //running time is O(n^2)
        public static void BubbleReverseSort(string[] values)
        {
            int count = 0;
            for (int i = 0; i < values.Length - 1; i++)
            {
                for (int position = 0; position < values.Length - 1 - i; position++)
                {
                    if (string.Compare(values[position], values[position + 1]) < 0) 
                     //if values aren't in the right order they are swapped
                    {
                        string tmp = values[position];
                        values[position] = values[position + 1];
                        values[position + 1] = tmp;                        
                    }
                    count++;

                }
            }
            Console.WriteLine("BubbleReverseSort was looped {0} times", count);
        }
        public static void SelectionReverseSort(string[] values)
        {
            int count = 0;
            for (int i = 0; i < values.Length - 1; i++)
            {
                int posMin = i;
                for (int pos = i + 1; pos < values.Length; pos++)
                {
                    count++;
                    //The inequality is reversed to get the string to be organized backwards 
                    //this also allowed for the ability to work on strings 
                    if (string.Compare(values[pos], values[posMin]) > 0)
                        posMin = pos;
                }
                string tmp = values[i];
                values[i] = values[posMin];
                values[posMin] = tmp;
            }
            Console.WriteLine("SelectionReverseSort was looped {0} times", count);
        }
        public static void MergeReverseSort(string[] values)
        {
            //this int was established here and passes through the next two functions to be able to count the loops
            int mergecount = 0;
            string[] tmp = new string[values.Length];
            MergeSortHelper(values, 0, values.Length - 1, tmp, ref mergecount);
            Console.WriteLine("MergeReverseSort was looped {0} times", mergecount);
        }
        private static void MergeSortHelper(string[] values, int start, int end, string[] tmp, ref int mergecount)
        {
            if (start < end)
            {
                //the ref int allows for the passing of the variable
                int middle = (start + end) / 2;
                MergeSortHelper(values, start, middle, tmp, ref mergecount);
                MergeSortHelper(values, middle + 1, end, tmp, ref mergecount);
                MergeSubArrays(values, start, middle, middle + 1, end, tmp, ref mergecount);
            }
        }
        public static void MergeSubArrays(string[] values, int startA, int endA, int startB, int endB, string[] tmp, ref int mergecount)
        {
           //establish variables
            int i = startA;
            int j = startB;
            int k = startA;
            while (i <= endA && j <= endB)
            {
                //this statement allows for the comparison of variables
                if (string.Compare(values[i], values[j]) > 0)
                {
                    mergecount++;
                    tmp[k] = values[i];
                    i++;
                    k++;
                }
                else
                {
                    mergecount++;
                    tmp[k] = values[j];
                    j++;
                    k++;
                }

            }
            //this is where the actual strings get swapped to be in the right order
            while (i <= endA)
            {
                tmp[k] = values[i];
                i++;
                k++;
            }
            while (j <= endB)
            {
                tmp[k] = values[j];
                j++;
                k++;
            }
            for (int h = startA; h <= endB; h++)
            { values[h] = tmp[h]; }
            
        }

    }
}
