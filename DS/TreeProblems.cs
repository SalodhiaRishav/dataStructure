using System;
using System.Collections.Generic;
using System.Text;

namespace NDS
{
    public class TreeProblems
    {
        public static void main()
        {
            BinaryTree bt = new BinaryTree();
            bt.Root= bt.CreateTree(bt.Root);
            bt.LevelOrderTraversing(bt.Root);
        }
    }

    public class MyTreeNode
    {
        public int Data;
        public MyTreeNode LeftChild;
        public MyTreeNode RightChild;

        public MyTreeNode()
        {
            LeftChild = null;
            RightChild = null;
        }
    }

    public class BinaryTree
    {
        public MyTreeNode Root;
        public static string[] inputString;
        public static int count;

        public BinaryTree()
        {
            Root = null;
            count = 0;
            string input = Console.ReadLine();
            inputString= input.Split(' ');
        }

        public MyTreeNode CreateTree(MyTreeNode Root)
        {

            if(Root==null)
            {
             //   Console.WriteLine("Enter Root");
                //int data = int.Parse(Console.ReadLine());
                int data = int.Parse(inputString[count++]);
                MyTreeNode node = new MyTreeNode();
                node.Data = data;
                Root = node;
            }
           
          //  Console.WriteLine("wanna enter left child");
            //   string userAnswer=Console.ReadLine();
            string userAnswer = inputString[count++];
            if(userAnswer=="true")
            {
              //  Console.WriteLine("Enter left Child");
                MyTreeNode leftNode = new MyTreeNode();
                //int data = int.Parse(Console.ReadLine());
                int data = int.Parse(inputString[count++]);
                leftNode.Data = data;
                Root.LeftChild = leftNode;
                CreateTree(leftNode);

            }
           // Console.WriteLine("wanna enter right child");
            //userAnswer = Console.ReadLine();
            userAnswer = inputString[count++];
            if (userAnswer == "true")
            {
              //  Console.WriteLine("Enter right Child");
                MyTreeNode rightNode = new MyTreeNode();
                //int data = int.Parse(Console.ReadLine());
                int data = int.Parse(inputString[count++]);
                rightNode.Data = data;
                Root.RightChild = rightNode;
                CreateTree(rightNode);

            }
            return Root;

        }

        public void LevelOrderTraversing(MyTreeNode root)
        {
            Queue<MyTreeNode> queue = new Queue<MyTreeNode>();
            queue.Enqueue(root);
            while(queue.Count!=0)
            {
                MyTreeNode curNode = queue.Dequeue();
                Console.Write($"{curNode.Data} ");
                if(curNode.LeftChild!=null)
                {
                    queue.Enqueue(curNode.LeftChild);
                }
                if(curNode.RightChild!=null)
                {
                    queue.Enqueue(curNode.RightChild);
                }
            }
        }

        public int GetHeightOfNode(MyTreeNode node)
        {
            return 0;
        }

    }

}
