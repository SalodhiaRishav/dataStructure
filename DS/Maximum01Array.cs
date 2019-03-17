using System;
using System.Collections.Generic;
using System.Text;

namespace DS
{
   public class Maximum01Array
    {
        public static void main()
        {
            long testCases = long.Parse(Console.ReadLine());
            while (testCases > 0)
            {


                long numberOfElements = long.Parse(Console.ReadLine());

                string[] input = Console.ReadLine().Split(' ');
                long[] numbers = new long[numberOfElements];

                for (long idx = 0; idx < numberOfElements; ++idx)
                {
                    numbers[idx] = long.Parse(input[idx]);
                }

                GetMaximum01Array(numbers, numberOfElements);
                testCases--;
            }
        }

        public static void GetMaximum01Array(long[] array,long numberOfElements)
        {
            long maxLength = 0;
            long indexOfMaxLength = -1;
            long sumOfElements = 0;
            Dictionary<long, long> map = new Dictionary<long, long>();
            map[0] = -1;
            for(long idx = 0;idx<numberOfElements;++idx)
            {
                sumOfElements += (array[idx] == 0) ? -1:1;
                
                if(map.ContainsKey(sumOfElements))
                {
                  
                    if (idx - map[sumOfElements] > maxLength)
                    {
                       maxLength= idx - map[sumOfElements];
                     
                        indexOfMaxLength = idx;
                    }

                }
                else
                {
                    map[sumOfElements] = idx;
                }
                
            }
            if(maxLength==0)
            {
                Console.WriteLine("None");
                return;
            }
            Console.WriteLine($"{indexOfMaxLength-maxLength+1} {indexOfMaxLength}");
        }
    }
}
