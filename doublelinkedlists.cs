using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_4._1
{
    class Program
    {
        static void Main(string[] args)
        {
            Node myNode = new Node(36);
            Node myNode2 = new Node(7);

            DoublyLinkedList mylist = new DoublyLinkedList();
            Console.WriteLine("Is the list empty?  {0}", mylist.IsEmpty());
            mylist.AddFront(1);
            mylist.Print();
            mylist.AddFront(2);
            mylist.AddFront(3);
            mylist.Print();
            mylist.AddBack(10);
            mylist.AddBack(20);
            mylist.AddBack(30);
            mylist.Insert(15);
            mylist.Reverse();
            mylist.Print();
            mylist.printReverse();
            mylist.Print();
            mylist.DeleteFront();
            mylist.Print();
        }
    }
    class Node
    {
        //data
        public int data; //this is the value stored by a node
        public Node next;//this is a "link" to the next node
        public Node previous;

        //methods


        //constructors
        public Node(int newValue)
        {
            data = newValue;
            next = null;
            previous = null;
        }
    }

    class DoublyLinkedList
    {
        //data
        Node head;
        Node tail;

        //method - the api

        public void Insert(int someValue)//we assume the list is already sorted, and we want to maintain it sorted
        {
            if (IsEmpty())
                AddFront(someValue);
            else if (head.data < someValue)
                AddFront(someValue);
            else
            {
                Node newNode = new Node(someValue); //creating the new node

                Node finger = head;//move to the last node less than somevalue
                tail = head.previous;
                while (finger.next != null && finger.next.data < someValue)
                    finger = finger.next;

                if(finger.next != null)
                {
                    newNode.next = finger.next;//1
                    finger.next = newNode; //2

                    newNode.next.previous = newNode;
                    newNode.previous = finger;
                }
                else
                {
                    finger.next = newNode;
                    newNode.previous = finger;
                    tail = newNode;
                }
               
            }
        }
        public void Delete(int someValue)
        {
            if (IsEmpty())          //if we have no nodes
                return;//do nothing if the list is empty
            else if (head.data == someValue)
                DeleteFront();
            else if (head.next == null) //if we have only one node
            {
                if (head.data == someValue)
                    head = null;
            }
            else                      //if we have at least two nodes
            {
                Node finger = head;
                while (finger.next != null && finger.next.data != someValue)
                {
                    finger = finger.next;
                }
                if (finger.next != null)
                {
                    finger.next = finger.next.next;
                    finger.previous = finger.next;
                }               
                else if (finger.next == null)
                {
                    finger.previous = tail;
                    finger.previous = finger;
                }
                else if (finger.previous == null)
                {
                    finger.next = finger;
                }
            }


        }
        public void DeleteFront()
        {
            if (head != null)
            {
                if(head.next == null)//if there is only one node
                {
                    head = null;
                    tail = null;
                }
                else
                {
                    head = head.next;
                    head.previous = null;
                }
            }
            else
            {
                throw new Exception("You cannot delete head from an empty list!");
            }                
        }
        public void DeleteBack() //O(n)
        {
            if (IsEmpty())
            {
                throw new Exception("You cannot delete the end of an empty list!");
            }
            else if (head.next == null)
            {
                DeleteFront();//head = null;
            }
            else
            {
                tail = tail.previous;
                tail.next = null;
            }

        }
        public bool IsEmpty()//O(1)
        {
            //if (head == null)
            //    return true;
            //else
            //    return false;
            return head == null;
        }
        public void Append(int newVal) //add to the end of the list - O(n)
        {
            if (IsEmpty())
            {
                AddFront(newVal);
            }
            else
            {
                Node newNode = new Node(newVal);
                tail.next = newNode;
                newNode.previous = tail;
                tail = newNode;
            }
        }
        public void Print() //O(n)
        {

            Console.WriteLine();
            Node finger = head;
            while (finger != null)
            {
                Console.Write(finger.data + " ");
                finger = finger.next;
            }

            Console.WriteLine();
        }

        public void Reverse()//O(n)
        {
            Node current = head;
            Node prev = null, next = null;

            while (current != null)
            {
                next = current.next;
                current.next = prev;
                prev = current;
                current = next;
            }
            head = prev;
        }
         public void printReverse()
         {
            Reverse();
            Print();
         }

        public void AddFront(int value)//O(1)
        {
            Node newNode = new Node(value);//creates the new box
            newNode.next = head;//link the node to the list
            newNode.previous = null;
            head = newNode; //move the head of the list
            if (head != null)
            {
                head.previous = newNode;
            }

        }

        public void AddBack(int value) // O(n)
        {
            Append(value); //this is the same as append - O(n)
        }

        //ctor(s)
        public DoublyLinkedList() //O(1)
        {
            head = null;
        }
    }
}
