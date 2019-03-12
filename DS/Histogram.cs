using System;
using System.Collections.Generic;
using System.Text;

namespace DS
{
    public class Histogram
    {
        public static void main()
        {

        }

        public static long LargestRectangularAreaHistogram(long[] heights,long numberOfElements)
        {
            long maxArea = 0;
            long[] rightMinHeights = new long[numberOfElements];
            long[] leftMinHeights = new long[numberOfElements];
            Stack<long> minHeightStack = new Stack<long>();
            rightMinHeights[numberOfElements - 1] = -1;

            //finding rightMinHeights

            return maxArea;

        }
    }
}
