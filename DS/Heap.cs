using System;
using System.Collections.Generic;
using System.Text;

namespace DS
{
    public class HeapMain
    {
        public static void main()
        {
            string[] input = Console.ReadLine().Split(' ');
            Heap myHeap = new Heap();
            long numberOfArrays = long.Parse(input[0]);
            long numberOfElements = long.Parse(input[1]);
            long heapIdx = -1;
            for(long i=0;i<numberOfArrays;++i)
            {
                input = Console.ReadLine().Split(' ');
                for (long idx = 0; idx < numberOfElements; ++idx)
                {
                    heapIdx++;
                    myHeap.InsertNode(long.Parse(input[(int)idx]), heapIdx);
                }
            }
            
            

        }
    }

    public class Heap
    {
        public List<long> HeapArray;
        public long TotalElements;

        public Heap()
        {
            HeapArray = new List<long>();
            TotalElements = 0;
        }

        public long getIndexOfLeftChild(long indexOfParent)
        {
            return (2 * indexOfParent) + 1;
        }

        public long getIndexOfRightChild(long indexOfParent)
        {
            return (2 * indexOfParent) + 2;
        }

        public long getIndexOfParent(long indexOfNode)
        {
            return ((indexOfNode + 1) / 2) - 1;
        }

        public void InsertNode(long data, long idx)
        {
            if (HeapArray.Count == 0)
            {
                HeapArray.Add(data);
                TotalElements++;
                return;
            }

            HeapArray.Add(data);
            TotalElements++;
            while (true)
            {
                long parentIdx = getIndexOfParent(idx);
                if (parentIdx < 0)
                {
                    return;
                }

                if (HeapArray[(int)parentIdx] < data)
                {
                    break;
                }

                long temp = HeapArray[(int)parentIdx];
                HeapArray[(int)parentIdx] = data;
                HeapArray[(int)idx] = temp;
                idx = parentIdx;
            }
            return;


        }

        public long TopNode()
        {
            return HeapArray[0];
        }

        public long DeleteNode()
        {

            long deletedNode = this.TopNode();
            HeapArray[0] = HeapArray[(int)TotalElements - 1];
            HeapArray.RemoveAt((int)TotalElements - 1);
            TotalElements--;
            long parentIdx = 0;
            long elementToMove = HeapArray[(int)parentIdx];
            while (true)
            {
                long leftChildIdx = getIndexOfLeftChild(parentIdx);
                long rightChildIdx = getIndexOfRightChild(parentIdx);
                long rightChild = 0;
                long leftChild = 0;
                if (leftChildIdx >= TotalElements && rightChildIdx >= TotalElements)
                {
                    break;
                }
                else if (leftChildIdx >= TotalElements)
                {
                    rightChild = HeapArray[(int)rightChildIdx];

                    if (rightChild < elementToMove)
                    {
                        HeapArray[(int)parentIdx] = rightChild;
                        HeapArray[(int)rightChildIdx] = elementToMove;
                        parentIdx = rightChildIdx;
                    }
                    else
                    {
                        break;
                    }
                }
                else if (rightChildIdx >= TotalElements)
                {
                    leftChild = HeapArray[(int)leftChildIdx];
                    if (leftChild < elementToMove)
                    {

                        HeapArray[(int)parentIdx] = leftChild;
                        HeapArray[(int)leftChildIdx] = elementToMove;
                        parentIdx = leftChildIdx;
                    }
                    else
                    {
                        break;
                    }
                }
                else
                {

                    rightChild = HeapArray[(int)rightChildIdx];
                    leftChild = HeapArray[(int)leftChildIdx];
                    if (leftChild < rightChild)
                    {
                        if (leftChild < elementToMove)
                        {
                            HeapArray[(int)leftChildIdx] = elementToMove;
                            HeapArray[(int)parentIdx] = leftChild;
                            parentIdx = leftChildIdx;
                        }
                        else
                        {
                            break;
                        }
                    }
                    else
                    {
                        if (rightChild < elementToMove)
                        {
                            HeapArray[(int)rightChildIdx] = elementToMove;
                            HeapArray[(int)parentIdx] = rightChild;
                            parentIdx = rightChildIdx;
                        }
                        else
                        {
                            break;
                        }
                    }
                }

            }
            return deletedNode;
        }

        

    }
}
