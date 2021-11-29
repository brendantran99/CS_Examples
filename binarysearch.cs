using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSC340._515_ch_6_BST
{
    class Program
    {
        static void Main(string[] args)
        {
            BST myTree = new BST();
            //Console.WriteLine(myTree.Max());

            Console.WriteLine(myTree.IsEmpty());
            myTree.Insert(7);
            myTree.Insert(17);
            myTree.Insert(4);
            myTree.Insert(1);
            myTree.Insert(7);
            myTree.Insert(-7);
            myTree.Insert(-77);
            Console.WriteLine(myTree.IsEmpty());
            Console.WriteLine(myTree.Contains(1));
            Console.WriteLine(myTree.Contains(2));
            Console.WriteLine(myTree.Max());
            Console.WriteLine(myTree.Min());

            myTree.PreOrderPrint();
            myTree.InOrderPrint();
            myTree.PostOrderPrint();
            int leaf = myTree.LeafCount();
            Console.WriteLine(leaf);
        }
    }

    class Node
    {
        //data
        public int value;
        public Node left, right;

        //methods
        //ctor
        public Node(int someValue)
        {
            value = someValue;
            //left = right = null;
        }
    }

    class BST
    {
        //data
        Node root;

        //methods
        public int LeafCount()
        {
            Console.WriteLine("The number of leaves is...");//call the method below 
            return LeafCountHelper(root);
        }
        public int LeafCountHelper(Node finger)
        {
            if (finger == null)
                return 0;
            else if (finger.left == null && finger.right == null)//check if node has any more children
                return 1;
            else
                return LeafCountHelper(finger.left) + LeafCountHelper(finger.right);//add up the results using recursion
        }
        public Boolean IsEmpty()
        {
            //if (root == null)
            //    return true;
            //else
            //    return false;
            return root == null;
        }

        public void Insert(int someValue)
        {
            Node newNode = new Node(someValue);//create a new node

            if(IsEmpty())
            {
               
                root = newNode;
            }
            else
            {
                Node finger = root;
                while(true)
                {
                    if (someValue <= finger.value)
                    {
                        if(finger.left!=null) //if there is a left child
                            finger = finger.left; //move left
                        else
                        {
                            finger.left = newNode;//link the new node to the left
                            return; //I'm done
                        }
                    }
                    else
                    {
                        if(finger.right!=null)//there is a right child
                        {
                            finger = finger.right;
                        }
                        else
                        {
                            finger.right = newNode;
                            return;
                        }
                    }
                        
                }
            }
        }

        public bool Contains(int key)
        {
            Node finger = root;
            while (finger != null)
            {
                if (key == finger.value)
                    return true;//found it!!!!
                else if (key <= finger.value)
                    finger = finger.left;
                else
                    finger = finger.right;
            }
            return false; //only leave the loop if key was not found

        }

        public int Max()
        {
            if (IsEmpty())
            {
                throw new Exception("no Max in an empty BST");
            }
            else
            {
                Node finger = root;
                while (finger.right != null) //as long as there is a right child
                    finger = finger.right;  //then move right

                return finger.value;
            }
        }

        public int Min()
        {
            if (IsEmpty())
            {
                throw new Exception("no Min in an empty BST");
            }
            else
            {
                Node finger = root;
                while (finger.left != null) //as long as there is a left child
                    finger = finger.left;  //then move left

                return finger.value;
            }
        }

        public void PreOrderPrint()
        {
            Console.WriteLine("Displaying PREORDER ...");
            PreOrderHelper(root);
            Console.WriteLine();
        }

        public void PreOrderHelper(Node finger) //N L R
        {
            if (finger != null)
            {
                Console.Write(finger.value+" ");//N
                PreOrderHelper(finger.left);//L
                PreOrderHelper(finger.right);//R
            }
        }


        public void InOrderPrint()
        {
            Console.WriteLine("Displaying IN ORDER ...");
            InOrderHelper(root);
            Console.WriteLine();
        }

        public void InOrderHelper(Node finger) // L N R
        {
            if (finger != null)
            {
                InOrderHelper(finger.left);//L
                Console.Write(finger.value + " ");//N
                InOrderHelper(finger.right);//R
            }
        }


        public void PostOrderPrint()
        {
            Console.WriteLine("Displaying POSTORDER ...");
            PostOrderHelper(root);
            Console.WriteLine();
        }

        public void PostOrderHelper(Node finger) // L R N
        {
            if (finger != null)
            {
                PostOrderHelper(finger.left);//L
                PostOrderHelper(finger.right);//R
                Console.Write(finger.value + " ");//N
            }
        }
        //ctor(s)
        public BST()
        {
            //root = null;
        }
    }
}
