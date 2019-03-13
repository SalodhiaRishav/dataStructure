using System;
using System.Collections.Generic;
using System.Text;

namespace DS
{
    public class MaximumLengthBiotonicArray
    {
        public static void main()
        {
            long testCases = long.Parse(Console.ReadLine());
            while (testCases > 0)
            {

                long numberOfElements = 0;
                numberOfElements = long.Parse(Console.ReadLine());

                long[] arr = new long[numberOfElements];
                string num = Console.ReadLine();
                string[] numbers = num.Split(' ');
                for (long i = 0; i < numberOfElements; ++i)
                {
                    arr[i] = long.Parse(numbers[i]);
                }

                long finalMax =GetMaximumLengthBiotonicArray(arr, numberOfElements);
                Console.WriteLine(finalMax);
                testCases--;
            }
        }

        public static long GetMaximumLengthBiotonicArray(long[] numbers, long numberOfElements)
        {
            long maximumLength = long.MinValue;
            long[] leftToRightIncreasingArray = new long[numberOfElements];
            long[] rightToLeftIncreasingArray = new long[numberOfElements];

            leftToRightIncreasingArray[0] = 1;
            for(long idx =1;idx<numberOfElements;++idx)
            {
                if(numbers[idx]>numbers[idx-1])
                {
                    leftToRightIncreasingArray[idx] = leftToRightIncreasingArray[idx - 1] + 1;
                }
                else
                {
                    leftToRightIncreasingArray[idx] = 1;
                }
            }

            rightToLeftIncreasingArray[numberOfElements-1] = 1;
            for (long idx = numberOfElements-2; idx >=0; --idx)
            {
                if (numbers[idx] > numbers[idx+1])
                {
                    rightToLeftIncreasingArray[idx] = rightToLeftIncreasingArray[idx + 1] + 1;
                }
                else
                {
                    rightToLeftIncreasingArray[idx] = 1;
                }
            }


            for(long idx =0;idx<numberOfElements;++idx)
            {
                long valueToCheck = leftToRightIncreasingArray[idx] + rightToLeftIncreasingArray[idx] - 1;
                if (valueToCheck>maximumLength)
                {
                    maximumLength = valueToCheck;
                }
                //Console.WriteLine("{0} {1}", leftToRightIncreasingArray[idx], rightToLeftIncreasingArray[idx]);


            }
            return maximumLength;

        }
    }
}
