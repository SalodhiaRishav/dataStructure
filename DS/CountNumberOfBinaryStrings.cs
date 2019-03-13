using System;
using System.Collections.Generic;
using System.Text;

namespace DS
{
    public class CountNumberOfBinaryStrings
    {
        public static void main()
        {
            long testCases = long.Parse(Console.ReadLine());
            while(testCases>0)
            {
                long lengthOfBinaryString = long.Parse(Console.ReadLine());
                Console.WriteLine(GetNumberOfBinaryStrings(lengthOfBinaryString));
                testCases--;
            }
        }

        public static long GetNumberOfBinaryStrings(long lengthOfString)
        {
           if(lengthOfString==1)
            {
                return 0;
            }
            long forZero = 2;
            long forOne = 1;
            long total = forZero + forOne;
            for(long idx = 3;idx<=lengthOfString;++idx)
            {
                forOne = forZero;
                forZero = total;
                total = forZero + forOne;
            }

            return total;
        }
    }
}
