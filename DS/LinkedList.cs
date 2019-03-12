using System;
using System.Collections.Generic;
using System.Text;

namespace DS
{
    public class Execute
    {
        public static void main()
        {
            CustomLinkedList customLinkedList = new CustomLinkedList();
            int numberOfElements = int.Parse(Console.ReadLine());
            string[] stringNumbers = Console.ReadLine().Split(' ');
        
            for (int i = 0; i < numberOfElements; ++i)
            {
                customLinkedList.Add(int.Parse(stringNumbers[i]));
            }

            //   int elementsToAppend = int.Parse(Console.ReadLine());
            //  elementsToAppend = elementsToAppend%numberOfElements;

            // Node newHead = customLinkedList.ReverseLinkedList(customLinkedList.Head);
            //Node newHead = customLinkedList.ReverseUsingRecursionData(customLinkedList.Head);
            Node newHead = customLinkedList.MergeSort(customLinkedList.Head);
            customLinkedList.ShowLinkedList(newHead);

           
        }
    }
    public class Node
    {
        public Node Next;
        public int Value;
        public Node(int data)
        {
            Next = null;
            Value = data;
        }
    }

    public class CustomLinkedList
    {
        public Node Head;
        public static int Count;
        public Node Tail;
        public CustomLinkedList()
        {
            Head = null;
        }
        public void Add(int data)
        {
            Node node = new Node(data);
            if(Head==null)
            {
                Head = node;
                Tail = node;
                Count++;
            }
            else
            {
                Node curNode = Head;
                while(curNode.Next!=null)
                {
                    curNode = curNode.Next;
                }
                curNode.Next = node;
                Tail = node;
                Count++;
            }

        }

        public void ShowLinkedList(Node head)
        {
            Node curNode = head;
            while(curNode!=null)
            {
                Console.Write("{0} ",curNode.Value);
                curNode = curNode.Next;
            }
        }



        public Node ReverseLinkedList(Node head)
        {

            if(head.Next==null)
            {
                return head;
            }
         
            Node newHead = ReverseLinkedList(head.Next);
            head.Next.Next = head;
            head.Next = null;
            return newHead;

        }

        public Node KAppend(Node head,int numberOfElementsToAppend)
        {
            int tempCount = Count - numberOfElementsToAppend;
            Tail.Next = head;
            
            Node curNode = head;
            while(tempCount!=1)
            {
                curNode = curNode.Next;
                tempCount--;
            }

            Head = curNode.Next;
            head = Head;
            curNode.Next = null;
            Tail = curNode;
            return head;
        }

        public Node ReverseUsingRecursionData(Node head)
        {
            if(head == null)
            {
                return null;
            }
            if(head.Next ==null)
            {
                return head;
            }

            Node temp = ReverseUsingRecursionData(head.Next);
            int tempdata = temp.Value;
            temp.Value = head.Value;
            head.Value = tempdata;

            Console.WriteLine("again");
            this.ShowLinkedList(head);

            Console.WriteLine();

            ReverseUsingRecursionData(head.Next);

            this.ShowLinkedList(head);
            Console.WriteLine("again");
            Console.WriteLine();
            return head;

        }

        public static Node FindMidNode(Node head)
        {
           
            Node slowNode = head;
            Node fastNode = head;
            while(fastNode.Next!=null&&fastNode.Next.Next!=null)
            {
                fastNode = fastNode.Next.Next;
                slowNode = slowNode.Next;
            }
            return slowNode;
        }

        public Node MergeSort(Node head)

        {
           if(head==null)
            {
                return null;
            }
           if(head.Next==null)
            {
                return head;
            }

            Node midNode = FindMidNode(head);
            Node nextHead = midNode.Next;
            midNode.Next = null;
            
            Node firstHead = MergeSort(head);
            Node secondHead = MergeSort(nextHead);
            Node newHead = MergeSortedArray(firstHead, secondHead);
            return newHead;
        }

        public static Node MergeSortedArray(Node firstHead, Node secondHead)
        {
            Node head = null;
            Node tail = null;
            Node firstTempListCurNode = firstHead;
            Node secondTempListCurNode = secondHead;
            while(firstTempListCurNode!=null&&secondTempListCurNode!=null)
            {
                Node minNode = null;
               if(firstTempListCurNode.Value<secondTempListCurNode.Value)
                {
                    minNode = firstTempListCurNode;
                    firstTempListCurNode = firstTempListCurNode.Next;
                    minNode.Next = null;
                }
                else
                {
                    minNode = secondTempListCurNode;
                    secondTempListCurNode = secondTempListCurNode.Next;
                    minNode.Next = null;
                }

               if(head==null)
                {
                    head = minNode;
                    tail = minNode;
                }
               else
                {
                    tail.Next = minNode;
                    tail = tail.Next;
                }

            }

            //while(firstTempListCurNode!=null)
            //{
            //    tail.Next = firstTempListCurNode;
            //    tail = tail.Next;
            //    tail.Next = null;
            //    firstTempListCurNode = firstTempListCurNode.Next;
            //}

            if(firstTempListCurNode!=null)
            {
                tail.Next = firstTempListCurNode;
            }
            else if(secondTempListCurNode!=null)
            {
                tail.Next = secondTempListCurNode;
            }

            //while(secondTempListCurNode!=null)
            //{

            //    tail.Next = secondTempListCurNode;
            //    tail = tail.Next;
            //    tail.Next = null;
            //    secondTempListCurNode = secondTempListCurNode.Next;

            //}
            return head;
        }
    }
}
