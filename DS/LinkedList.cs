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
            MyTreeNode newHead = customLinkedList.MergeSort(customLinkedList.Head);
            customLinkedList.ShowLinkedList(newHead);

           
        }
    }
    public class MyTreeNode
    {
        public MyTreeNode Next;
        public int Value;
        public MyTreeNode(int data)
        {
            Next = null;
            Value = data;
        }
    }

    public class CustomLinkedList
    {
        public MyTreeNode Head;
        public static int Count;
        public MyTreeNode Tail;
        public CustomLinkedList()
        {
            Head = null;
        }
        public void Add(int data)
        {
            MyTreeNode node = new MyTreeNode(data);
            if(Head==null)
            {
                Head = node;
                Tail = node;
                Count++;
            }
            else
            {
                MyTreeNode curNode = Head;
                while(curNode.Next!=null)
                {
                    curNode = curNode.Next;
                }
                curNode.Next = node;
                Tail = node;
                Count++;
            }

        }

        public void ShowLinkedList(MyTreeNode head)
        {
            MyTreeNode curNode = head;
            while(curNode!=null)
            {
                Console.Write("{0} ",curNode.Value);
                curNode = curNode.Next;
            }
        }



        public MyTreeNode ReverseLinkedList(MyTreeNode head)
        {

            if(head.Next==null)
            {
                return head;
            }
         
            MyTreeNode newHead = ReverseLinkedList(head.Next);
            head.Next.Next = head;
            head.Next = null;
            return newHead;

        }

        public MyTreeNode KAppend(MyTreeNode head,int numberOfElementsToAppend)
        {
            int tempCount = Count - numberOfElementsToAppend;
            Tail.Next = head;
            
            MyTreeNode curNode = head;
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

        public MyTreeNode ReverseUsingRecursionData(MyTreeNode head)
        {
            if(head == null)
            {
                return null;
            }
            if(head.Next ==null)
            {
                return head;
            }

            MyTreeNode temp = ReverseUsingRecursionData(head.Next);
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

        public static MyTreeNode FindMidNode(MyTreeNode head)
        {
           
            MyTreeNode slowNode = head;
            MyTreeNode fastNode = head;
            while(fastNode.Next!=null&&fastNode.Next.Next!=null)
            {
                fastNode = fastNode.Next.Next;
                slowNode = slowNode.Next;
            }
            return slowNode;
        }

        public MyTreeNode MergeSort(MyTreeNode head)

        {
           if(head==null)
            {
                return null;
            }
           if(head.Next==null)
            {
                return head;
            }

            MyTreeNode midNode = FindMidNode(head);
            MyTreeNode nextHead = midNode.Next;
            midNode.Next = null;
            
            MyTreeNode firstHead = MergeSort(head);
            MyTreeNode secondHead = MergeSort(nextHead);
            MyTreeNode newHead = MergeSortedArray(firstHead, secondHead);
            return newHead;
        }

        public static MyTreeNode MergeSortedArray(MyTreeNode firstHead, MyTreeNode secondHead)
        {
            MyTreeNode head = null;
            MyTreeNode tail = null;
            MyTreeNode firstTempListCurNode = firstHead;
            MyTreeNode secondTempListCurNode = secondHead;
            while(firstTempListCurNode!=null&&secondTempListCurNode!=null)
            {
                MyTreeNode minNode = null;
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
