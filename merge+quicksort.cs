using System;

namespace Sorting_Part_2
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] values = { 98, 6, 5, 15, 101, 1, -2 };
            QuickSort(values);
            PrintArray(values);
        }

        static void QuickSort(int[] arr)
        {
            QuickSortHelper(arr, 0, arr.Length - 1);
        }

        static void QuickSortHelper (int[] arr, int startIdx, int endIdx)
        {
            if(startIdx < endIdx)
            {
                int q = Partition(arr, startIdx, endIdx);
                //partition will return new position of the pivot
                QuickSortHelper(arr, startIdx, q - 1);
                QuickSortHelper(arr, q + 1, endIdx);
            }
        }
        static int Partition(int[] arr, int startIdx, int endIdx)
        {
            //selecting a pivot
            int pivot = arr[endIdx];
            int i = startIdx - 1;
            for (int j = startIdx; j < endIdx; j++) //j goes through all values in array
            {
                if(arr[j] <= pivot)
                {
                    i++; //move i over
                    //swap arr[i] with arr[j]
                    int tmp = arr[i];
                    arr[i] = arr[j];
                    arr[j] = tmp;
                }
            }
            int tmp2 = arr[i + 1];
            arr[i + 1] = arr[endIdx];
            arr[endIdx] = tmp2;
            return i + 1;
        }

        static void PrintArray(int[] arr)
        {
            Console.WriteLine();
            foreach (int num in arr)
                Console.Write(num + " ");
            Console.WriteLine();
        }

        static void MergeSort(int[] arr)
        {
            int count = 0;
            MergeSortHelper(arr, 0, arr.Length - 1, ref count);
            Console.WriteLine("counter = {0}", count);
        }
        static void MergeSortHelper(int[] arr, int startIdx, int endIdx, ref int count)
        {
            if (startIdx < endIdx) //if the array has more than 2 elements
            {
                int middleIdx = (startIdx + endIdx) / 2;
                MergeSortHelper(arr, startIdx, middleIdx, ref count); //sort first half
                MergeSortHelper(arr, middleIdx + 1, endIdx, ref count); //sort second half
                MergeSubArrays(arr, startIdx, middleIdx, middleIdx + 1, endIdx, ref count);
                //merge the 2 sub arrays
            }
        }
        //O(n)
        static void MergeSubArrays (int[] arr, int startA, int endA, int startB, int endB, ref int count)
        {
            int[] tmp = new int[arr.Length];
            int i = startA; 
            int j = startB;
            int k = startA;

            while(i <= endA && j <= endB)
            {
                count++;
                if (arr[i] <= arr[j])
                {
                    tmp[k] = arr[i];
                    i++;
                    k++;
                }
                else
                {
                    /*tmp[k] = arr[j];
                    j++;
                    k++; */
                    tmp[k++] = arr[j++];
                }
            }

            //now copy the leftover elements
            while (i <= endA)
            {
                tmp[k] = arr[i];
                i++;
                k++;
            }
            while (j <= endB)
            {
                tmp[k] = arr[j];
                j++;
                k++;
            }
            //put all elements from tmp into arr
            for (k = startA; k <= endB; k++)
                arr[k] = tmp[k];
        }
    }
}
