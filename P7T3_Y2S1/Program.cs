using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace P7T3_Y2S1
{
    internal class Program
    {
        public static LinkedList finalList = new LinkedList();

        static void Main(string[] args)
        {
            LinkedList list1 = new LinkedList();
            LinkedList list2 = new LinkedList();
            String sline;


            Console.WriteLine("Enter String for List 1:");
            sline = Console.ReadLine();
            char[] chara1 = new Char[sline.Length];
            chara1 = sline.ToCharArray();
            for (int i = 0; i < chara1.Length; i++)
            {
                list1.InsertAtLast(chara1[i]);
            }
            list1.DisplayAll();
            Console.WriteLine();
            if (list1.head != null)
            {
                Console.WriteLine("Head: " + list1.head.Cargo.ToString());
            }
            else
            {
                Console.WriteLine("Head: null");
            }
            if (list1.head != null)
            {
                Console.WriteLine("Tail: " + list1.tail.Cargo.ToString());
            }
            else
            {
                Console.WriteLine("Tail: null");
            }

            Console.WriteLine("Enter String for List 2:");
            sline = Console.ReadLine();
            char[] chara2 = new Char[sline.Length];
            chara2 = sline.ToCharArray();
            for (int i = 0; i < chara2.Length; i++)
            {
                list2.InsertAtLast(chara2[i]);
            }
            list2.DisplayAll();
            Console.WriteLine();
            if (list2.head != null)
            {
                Console.WriteLine("Head: " + list2.head.Cargo.ToString());
            }
            else
            {
                Console.WriteLine("Head: null");
            }
            if (list2.head != null)
            {
                Console.WriteLine("Tail: " + list2.tail.Cargo.ToString());
            }
            else
            {
                Console.WriteLine("Tail: null");
            }
            Node newnode = finalList.Concatenate(list1.head, list2.head);
            while (newnode != null)
            {
                Console.WriteLine(newnode.Cargo);
                newnode = newnode.next;
            }
            //finalList.head = Concatenate(list1.head,list2.head);
            Console.WriteLine();
            Console.WriteLine("Result: ");
            finalList.DisplayAll();
            
            

            Console.ReadLine();

        }

        /*public static Node Concatenate(Node L1, Node L2)
        //Preconditions: L1 and L2 are curhead pointers to two linked lists
        //Post conditions: the curhead of the list consisting the concatenation of the two lists //is returned
        {
           // return null;
            if (L1 == null && finalList.head == null)
            {
                return L2;
            }

            if (L1 == null)
            {
                finalList.tail.next = L2;
                return finalList.head;
            }

            finalList.InsertAtLast(L1.Cargo);
            Concatenate(L1.next, L2);
            return finalList.head;


        }*/

    }
    class LinkedList
    {
        public Node head; //Points to first element in the LL if list is not empty
        public Node tail;

        public Node Concatenate(Node L1, Node L2)
        //Preconditions: L1 and L2 are curhead pointers to two linked lists
        //Post conditions: the curhead of the list consisting the concatenation of the two lists //is returned
        {
            
            if (L1 != null)
            {
                InsertAtLast(L1.Cargo);
                Concatenate(L1.next, L2);
                return head;
            }
            else
            {
                if (head == null)
                {
                    head = L2;
                    tail = L2;
                    return head;
                }
                else
                {
                    tail.next = L2;
                    return head;
                }              
                
            }
            
            
        }

        public char GetFirst()
        {
            if (head != null) return head.Cargo;
            else return ' ';
        }

        public char GetLast()
        {
            Node temp = tail;
            return temp.Cargo;
        }

        public char GetAt(int pos)
        {
            if (head == null) return ' ';
            else
            {
                Node temp = head;
                while (pos > 0)
                {
                    pos--;
                    temp = temp.next;
                    if (temp == null) return ' ';
                }

                return temp.Cargo;
            }
        }

        public void InsertAtFirst(char cargo)
        {
            Node newnode = new Node();
            newnode.Cargo = cargo;
            newnode.next = head;
            head = newnode;
            if (newnode.next == null)
            {
                tail = newnode;
            }

        }

        public void InsertAtLast(char cargo)
        {
            Node newNode = new Node();
            newNode.Cargo = cargo;
            if (head == null)
            {
                head = newNode;
                tail = head;
            }
            else
            {
                Node temp = tail;
                temp.next = newNode;
                temp = temp.next;
                tail = temp;
            }
        }

        public bool InsertAt(int pos, char cargo)
        {
            Node newnode = new Node();
            newnode.Cargo = cargo;

            if (pos == 0)
            {
                newnode.next = head;
                head = newnode;
                if (newnode.next == null)
                {
                    tail = newnode;
                }
                return true;
            }
            else
            {
                if (head == null)
                {
                    tail = null;
                    return false;
                }
                pos--; // We want to find the node before the insert spot
                Node temp = head;
                while (pos > 0)
                {
                    pos--;
                    temp = temp.next;
                    if (temp == null) return false;
                }

                newnode.next = temp.next;
                temp.next = newnode;
                if (newnode.next == null)
                {
                    tail = newnode;
                }
                return true;
            }
        }

        public char Search(char cargo)
        {
            Node temp = head;
            while ((temp != null) && (temp.Cargo != cargo))
            {
                temp = temp.next;
            }

            if (temp != null) return temp.Cargo;
            else return ' ';
        }

        public char DeleteFirst()
        {
            if (head == null)
            {
                tail = null;
                return ' ';
            }
            else
            {
                char tempCargo = head.Cargo;
                head = head.next;
                if (head.next == null)
                {
                    tail = head;
                }
                return tempCargo;
            }
        }

        public char DeleteLast()
        {
            if (head == null)
            {
                tail = null;
                return ' ';
            }
            else if (head.next == null)
            {
                char tempCargo = head.Cargo;
                head = null;
                tail = null;
                return tempCargo;
            }
            else
            {
                Node temp = head;
                while (temp.next.next != null)
                {
                    temp = temp.next;
                }
                char tempCargo = temp.next.Cargo;
                temp.next = null;
                tail = temp;
                return tempCargo;
            }
        }

        public char DeleteAt(int pos)///////////////////////////////
        {
            if (head == null)
            {
                tail = null;
                return ' ';

            }

            if (pos == 0)
            {
                char tempCargo = head.Cargo;
                head = head.next;
                if (head.next == null)
                {
                    tail = head;
                }
                return tempCargo;
            }
            else
            {
                pos--; // We want to find the node before the insert spot
                Node temp = head;
                while (pos > 0)
                {
                    pos--;
                    temp = temp.next;
                    if (temp == null) return ' ';
                }

                if (temp.next == null) return ' ';
                else
                {
                    char tempCargo = temp.next.Cargo;
                    temp.next = temp.next.next;
                    return tempCargo;
                }
            }
        }


        public void DisplayAll()
        {
            Node temp = head;
            int i = 0;
            while (temp != null)
            {
                Console.WriteLine("{0}\t{1}", i, temp.Cargo);
                temp = temp.next;
                i++;
            }

        }
        public Node Append(Node curhead, Node temp)
        //Preconditions: temp is node that must be appended to the end of the list 
        //curhead is a reference to the first element in a list (or sub-list)
        //Post conditions: the curhead of the list (which now contains temp as a last element) //is returned
        {
            if (curhead == null)    //The list is empty so it will only contain temp
            {
                temp.next = null;
                return temp;
            }
            else
            {
                curhead.next = Append(curhead.next, temp); //The next of curhead is assigned 
                //to the excess of the list to which temp is appended
                return curhead;
            }
        }

        public Node Reverse(Node curhead)
        //Preconditions: curhead is a reference to the first element in a list (or sub-list)
        //Post conditions: a reference to the first element of the reversed list is returned
        {
            tail = head;
            if (curhead == null) return null;
            else return Append(Reverse(curhead.next), curhead);  //Reverse the excess of the 
                                                                 //list and append curhead at the end            
        }


    }

    class Node
    {
        public char Cargo;  //This linked list stores Strings
        public Node next;  //Reference to next list element
    }
}
