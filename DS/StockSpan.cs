using System;
using System.Collections.Generic;
using System.Text;

namespace DS
{
   public class StockSpan
    {
        public static void main()
        {
            long testCases = long.Parse(Console.ReadLine());
            while (testCases > 0)
            {
                testCases--;
                long numberOfElements = long.Parse(Console.ReadLine());
             //   string input = Console.ReadLine();
                
               // string[] inputArray = input.Split(' ');
                long[] stocks = new long[numberOfElements];

                for(long idx=0; idx<numberOfElements;++idx)
                {
                    stocks[idx] = long.Parse(Console.ReadLine());
                }

                long[] answer = new long[numberOfElements];
                GetStockSpanStack(stocks, numberOfElements);
                //for(long idx = 0;idx<numberOfElements;++idx)
                //{
                //    Console.Write("{0} ",answer[idx]);
                   
                //}
               

            }
        }
        
        public static long[] GetStockSpan(long[] stocks,long numberOfElements)
        {
            long[] answer = new long[numberOfElements];
            
            for(long idx=numberOfElements-1;idx>0;--idx)
            {
                long count = 1;
                long idx2 = idx - 1;
                while(idx2 >= 0&&stocks[idx]>stocks[idx2])
                {
                    count++;
                    idx2--;
                }
                answer[idx] = count;
            }
            answer[0] = 1;
            return answer;
        }

        public static void GetStockSpanStack(long[] stocks, long numberOfElements)
        {
            if(numberOfElements==1)
            {
                Console.WriteLine(1);
                return;
            }
            long[] indexMax = new long[numberOfElements];
            long[] answer = new long[numberOfElements];
            Stack<long> maximum = new Stack<long>();
            
            Stack<long> indexes = new Stack<long>();
            maximum.Push(stocks[0]);
            answer[0] = -1;
            indexMax[0] = 1;
            indexes.Push(0);
            for(long idx = 1;idx<numberOfElements;++idx)
            {
                while(maximum.Count!=0 && maximum.Peek()<stocks[idx])
                {
                    maximum.Pop();
                    indexes.Pop();
                }
                if(maximum.Count==0)
                {
                    indexMax[idx] = -1;
                    answer[idx] = -1;
                    maximum.Push(stocks[idx]);
                    indexes.Push(idx);
                }
                else
                {
                   
                    answer[idx] = maximum.Peek();
                    indexMax[idx] = indexes.Peek() ;
                    maximum.Push(stocks[idx]);
                    indexes.Push(idx);
                }

            }
            Console.Write("1 ");
            for(long idx =1;idx<numberOfElements;++idx)
            {
                if(indexMax[idx]==-1)
                {
                    Console.Write("{0} ", idx+1);
                }
                else
                {
                    Console.Write("{0} ", idx-indexMax[idx]);
                }
              
            }
            Console.WriteLine();
           return;


        }
    }
}
