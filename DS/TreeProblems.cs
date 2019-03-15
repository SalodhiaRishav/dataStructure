using System;
using System.Collections.Generic;
using System.Text;

namespace NDS
{
   
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
        public static void main()
        {
            BinaryTree treeOne = new BinaryTree();
            treeOne.Root = treeOne.CreateTree(treeOne.Root);
            BinaryTree treeTwo = new BinaryTree();
            treeTwo.Root = treeTwo.CreateTree(treeTwo.Root);

            if(IsTwoTreeStructurallyIdentical(treeOne.Root,treeTwo.Root))
            {
                Console.WriteLine("true");
            }
            else
            {
                Console.WriteLine("false");
            }
          
        }
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
                Console.WriteLine($"Data : {curNode.Data}  Height : {GetHeightOfNode(curNode)} ");
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

        public void CheckSibling(MyTreeNode root)
        {
            Queue<MyTreeNode> queue = new Queue<MyTreeNode>();
            queue.Enqueue(root);
            while (queue.Count != 0)
            {
                MyTreeNode curNode = queue.Dequeue();
                if(curNode.LeftChild!=null&&curNode.RightChild==null)
                {
                    Console.WriteLine($"{curNode.LeftChild.Data} ");
                }
                else if(curNode.LeftChild==null&&curNode.RightChild!=null)
                {
                    Console.Write($"{curNode.RightChild.Data} ");
                }
                
                if (curNode.LeftChild != null)
                {
                    queue.Enqueue(curNode.LeftChild);
                }
                if (curNode.RightChild != null)
                {
                    queue.Enqueue(curNode.RightChild);
                }
            }
        }

        public bool CheckBalanceTree(MyTreeNode root)
        {
            if(root == null)
            {
                return true;
            }

            int leftSubTreeHeight = GetHeightOfNode(root.LeftChild);
            int rightSubTreeHeight = GetHeightOfNode(root.RightChild);

           // bool isBalanced = false;
            if(Math.Abs(leftSubTreeHeight-rightSubTreeHeight)>1)
            {
                return false;
            }
            else
            {
                if(CheckBalanceTree(root.LeftChild)&&CheckBalanceTree(root.RightChild))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public void ZigZagTraversing(MyTreeNode root)
        {
            Stack<MyTreeNode> leftToRightLevel = new Stack<MyTreeNode>();
            Stack<MyTreeNode> rightToLeftLevel = new Stack<MyTreeNode>();
            leftToRightLevel.Push(root);
            while (leftToRightLevel.Count!=0||rightToLeftLevel.Count!=0)
            {
                while(leftToRightLevel.Count!=0)
                {
                   MyTreeNode curNode= leftToRightLevel.Pop();
                    if (curNode.LeftChild != null)
                    {
                        rightToLeftLevel.Push(curNode.LeftChild);
                    }
                    if (curNode.RightChild!=null)
                    {
                        rightToLeftLevel.Push(curNode.RightChild);
                    }
                                    
                    Console.Write($"{curNode.Data} ");
                }

                while (rightToLeftLevel.Count != 0)
                {
                    MyTreeNode curNode = rightToLeftLevel.Pop();
                    if (curNode.RightChild != null)
                    {
                        leftToRightLevel.Push(curNode.RightChild);
                    }
                    if (curNode.LeftChild != null)
                    {
                        leftToRightLevel.Push(curNode.LeftChild);
                    }
                    
                    
                    Console.Write($"{curNode.Data} ");
                }
            }
            
        }

        public static int GetHeightOfNode(MyTreeNode node)
        {           
            if(node==null)
            {
                return 0;
            }
            int height = Math.Max(GetHeightOfNode(node.LeftChild), GetHeightOfNode(node.RightChild)) + 1;
            return height;
        }

        public static bool IsTwoTreeStructurallyIdentical(MyTreeNode rootTreeOne,MyTreeNode rootTreeTwo)
        {
           
            if ((rootTreeOne!=null && rootTreeTwo == null) || (rootTreeOne==null&&rootTreeTwo!=null))
            {
                return false;
            }

            if(rootTreeTwo==null && rootTreeOne==null)
            {
                return true;
            }

            bool isLeftStructureSame = IsTwoTreeStructurallyIdentical(rootTreeOne.LeftChild, rootTreeTwo.LeftChild);
            bool isRightStructureSame = IsTwoTreeStructurallyIdentical(rootTreeOne.RightChild, rootTreeTwo.RightChild);
            if(isLeftStructureSame&&isRightStructureSame)
            {
                return true;
            }
            return false;
        }

    }

}
