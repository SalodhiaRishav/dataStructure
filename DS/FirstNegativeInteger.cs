using System;
using System.Collections.Generic;
using System.Text;

namespace DS
{
    public class FirstNegativeInteger
    {
        public static void main()
        {
            long testCases = long.Parse(Console.ReadLine());
            while (testCases > 0)
            {
                string firstInput = Console.ReadLine();
                string[] firstInputs = firstInput.Split(' ');
                long numberOfElements = long.Parse(firstInputs[0]);
                long windowSize = long.Parse(firstInputs[1]);

                string arrayInput = Console.ReadLine();
                string[] arrayInputs = arrayInput.Split(' ');
                long[] numbers = new long[numberOfElements];
                for (int a = 0; a < numberOfElements; ++a)
                {
                    numbers[a] = long.Parse(arrayInputs[a]);
                }

                long[] answerArray = new long[numberOfElements - windowSize + 1];
                long endIdx = numberOfElements - windowSize;
                answerArray = GetFirstNegativeInteger(numbers, numberOfElements, windowSize);
                for (int a = 0; a <= endIdx; ++a)
                {
                    Console.Write("{0} ", answerArray[a]);
                }
                Console.WriteLine();
                testCases--;
            }

        }

        public static long[] GetFirstNegativeInteger(long[] input,long numberOfElements,long windowSize)
        {
            long[] firstNegativeInteger = new long[numberOfElements-windowSize+1];
            
            Queue<long> negativeNumbers = new Queue<long>();
            Queue<long> indexes = new Queue<long>();
            for(long idx =0;idx<numberOfElements;++idx)
            {
                if(input[idx]<0)
                {
                    negativeNumbers.Enqueue(input[idx]);
                    indexes.Enqueue(idx);

                }
            }
            long lastIdx = numberOfElements - windowSize;
          for(long idx=0;idx<=lastIdx;++idx)
            {
                if(idx>indexes.Peek())
                {
                    indexes.Dequeue();
                    negativeNumbers.Dequeue();
                }

                if(firstNegativeInteger[idx]==0)
                {
                    if(indexes.Count!=0)
                    {
                        long checkHigherIdx = indexes.Peek();
                        long checkLowerIdx = indexes.Peek()-windowSize+1;
                        long negativeNumber = negativeNumbers.Peek();
                        if(idx>=checkLowerIdx&&idx<=checkHigherIdx)
                        {
                            firstNegativeInteger[idx] = negativeNumber;
                        }
                    }                  
                }

                
            }
            return firstNegativeInteger;
        }

    }
}
