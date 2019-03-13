using System;
using System.Collections.Generic;
using System.Text;

namespace DS
{
    public class OptimalGameStrategy
    {
        public static void main()
        {
            long numberOfElements = long.Parse(Console.ReadLine());

            string[] input = Console.ReadLine().Split(' ');
            long[] coinValue = new long[numberOfElements];

            for (long idx = 0; idx < numberOfElements; ++idx)
            {
                coinValue[idx] = long.Parse(input[idx]);
            }

            Console.WriteLine(GetMaximumProfit(coinValue,0,numberOfElements-1));
        }

        public static long GetMaximumProfit(long[] coinValue, long startIdx, long endIdx)
        {
            long maxEarned = 0;
            if (endIdx == (startIdx + 1))
            {
                return Math.Max(coinValue[startIdx],coinValue[endIdx]);
            }
            long ifFirstChoosed = coinValue[startIdx] + Math.Min(GetMaximumProfit(coinValue, startIdx + 1, endIdx - 1),
                GetMaximumProfit(coinValue, startIdx + 2, endIdx));

            long ifSecondChoosed = coinValue[endIdx] + Math.Min(GetMaximumProfit(coinValue,startIdx,endIdx-2),
                GetMaximumProfit(coinValue,startIdx+1,endIdx-1));


           maxEarned = Math.Max(ifFirstChoosed, ifSecondChoosed);
            return maxEarned;
        }


    }
}
