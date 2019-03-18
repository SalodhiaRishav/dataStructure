using System;
using System.Collections.Generic;
using System.Text;

namespace DS
{
    public class BinarySearchTreeNode
    {
        public long Data;
        public BinarySearchTreeNode LeftChild;
        public BinarySearchTreeNode RightChild;
        public BinarySearchTreeNode ParentNode;

        public BinarySearchTreeNode()
        {
            LeftChild = null;
            ParentNode = null;
            RightChild = null;
        }
    }
   public class BinarySearchTree
    {
        public static void main()
        {
                     BinarySearchTree bst = new BinarySearchTree();
                long numberOfNodes = long.Parse(Console.ReadLine());
                string[] input = Console.ReadLine().Split(' ');
                for (long i = 0; i < numberOfNodes; ++i)
                {
                    long data = long.Parse(input[i]);
                    bst.AddNewNode(data);
                }
            bst.GetMedianOfBST(numberOfNodes);
           // bst.InOrderTraverseMorisApproach();
           
        }

       public BinarySearchTreeNode Root;

       public BinarySearchTree()
        {
            Root = null;
        }

        public void AddNewNode(long data)
        {
            BinarySearchTreeNode newNode = new BinarySearchTreeNode();
            newNode.Data = data;

            if (Root==null)
            {
                Root = new BinarySearchTreeNode();
                Root.Data = data;
                return;
            }          

            BinarySearchTreeNode currentNode = Root;
            while (true)
            {
               
                if (data < currentNode.Data)
                {
                    if(currentNode.LeftChild==null)
                    {
                        
                        currentNode.LeftChild = newNode;
                        currentNode.LeftChild.ParentNode = currentNode;
                        return;
                    }
                    currentNode = currentNode.LeftChild;
                }
                else
                {
                    if (currentNode.RightChild == null)
                    {
                        currentNode.RightChild = newNode;
                        currentNode.RightChild.ParentNode = currentNode;
                        return;
                    }
                    currentNode = currentNode.RightChild;
                }
            }

        }

        public void LevelOrderTraversing()
        {
            BinarySearchTreeNode root = Root;
            Queue<BinarySearchTreeNode> queue = new Queue<BinarySearchTreeNode>();
            queue.Enqueue(root);
            while (queue.Count != 0)
            {
                BinarySearchTreeNode curNode = queue.Dequeue();
                Console.Write($"{curNode.Data} ");
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

        public  BinarySearchTreeNode FindNode(long dataToFind,BinarySearchTreeNode root)
        {
            BinarySearchTreeNode curNode = root;
            while(curNode!=null)
            {
                if(curNode.Data==dataToFind)
                {
                    return curNode;
                }
                else if(dataToFind < curNode.Data)
                {
                    curNode = curNode.LeftChild;
                }
                else
                {
                    curNode = curNode.RightChild;
                }
            }
            return null;
        }

        public  BinarySearchTreeNode getLowestCommonAncestor(long data1,long data2)
        {
            Stack<BinarySearchTreeNode> stack = new Stack<BinarySearchTreeNode>();
            BinarySearchTreeNode curNode = Root;
            while(true)
            {
                stack.Push(curNode);
                if (curNode.Data==data1)
                {                  
                    break;
                }
                else if(curNode.Data<data1)
                {
                    curNode = curNode.RightChild;
                }
                else
                {
                    curNode = curNode.LeftChild;
                }
            }

            while(stack.Count!=0)
            {
                curNode = stack.Pop();
                if(FindNode(data2,curNode)!=null)
                {
                    return curNode;
                }               
            }
            return null;
            
        }

        public void DeleteNode(long dataToDelete)
        {
            BinarySearchTreeNode nodeToDelete = FindNode(dataToDelete,Root);
            BinarySearchTreeNode parent = nodeToDelete.ParentNode;
            if (nodeToDelete.LeftChild==null && nodeToDelete.RightChild==null)
            {
                if (parent.LeftChild.Data == nodeToDelete.Data)
                {
                    parent.LeftChild = null;


                }
                else
                {
                    parent.RightChild=null;
                }
                return;
            }

            if(nodeToDelete.LeftChild==null)
            {
                
                nodeToDelete.RightChild.ParentNode = nodeToDelete.ParentNode;
                if (parent.LeftChild.Data == nodeToDelete.Data)
                {
                    parent.LeftChild = nodeToDelete.RightChild;


                }
                else
                {
                    parent.RightChild = nodeToDelete.RightChild;
                }
                return;
            }
           
            if(nodeToDelete.RightChild==null)
            {
              
                nodeToDelete.LeftChild.ParentNode = nodeToDelete.ParentNode;
                if (parent.LeftChild.Data == nodeToDelete.Data)
                {
                    parent.LeftChild = nodeToDelete.LeftChild;

                }
                else
                {
                    parent.RightChild = nodeToDelete.LeftChild;
                }
                return;
            }

            BinarySearchTreeNode curNode = nodeToDelete.LeftChild;
            while(curNode.RightChild!=null)
            {
                curNode = curNode.RightChild;
            }
            long datas = curNode.Data;
            this.DeleteNode(datas);
            nodeToDelete.Data = datas;
        }

        public void InOrderTraverseMorisApproach()
        {
            BinarySearchTreeNode curNode = Root;
            while(curNode!=null)
            {
                if (curNode.LeftChild == null)
                {
                    Console.Write($"{curNode.Data} ");
                    curNode = curNode.RightChild;
                }
                else
                {
                    BinarySearchTreeNode rightMostNodeInLeftSubTree = curNode.LeftChild;

                    while(rightMostNodeInLeftSubTree.RightChild!=null&&rightMostNodeInLeftSubTree.RightChild!=curNode)
                    {
                        rightMostNodeInLeftSubTree= rightMostNodeInLeftSubTree.RightChild;
                    }

                    if(rightMostNodeInLeftSubTree.RightChild==null)
                    {
                        rightMostNodeInLeftSubTree.RightChild = curNode;
                        curNode = curNode.LeftChild;
                    }
                    else
                    {
                        rightMostNodeInLeftSubTree.RightChild = null;
                        Console.Write($"{curNode.Data} ");
                        curNode = curNode.RightChild;
                    }
                }
            }
           
           
        }

        public void GetMedianOfBST(long numberOfNodes)
        {
            if(numberOfNodes==1)
            {
                Console.WriteLine(Root.Data);
                return;
            }
            long firstMedian = 0;
            long secondMedian = 0;

               long medianNodeCountFirst = numberOfNodes/2;
               long medianNodeCountSecond = medianNodeCountFirst+ 1;
            


            BinarySearchTreeNode curNode = Root;
            while (curNode != null)
            {
                if (curNode.LeftChild == null)
                {
                    medianNodeCountSecond--;
                    if(medianNodeCountSecond==0)
                    {
                        secondMedian = curNode.Data;
                        break;
                    }
                    else
                    {
                        firstMedian = curNode.Data;
                    }
                    curNode = curNode.RightChild;
                    medianNodeCountFirst--;
                }
                else
                {
                    BinarySearchTreeNode rightMostNodeInLeftSubTree = curNode.LeftChild;

                    while (rightMostNodeInLeftSubTree.RightChild != null && rightMostNodeInLeftSubTree.RightChild != curNode)
                    {
                        rightMostNodeInLeftSubTree = rightMostNodeInLeftSubTree.RightChild;
                    }

                    if (rightMostNodeInLeftSubTree.RightChild == null)
                    {
                        rightMostNodeInLeftSubTree.RightChild = curNode;
                        curNode = curNode.LeftChild;
                    }
                    else
                    {
                        rightMostNodeInLeftSubTree.RightChild = null;
                        medianNodeCountSecond--;
                        if (medianNodeCountSecond == 0)
                        {
                            secondMedian = curNode.Data;
                            break;
                        }
                        else
                        {
                            firstMedian = curNode.Data;
                        }
                        
                        curNode = curNode.RightChild;
                    }
                }
            }

            if(numberOfNodes%2==0)
            {
                Console.WriteLine((firstMedian + secondMedian) / 2);
            }
            else
            {
                Console.WriteLine(secondMedian);
            }


        }

    }

    
}
