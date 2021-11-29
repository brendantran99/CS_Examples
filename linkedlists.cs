using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_4
{
    class Program
    {
        static void Main(string[] args)
        {
            Node myNode = new Node("carrot");
            Node myNode2 = new Node("arrow");
            SinglyLinkedList mylist = new SinglyLinkedList();
            Console.WriteLine("Is the list empty?  {0}", mylist.IsEmpty());
            mylist.AddFront("lemon");
            mylist.Print();
            mylist.AddFront("coffee");
            mylist.AddFront("pear");
            mylist.Print();
            mylist.AddBack("watermelon");
            mylist.AddBack("water");
            mylist.AddBack("guava");
            mylist.Print();
            mylist.Reverse();
            mylist.Insert("kiwi");
            mylist.Print();
            mylist.Delete("lemon");
            mylist.Print();
        }
    }
    class Node
    {
        //data
        public string data; //this is the value stored by a node
        public Node next;//this is a "link" to the next node

        //methods


        //constructors
        public Node(string newValue)
        {
            data = newValue;
            next = null;
        }
    }

    class SinglyLinkedList
    {
        //data
        Node head;

        //method - the api

        public void Insert(string someValue)//we assume the list is already sorted, and we want to maintain it sorted
        {
            if (IsEmpty())
                AddFront(someValue);
            else if (head.data.CompareTo(someValue) > 0)
                AddFront(someValue);
            else
            {
                Node newNode = new Node(someValue); //creating the new node

                Node finger = head;//move to the last node less than somevalue
                while (finger.next != null && finger.next.data.CompareTo(someValue) > 0)
                    finger = finger.next;

                newNode.next = finger.next;//1
                finger.next = newNode; //2
            }


        }

        public void Delete(string someValue)
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
                    finger = finger.next;//move right

                if (finger.next != null)
                    finger.next = finger.next.next;
            }


        }
        public void DeleteFront()
        {
            if (head != null)
                head = head.next;
            else
                throw new Exception("You cannot delete head from an empty list!");
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
            Node finger = head;
            while (finger.next.next != null)
                finger = finger.next;//moves right

            finger.next = null;//break the link to the last not null node

        }
        public bool IsEmpty()//O(1)
        {
            //if (head == null)
            //    return true;
            //else
            //    return false;
            return head == null;
        }
        public void Append(string newVal) //add to the end of the list - O(n)
        {
            if (IsEmpty())
            {
                AddFront(newVal);
            }
            else
            {
                Node newNode = new Node(newVal); //creates a new node

                Node finger = head;             //takes you to the last not-null node
                while (finger.next != null)
                    finger = finger.next;

                finger.next = newNode;          //links in the last node
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

        public void AddFront(string value)//O(1)
        {
            Node newNode = new Node(value);//creates the new box
            newNode.next = head;//link the node to the list
            head = newNode; //move the head of the list

        }

        public void AddBack(string value) // O(n)
        {
            Append(value); //this is the same as append - O(n)
        }

        //ctor(s)
        public SinglyLinkedList() //O(1)
        {
            head = null;
        }
    }
}
