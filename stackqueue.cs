using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_4._2
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<int> myQueue = new Queue<int>();
            //create new queue
            myQueue.Enqueue(1);
            myQueue.Enqueue(2);
            myQueue.Enqueue(3);
            myQueue.Enqueue(4);
            myQueue.Enqueue(5);
            myQueue.Enqueue(6);
            //put things into queue
            Stack myStack = new Stack();
            //create new stack
            foreach (int S in myQueue)
            {
                Console.WriteLine(S);
            }
            //print the queue
            myStack.Push(myQueue.Dequeue());
            myStack.Push(myQueue.Dequeue());
            myStack.Push(myQueue.Dequeue());
            myStack.Push(myQueue.Dequeue());
            myStack.Push(myQueue.Dequeue());
            myStack.Push(myQueue.Dequeue());
            //push the items that are dequeued into the stack
            foreach (int S in myStack)
            {
                myQueue.Enqueue(S);
                Console.WriteLine(S);
            }
            //print the stack
        }
    }
    class StackUsingQueue
    {
        //data
        Queue<int> data;

        //methods
        public void Push(int value) //O(n)
        {
            data.Enqueue(value); //put the data into the queue
            for (int i = 0; i < data.Count - 1; i++)//use the loop to queue the dequeued data
                data.Enqueue(data.Dequeue());
        }
        //every element in the queue's data will be pushed onto the stack
        public void Pop() //O(1)
        {
            data.Dequeue();
        }
        //dequeue is the same as pop in this function
        public int Peek() //O(1)
        {
            return data.Peek(); //return the data to see what is at the top
        }
        //returns the data of the top of the stack
        public bool IsEmpty() //O(1)
        {
            return data.Count == 0;
        }
        //constructor
        public StackUsingQueue()
        {
            data = new Queue<int>();
        }
    }

    class Node
    {
        //data
        public int data; //this is the value stored by a node
        public Node next;//this is a "link" to the next node
        public Node previous;//this is a "link" to the previous node

        //constructors
        public Node(int newValue)
        {
            data = newValue;
            next = null;
            previous = null;
        }
    }

    class SinglyLinkedList
    {
        //data
        public Node head;

        //method - the api

        public void Insert(int someValue)//we assume the list is already sorted, and we want to maintain it sorted
        {
            if (IsEmpty())//if the list is empty just add the value to the front
                AddFront(someValue);
            else if (head.data > someValue)//if the head is greater than the value being inserted, it will be added to the front
                AddFront(someValue);
            else
            {
                Node newNode = new Node(someValue); //creating the new node

                Node finger = head;//move to the last node less than somevalue
                while (finger.next != null && finger.next.data < someValue)
                    finger = finger.next;//point the finger to the right

                newNode.next = finger.next;//1
                finger.next = newNode; //2
            }
        }

        public void Delete(int someValue)
        {
            if (IsEmpty())          //if we have no nodes
                return;//do nothing if the list is empty
            else if (head.data == someValue)
                DeleteFront();
            else if (head.next == null) //if we have only one node, it will be pointed to null
            {
                if (head.data == someValue)
                    head = null;
            }
            else                      //if we have at least two nodes
            {
                Node finger = head;
                while (finger.next != null && finger.next.data != someValue)
                    finger = finger.next;//move right

                if (finger.next != null)//if the next node isn't empty, it will move right
                    finger.next = finger.next.next;
            }

        }
        public void DeleteFront()
        {
            if (head != null)
                head = head.next;//the head is now moved one to the right
            else//if the null is empty
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
        public void Append(int newVal) //add to the end of the list - O(n)
        {
            if (IsEmpty())
            {
                AddFront(newVal);
            }
            else
            {
                Node newNode = new Node(newVal); //creates a new node

                Node finger = head;             //takes you to the last not-null node
                while (finger.next != null)//makes sure there is space to the right to move
                    finger = finger.next;

                finger.next = newNode;          //links in the last node
            }
        }


        public void Print() //O(n)
        {

            Console.WriteLine();
            Node finger = head;
            while (finger != null)//loop that goes through the list and will print the most recent iteration
            {
                Console.Write(finger.data + " ");
                finger = finger.next;
            }

            Console.WriteLine();
        }

        public void AddFront(int value)//O(1)
        {
            Node newNode = new Node(value);//creates the new box
            newNode.next = head;//link the node to the list
            head = newNode; //move the head of the list

        }

        public void AddBack(int value) // O(n)
        {
            Append(value); //this is the same as append - O(n)
        }

        //ctor(s)
        public SinglyLinkedList() //O(1)
        {
            head = null;
        }
    }

    class DynamicStack
    {
        //data
        SinglyLinkedList values;

        //methods
        public void Push(int value) //O(1)
        {
            values.AddFront(value);//runs in O(1)
        }
        //addfront method of the list is the same as push in this case
        public void Pop()
        {
            if (IsEmpty())
            {
                Console.WriteLine("you cannot pop from am empty stack");
                //checks if the list is empty 
            }
            else
            {
                values.DeleteFront();
                //uses the delete front function from the lists as the pop function
            }
                
        }
        public int Peek()
        {
            if (IsEmpty())
                throw new Exception("you cannot peek from am empty stack");
            else
            {
                return values.head.data;
                //returns the data from the top of the list
            }               
        }
        public bool IsEmpty()
        {
            return values.IsEmpty();
            //in case its empty
        }
        public void Print()
        {
            values.Print();
        }
        //ctor
        public DynamicStack()
        {
            values = new SinglyLinkedList();//creates an empty linked list to store the values of the stack
        }
    }

    class DynamicQueue
    {
        //data
        DoublyLinkedList values;

        //methods
        public bool IsEmpty()
        {
            return values.IsEmpty();
        }

        public void Enqueue(int value) //O(1)
        {
            values.AddBack(value);//O(1)
            //putting something into the queue acts as the same as the addback function in lists
        }

        public void Dequeue()
        {
            values.DeleteFront();//O(1)
            //acts the same as the deletefront function in lists
        }

        public int Peek()//return the value from the top of the queue
        {
            return values.head.data;//O(1)
        }
        //ctor
        public DynamicQueue()
        {
            values = new DoublyLinkedList();
        }
    }

    class DoublyLinkedList
    {
        //data
        public Node head;
        public Node tail;

        //method - the api

        public void Insert(int someValue)
        {
            if (IsEmpty())
                AddFront(someValue);
            else if (head.data > someValue)//if the head is larger than the value, it will be added to the front
                AddFront(someValue);
            else
            {
                Node newNode = new Node(someValue); //creating the new node

                Node finger = head;//move to the last node less than somevalue
                while (finger.next != null && finger.next.data < someValue)
                    finger = finger.next;//move right 

                newNode.next = finger.next;//1
                finger.next = newNode; //2
            }
        }

        public void Delete(int someValue)
        {
            if (IsEmpty())          //if we have no nodes
                return;//do nothing if the list is empty
            else if (head.data == someValue)//if the head matches the value in the parameter
                DeleteFront();
            else if (head.next == null) //if we have only one node
            {
                if (head.data == someValue)
                    head = null;//point the head to null
            }
            else                      //if we have at least two nodes
            {
                Node finger = head;
                while (finger.next != null && finger.next.data != someValue)
                    finger = finger.next;//move right

                if (finger.next != null)
                    finger.next = finger.next.next;//finger now points to the right 
            }


        }//tbd
        public void DeleteFront()
        {
            if (head != null)
                head = head.next;//point the head to the right 
            else//if the next node is null
                throw new Exception("You cannot delete head from an empty list!");
        } 

        public void DeleteBack() //O(n)
        {
            if (IsEmpty())
            {
                throw new Exception("You cannot delete the end of an empty list!");
            }
            else if (head.next == null)//we only have one element in the list
            {
                head = null;
                tail = null;
            }
            else
            {
                tail.previous.next = null;//the node pointing to the right is now null
                tail = tail.previous;//move tail to the left
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
        public void Append(int newVal) //add to the end of the list - O(1)
        {
            if (IsEmpty())
            {
                AddFront(newVal);//simply add the node to the front since positioning doesn't matter
            }
            else
            {
                Node newNode = new Node(newVal); //creates a new node

                tail.next = newNode;            //links in the last node
                newNode.previous = tail;

                tail = tail.next;               //moves the tail
            }
        }


        public void PrintReverse() //O(n)
        {

            Console.WriteLine();
            Node finger = tail; //change the pointer
            while (finger != null)
            {
                Console.Write(finger.data + " ");
                finger = finger.previous;//finger now points to the left
            }

            Console.WriteLine();
        }

        public void Print() //O(n)
        {

            Console.WriteLine();
            Node finger = head;
            while (finger != null)//create loop that goes through the list and prints each element
            {
                Console.Write(finger.data + " ");
                finger = finger.next;
            }

            Console.WriteLine();
        }

        public void AddFront(int value)//O(1)
        {
            Node newNode = new Node(value);//creates the new box

            if (IsEmpty())//adds node to empty list
            {
                head = newNode;
                tail = newNode;
            }
            else
            {
                newNode.next = head;//link the node to the list
                head.previous = newNode;//assign the new element to the left of the head
                head = newNode; //move the head of the list
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
            tail = null;
        }
    }
}
