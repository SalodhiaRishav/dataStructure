using System;
using System.Collections.Generic;
using System.Text;

namespace DS
{
    public class MinimumJump
    {
        public static void main()
        {
            long numberOfElements = long.Parse(Console.ReadLine());
            string[] stringNumbers = Console.ReadLine().Split(' ');
            long[] jumpPower = new long[numberOfElements];
            
            for (int i = 0; i < numberOfElements; ++i)
            {
                jumpPower[i]=long.Parse(stringNumbers[i]);
            }

            Console.WriteLine(GetMinimumJump(jumpPower, numberOfElements));
        }

        public static long GetMinimumJump(long[] jumpPower,long numberOfElements)
        {
            if(jumpPower[0]==0)
            {
                return 0;
            }

            long[] dpArray = new long[numberOfElements];
            for(long a=0;a<numberOfElements;++a)
            {
                dpArray[a] = long.MaxValue;
            }
            dpArray[0] = 0;
            long lastIdx = numberOfElements - 1;
            for (long a = 0; a <lastIdx; ++a)
            {
                long last = a + jumpPower[a];
                long valueToFill=dpArray[a] + 1;
                for(long b=a+1;b<=last;++b)
                {
                   
                    
                        dpArray[b] = (dpArray[b] < valueToFill) ? dpArray[b] : valueToFill;  
                    if(b==numberOfElements-1)
                    {
                        return dpArray[numberOfElements - 1] < 0 ? 0 :dpArray[numberOfElements-1];
                    }
                }
            }

            return dpArray[numberOfElements - 1] < 0 ? 0 : dpArray[numberOfElements - 1];

        }
    }

    
}
