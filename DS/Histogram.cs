using System;
using System.Collections.Generic;
using System.Text;

namespace DS
{
    public class Histogram
    {
        public static void main()
        {
            long numberOfElements = long.Parse(Console.ReadLine());

            string[] input = Console.ReadLine().Split(' ');
            long[] heights = new long[numberOfElements];

            for(long idx=0;idx<numberOfElements;++idx)
            {
                heights[idx]=long.Parse(input[idx]);
            }

            Console.WriteLine(LargestRectangularAreaHistogram(heights,numberOfElements));
        }

        public static long LargestRectangularAreaHistogram(long[] heights,long numberOfElements)
        {
            long maxArea = 0;
            long[] rightMinHeightsIndexes = new long[numberOfElements];
            long[] leftMinHeightsIndexes = new long[numberOfElements];
            Stack<long> minHeightStackIndexes = new Stack<long>();
            rightMinHeightsIndexes[numberOfElements - 1] = numberOfElements;

            //finding rightMinHeightsIndexes
            minHeightStackIndexes.Push(numberOfElements-1);
            for(long idx = numberOfElements-2;idx>=0;--idx)
            {
               while(minHeightStackIndexes.Count!=0&&heights[minHeightStackIndexes.Peek()]>=heights[idx])
                {
                    minHeightStackIndexes.Pop();
                }
               if(minHeightStackIndexes.Count==0)
                {
                    rightMinHeightsIndexes[idx] = numberOfElements;

                }
               else
                {
                    rightMinHeightsIndexes[idx] = minHeightStackIndexes.Peek();
                }
               
                minHeightStackIndexes.Push(idx);
            }

            minHeightStackIndexes.Clear();
            leftMinHeightsIndexes[0] = -1;

            //finding rightMinHeightsIndexes
            minHeightStackIndexes.Push(0);
            for (long idx = 1; idx<numberOfElements; ++idx)
            {
                while (minHeightStackIndexes.Count != 0 && heights[minHeightStackIndexes.Peek()] >= heights[idx])
                {
                    minHeightStackIndexes.Pop();
                }
                if (minHeightStackIndexes.Count == 0)
                {
                    leftMinHeightsIndexes[idx] = numberOfElements;

                }
                else
                {
                    leftMinHeightsIndexes[idx] = minHeightStackIndexes.Peek();
                }

                minHeightStackIndexes.Push(idx);
            }

            minHeightStackIndexes.Clear();
            maxArea = long.MinValue;
            for (int idx =0;idx<numberOfElements;++idx)
            {
                long lengthOfRectange = rightMinHeightsIndexes[idx] - leftMinHeightsIndexes[idx] - 1;
                long area = lengthOfRectange * heights[idx];
                if(area>maxArea)
                {
                    maxArea = area;
                }
                //Console.WriteLine("{0} {1}",leftMinHeightsIndexes[idx],rightMinHeightsIndexes[idx]);
            }
          //  Console.WriteLine();
            return maxArea;

        }
    }
}
