using System;
using System.Collections.Generic;
using System.Text;

namespace DS
{
    public class SubsetSumEasy
    {
        public static void main()
        {
            long testCases = long.Parse(Console.ReadLine());
            while(testCases>0)
            {
                long numberOfElements = long.Parse(Console.ReadLine());
                long[] numbers = new long[numberOfElements];
                string[] input = Console.ReadLine().Split(' ');
                for(long idx=0;idx<numberOfElements;++idx)
                {
                    numbers[idx] = long.Parse(input[idx]);
                }
                IsSumZero(numbers,numberOfElements);
                testCases--;
            }
        }

        public static void IsSumZero(long[] numbers, long numberOfElements)
        {
           
            List<long> postiveNumbers = new List<long>();
            long sumToCheck = 0;
            long numberOfPostiveNumbers = 0;
            for (long idx = 0; idx < numberOfElements; ++idx)
            {
                if (numbers[idx] < 0)
                {
                    sumToCheck += Math.Abs(numbers[idx]);
                }
                else
                {
                    postiveNumbers.Add(numbers[idx]);
                    numberOfPostiveNumbers++;
                }
            }
            bool isAllZero = true;
            for(long idx=0;idx<numberOfElements;++idx)
            {
                if(numbers[idx]!=0)
                {
                    isAllZero = false;
                }
            }
            if(isAllZero)
            {
                Console.WriteLine("Yes");
                return;
            }
            if(numberOfPostiveNumbers==numberOfElements)
            {
                Console.WriteLine("No");
                return;
            }

           
            if (SubsetSum(postiveNumbers, sumToCheck, numberOfPostiveNumbers))
            {
                Console.WriteLine("Yes");
            }
            else
            {
                Console.WriteLine("No");
            }


            return;
        }

        public static bool SubsetSum(List<long> numbers,long sumToCheck,long numberOfElements)
        {
            //if(numberOfElements==1&&sumToCheck!=numbers[0])
            //{
            //    return false;
            //}
            //if(numberOfElements==1 && sumToCheck==numbers[0])
            //{
            //    return true;
            //}
            if(sumToCheck==0)
            {
                return true;
            }

            if(numberOfElements==0&&sumToCheck!=0)
            {
                return false;
            }

            if(numbers[(int)numberOfElements-1]>sumToCheck)
            {
                return SubsetSum(numbers, sumToCheck, numberOfElements - 1);
            }

            return SubsetSum(numbers, sumToCheck, numberOfElements - 1) || SubsetSum(numbers,sumToCheck-numbers[(int)numberOfElements-1],numberOfElements-1);
        }
    }
}
