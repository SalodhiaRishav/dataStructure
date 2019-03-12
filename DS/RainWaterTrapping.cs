using System;
using System.Collections.Generic;
using System.Text;

namespace DS
{
   public class RainWaterTrapping
    {
        public static void main()
        {
            long testCases = long.Parse(Console.ReadLine());
            while(testCases>0)
            {
                long numberOfBars = long.Parse(Console.ReadLine());
                string input = Console.ReadLine();
                //Console.WriteLine("ans");
                Console.WriteLine(StoredWater(input, numberOfBars));
                testCases--;
            }
            
        }

        public static long StoredWater(string input,long numberOfBars)
        {
            long[] bars = new long[numberOfBars];
            string[] bar = input.Split(' ');
            for(long a =0;a<numberOfBars; ++a)
            {
                bars[a]= long.Parse(bar[a]);

            }
            if(numberOfBars<3)
            {
                return 0;
            }
            long totalWater = 0;

            Stack<long> stack = new Stack<long>();
            
            long[] RightMax = new long[numberOfBars];
            long[] LeftMax = new long[numberOfBars];
            RightMax[numberOfBars - 1] =bars[numberOfBars-1] ;
            stack.Push(bars[numberOfBars-1]);
            for(long a = numberOfBars-2;a>=0;--a)
            {
                if(bars[a]>=stack.Peek())
                {
                    stack.Pop();
                    stack.Push(bars[a]);
                    RightMax[a] = bars[a];
                }
                else
                {
                    RightMax[a] = stack.Peek();
                }
            }
            LeftMax[0] = bars[0];
            stack.Clear();
            stack.Push(bars[0]);
            for (long a = 1; a <numberOfBars; ++a)
            {
                if (bars[a] >= stack.Peek())
                {
                    stack.Pop();
                    stack.Push(bars[a]);
                    LeftMax[a] = bars[a];
                }
                else
                {
                    LeftMax[a] = stack.Peek();
                }
            }
            //Console.WriteLine();
            //Console.WriteLine("LeftMax");

            //for (long a = 0; a < numberOfBars; ++a)
            //{
            //    Console.Write("{0} ", LeftMax[a]);
            //}
            //Console.WriteLine();
            //Console.WriteLine("RightMax");

            //for (long a = 0; a < numberOfBars; ++a)
            //{
            //    Console.Write("{0} ", RightMax[a]);
            //}
            long last = numberOfBars - 1;
            for(long a=1;a<last;++a)
            {
                if(LeftMax[a]<RightMax[a])
                {
                    totalWater += LeftMax[a] - bars[a];
                }
                else
                {
                    totalWater += RightMax[a] - bars[a];
                }
            //    Console.WriteLine("total water : {0}", totalWater);
            }

            return totalWater;
        }
    }


}
