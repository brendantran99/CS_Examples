using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Array_Lists
{
    class Program
    {
        static void Main(string[] args)
        {
            ArrayList mylist = new ArrayList();
            mylist.Add(2019);
            mylist.Add("34");
            List<int> mylist2 = new List<int>();
            Console.WriteLine("size = {0}, capacity = {1}", mylist2.Count, mylist2.Capacity);
            mylist2.Add(23);
            Console.WriteLine("size = {0}, capacity = {1}", mylist2.Count, mylist2.Capacity);
            mylist2.Add(14);
            Console.WriteLine("size = {0}, capacity = {1}", mylist2.Count, mylist2.Capacity);
            mylist2.Add(90);
            Console.WriteLine("size = {0}, capacity = {1}", mylist2.Count, mylist2.Capacity);
            mylist2.Add(114);
            Console.WriteLine("size = {0}, capacity = {1}", mylist2.Count, mylist2.Capacity);
            mylist2.Add(420);
            Console.WriteLine("size = {0}, capacity = {1}", mylist2.Count, mylist2.Capacity);

            List2<int> myCustomList = new List2<int>();
            Console.WriteLine("size = {0}, capacity = {1}", myCustomList.count, myCustomList.capacity);
            myCustomList.AddBack(17);
            myCustomList.Print();
            Console.WriteLine("size = {0}, capacity = {1}", myCustomList.count, myCustomList.capacity);
            myCustomList.AddBack(18);
            myCustomList.Print();       
            Console.WriteLine("size = {0}, capacity = {1}", myCustomList.count, myCustomList.capacity);
            myCustomList.AddBack(19);
            myCustomList.Print();
            Console.WriteLine("size = {0}, capacity = {1}", myCustomList.count, myCustomList.capacity);
            myCustomList.AddBack(20);
            myCustomList.Print();
            Console.WriteLine("size = {0}, capacity = {1}", myCustomList.count, myCustomList.capacity);
            myCustomList.AddBack(21);
            myCustomList.Print();
            Console.WriteLine("size = {0}, capacity = {1}", myCustomList.count, myCustomList.capacity);
            myCustomList.AddFront(24);
            myCustomList.Print();
            Console.WriteLine("size = {0}, capacity = {1}", myCustomList.count, myCustomList.capacity);

            List2<string> myCustomList2 = new List2<string>();
            myCustomList2.AddBack("wild");
            myCustomList2.Print();
            Console.WriteLine("size = {0}, capacity = {1}", myCustomList2.count, myCustomList2.capacity);
            myCustomList2.AddBack("wild");
            myCustomList2.Print();
            Console.WriteLine("size = {0}, capacity = {1}", myCustomList2.count, myCustomList2.capacity);
            myCustomList2.AddFront("west");
            myCustomList2.Print();
            Console.WriteLine("size = {0}, capacity = {1}", myCustomList2.count, myCustomList2.capacity);
        }

        public class List2<T>
        {
            //data
            T[] data;
            public int capacity { get; private set; } //capacity of data -- data.length
            public int count { get; private set; } //the actual number of values in data

            //methods
            public void AddBack(T somevalue)
            {
                if(count == capacity)//if the array becomes full
                {
                    Resize();
                }
                
                data[count] = somevalue;
                count++;
            }
            public void AddFront(T somevalue)
            {
                Insert(0, somevalue);
                count++;
            }
            private void Resize()
            {
                if (capacity == 0)//if there is no array 
                {
                    data = new T[4];
                    capacity = 4;
                }
                else
                {
                    //double the capacity
                    T[] newData = new T[2 * capacity];
                    //copy values from old array into new one
                    for (int i = 0; i < count; i++)
                    {
                        newData[i] = data[i];
                    }
                    //call newdata to be data
                    data = newData;
                    capacity = 2 * capacity;
                }
                
            }
            public void Insert(int idx, T someValue)
            {
                if (idx < 0 || idx > count)
                    throw new Exception("uh oh");
                if(count == capacity)//if the array is full
                {
                    Resize();
                }
                for (int i = count - 1; i >= idx; i--)//shifts elements to the right
                {
                    data[i + 1] = data[i];
                }
                data[idx] = someValue; //plug in new value
            }
            public void Print()
            {
                for(int i = 0; i < count; i++)
                {
                    Console.Write(data[i] + " ");
                }
                Console.WriteLine();
            }
            public void DeleteFirst()
            {
                if (count == 0)
                    throw new Exception("the list is empty");
                for (int i = 1; i < count; i++)//shift all elements except for the first to the left
                {
                    data[i-1] = data[i];
                }
                count--;
            }
            public void DeleteBack()
            {
                if (count == 0)// if there is nothing in there
                    throw new Exception("the list is empty");
                else
                    count--;
            }
            public void Clear()
            {
                count = 0;
            }
            //constructor
            public List2()
            {
                capacity = 0;
                count = 0;
            }
        }
    }
}
