using System;
using System.Collections.Generic;
using System.Text;

namespace NDS
{
   
    public class MyTreeNode
    {
        public MyTreeNode Parent;       
        public int Data;
        public MyTreeNode LeftChild;
        public MyTreeNode RightChild;

        public MyTreeNode()
        {
            Parent = null;
            LeftChild = null;
            RightChild = null;
        }
    }

    public class BinaryTree
    {
        public static Dictionary<long, List<MyTreeNode>> horizentalDistances;
        public static void main()
        {
            BinaryTree treeOne = new BinaryTree();
            //treeOne.Root = treeOne.CreateTree(treeOne.Root);
            treeOne.Root = treeOne.CreateTreeSecond(treeOne.Root);
            VerticalOrderTraversing(treeOne.Root);
                       
        }
        public MyTreeNode Root;
        public static string[] inputString;
        public static int count;
        private static Queue<MyTreeNode> queue;
        private static Queue<MyTreeNode> RootToLeafSumQueue;

        public BinaryTree()
        {
            horizentalDistances = new Dictionary<long, List<MyTreeNode>>();
             queue = new Queue<MyTreeNode>();
            Root = null;
            count = 0;
            string input = Console.ReadLine();
            inputString= input.Split(' ');
            RootToLeafSumQueue = new Queue<MyTreeNode>();
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
                Root.LeftChild.Parent = Root;
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
                Root.RightChild.Parent = Root;
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

        public MyTreeNode CreateTreeSecond(MyTreeNode root)
        {
            
            int data = 0;
            if(root==null)
            {
                //  Console.WriteLine("Enter Root");
                // data = int.Parse(Console.ReadLine());
                data = int.Parse(inputString[count++]);
                MyTreeNode curNode = new MyTreeNode();
                curNode.Data = data;
                root = curNode;
            }
            //Console.WriteLine("enter left");
            data = int.Parse(inputString[count++]);
            if (data!=-1)
            {
                MyTreeNode newNode = new MyTreeNode();
                newNode.Data = data;
                root.LeftChild = newNode;
                queue.Enqueue(root.LeftChild);
            }
          //  Console.WriteLine("enter right"); 
            data = int.Parse(inputString[count++]);
            if (data!=-1)
            {
                MyTreeNode newNode = new MyTreeNode();
                newNode.Data = data;
                root.RightChild = newNode;
                queue.Enqueue(root.RightChild);
            }
            while(queue.Count!=0)
            {
                MyTreeNode curRoot = queue.Dequeue();
                CreateTreeSecond(curRoot);
            }
            return root;

        }

        public static void ShowLeftView(MyTreeNode root)
        {
            MyTreeNode markerNode = new MyTreeNode();
            markerNode.Data = -1;
            Queue<MyTreeNode> levelQueue = new Queue<MyTreeNode>();
            if (root == null)
            {
                return;
            }
            levelQueue.Enqueue(root);
            levelQueue.Enqueue(markerNode);

            while (levelQueue.Count != 0)
            {
                MyTreeNode curNode = levelQueue.Dequeue();
                if (levelQueue.Count == 0)
                    break;

                if (levelQueue.Peek().Data == -1)
                {
                    Console.Write($"{curNode.Data} ");
                }
                if (curNode.Data == -1)
                {
                    levelQueue.Enqueue(markerNode);
                }
                else
                {
                    if (curNode.RightChild != null)
                    {
                        levelQueue.Enqueue(curNode.RightChild);
                    }
                    if (curNode.LeftChild != null)
                    {
                        levelQueue.Enqueue(curNode.LeftChild);
                    }
                    

                }
            }
            return;
        }

        public static void ShowRightView(MyTreeNode root)
        {
            MyTreeNode markerNode = new MyTreeNode();
            markerNode.Data = -1;
            Queue<MyTreeNode> levelQueue = new Queue<MyTreeNode>();
            if(root==null)
            {
                return;
            }
            levelQueue.Enqueue(root);
            levelQueue.Enqueue(markerNode);
          
            while(levelQueue.Count!=0)
            {
               MyTreeNode curNode = levelQueue.Dequeue();
                if (levelQueue.Count == 0)
                    break;

                if(levelQueue.Peek().Data==-1)
                {                    
                    Console.Write($"{curNode.Data} ");
                }
                if(curNode.Data==-1)
                {
                    levelQueue.Enqueue(markerNode);
                }
                else
                {
                    if(curNode.LeftChild!=null)
                    {
                        levelQueue.Enqueue(curNode.LeftChild);
                    }
                    if(curNode.RightChild!=null)
                    {
                        levelQueue.Enqueue(curNode.RightChild);
                    }
                    
                }
            }
            return;
        }

        public static void ShowTopView(MyTreeNode root)
        {
            if(root==null)
            {
                return ;
            }

            List<MyTreeNode> answerList = new List<MyTreeNode>();
            MyTreeNode curNode = root;
           
            while(curNode!=null)
            {
                answerList.Add(curNode);
                curNode = curNode.LeftChild;
            }
            answerList.Reverse();

            curNode = root.RightChild;

            while(curNode!=null)
            {
                answerList.Add(curNode);
                curNode = curNode.RightChild;
            }

            foreach(MyTreeNode node in answerList)
            {
                Console.Write($"{node.Data} ");
            }

        }

        public static void DepthOrderTraversing(MyTreeNode root)
        {
            Stack<MyTreeNode> stack = new Stack<MyTreeNode>();
            MyTreeNode curNode;
            stack.Push(root);
            while(stack.Count!=0)
            {
                curNode = stack.Pop();
                Console.Write($"{curNode.Data} ");
                if(curNode.RightChild!=null)
                {
                    stack.Push(curNode.RightChild);
                }
                if(curNode.LeftChild!=null)
                {
                    stack.Push(curNode.LeftChild);
                }
            }
        }

        public static bool GetSumRootToLeaf(MyTreeNode root,long numberToFind)       
       {
            
           if(numberToFind<root.Data)
            {
                return false;
            }
            if (numberToFind == root.Data)
            {
                return true;
            }

            numberToFind = numberToFind - root.Data;
           
            if(root.LeftChild!=null && GetSumRootToLeaf(root.LeftChild, numberToFind))
            {
                RootToLeafSumQueue.Enqueue(root.LeftChild);
              
                return true;
            }
            if(root.RightChild!=null && GetSumRootToLeaf(root.RightChild,numberToFind))
            {
                RootToLeafSumQueue.Enqueue(root.RightChild);
                
                return true;
            }
            
            return false;

        }

        public static void DeleteLeafNodes(MyTreeNode root)
        {
            Queue<MyTreeNode> queue = new Queue<MyTreeNode>();
            queue.Enqueue(root);
            while (queue.Count != 0)
            {
                MyTreeNode curNode = queue.Dequeue();
                if(curNode.LeftChild==null&&curNode.RightChild==null)
                {
                    MyTreeNode parentNode = curNode.Parent;
                    if(parentNode.LeftChild.Data==curNode.Data)
                    {
                        parentNode.LeftChild = null;
                    }
                    else
                    {
                        parentNode.RightChild = null;
                    }
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
            queue.Clear();
          
            queue.Enqueue(root);
            while (queue.Count != 0)
            {
                MyTreeNode curNode = queue.Dequeue();
                string answer = "";
                if(curNode.LeftChild!=null)
                {
                    answer += curNode.LeftChild.Data.ToString() + " => ";
                    queue.Enqueue(curNode.LeftChild);
                }
                else
                {
                    answer += "END => ";
                }
                answer += curNode.Data;
                if(curNode.RightChild!=null)
                {
                    answer += " <= " + curNode.RightChild.Data.ToString();
                    queue.Enqueue(curNode.RightChild);
                }
                else
                {
                    answer += " <= END";
                }
                Console.WriteLine(answer);

              
            }
        }

        public static void GetHorizentalDistances(MyTreeNode root,long horizentalDistance)
        {
            if(root==null)
            {
                return;
            }
            if(!horizentalDistances.ContainsKey(horizentalDistance))
            {
                horizentalDistances[horizentalDistance] = new List<MyTreeNode>();
            }
             
                horizentalDistances[horizentalDistance].Add(root);
            
            GetHorizentalDistances(root.LeftChild, horizentalDistance - 1);
            GetHorizentalDistances(root.RightChild, horizentalDistance + 1);
        }

        public static void VerticalOrderTraversing(MyTreeNode root)
        {
            GetHorizentalDistances(root, 0);
            List<long> mapKeys = new List<long>();
            foreach (KeyValuePair<long, List<MyTreeNode>> kvp in horizentalDistances)
            {
                mapKeys.Add(kvp.Key);        
            }
            mapKeys.Sort();
            foreach(long key in mapKeys)
            {
               
                Console.Write($"{horizentalDistances[key][0].Data} ");
            }

        }
        


    }

}
