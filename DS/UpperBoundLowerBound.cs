using System;

namespace DS
{
        public class UpperBoundLowerBound
        {
            public static void main()
            {
                long numberOfElements = long.Parse(Console.ReadLine());
                string input = Console.ReadLine();
                string[] inputArray = input.Split(' ');
                long[] numbers = new long[numberOfElements];
                
                for (long idx = 0; idx < numberOfElements; ++idx)
                {
                    numbers[idx] = long.Parse(inputArray[idx]);
                }
                long testCases = long.Parse(Console.ReadLine());
                long[,] output = new long[testCases, 2];
                long idxCount = 0;
                while (testCases > 0)
                {
                    long numberToFind = long.Parse(Console.ReadLine());
                    long[] answer = GetUpperLowerBound(numbers, numberToFind, numberOfElements);
                    output[idxCount,0]=answer[0];
                    output[idxCount,1]=answer[1];
                 testCases--;
                idxCount++;
                }

                for(long idx =0; idx<idxCount;++idx)
                {
                Console.WriteLine("{0} {1}",output[idx,0],output[idx,1]);
                }
            }

            public static long[] GetUpperLowerBound(long[] numbers, long numberToFind, long numberOfElements)
            {
                long[] answer = new long[2];
                long idxFound = BinarySearch(numbers, numberToFind, numberOfElements);
                if (idxFound == -1)
                {
                    answer[0] = -1;
                    answer[1] = -1;
                    return answer;
                }
                long upperIdx = idxFound;
                while (numbers[upperIdx] == numberToFind && upperIdx < numberOfElements)
                {
                    upperIdx++;
                }

                long lowerIdx = idxFound;
                while (numbers[lowerIdx] == numberToFind && upperIdx >= 0)
                {
                    lowerIdx--;
                }
                answer[0] = lowerIdx + 1;
                answer[1] = upperIdx - 1;
                return answer;
            }

            public static long BinarySearch(long[] numbers, long numberToFind, long numberOfElements)
            {
                long startIdx = 0;
                long endIdx = numberOfElements - 1;
                while (startIdx <= endIdx)
                {
                    long mid = (startIdx + endIdx) / 2;
                    if (numbers[mid] == numberToFind)
                    {
                        return mid;
                    }

                    if (numberToFind < numbers[mid])
                    {
                        endIdx = mid - 1;
                    }
                    else
                    {
                        startIdx = mid + 1;
                    }
                }

                return -1;
            }
        


    }

}

