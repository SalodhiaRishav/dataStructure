using System;

namespace DS
{
    public class MaximumCircularSum
    {
        public static void main()
        {
            int testCases = int.Parse(Console.ReadLine());
            while (testCases > 0)
            {

                int numberOfElements = 0;
                numberOfElements = int.Parse(Console.ReadLine());

                int[] arr = new int[numberOfElements];
                string num = Console.ReadLine();
                string[] numbers = num.Split(' ');
                for (int i = 0; i < numberOfElements; ++i)
                {
                    arr[i] = int.Parse(numbers[i]);
                }

                long finalMax = CircularMaxSubArray(arr, numberOfElements);
                Console.WriteLine(finalMax);
                testCases--;
            }

        }

        public static int CircularMaxSubArray(int[] arr,int numberOfElements)
        {
            int finalMax = MaxSubArray(arr, numberOfElements,0);
            //  int[] circularArray = new int[numberOfElements];
            for (int i=1;i<numberOfElements;++i)
            {
                int curMax=MaxSubArray(arr, numberOfElements, i);
                if(curMax>finalMax)
                {
                    finalMax = curMax;
                }
            }
            return finalMax;
        }

        public static int MaxSubArray(int[] arr, int numberOfElements,int startIdx)
        {
           
            int max = arr[startIdx];
            int gMax = max;
    
            for (int i = startIdx+1; i < numberOfElements; ++i)
            {
                if ((max + arr[i]) >= arr[i])
                {
                    max = arr[i] + max;
                }
                else
                {
                    max = arr[i];
                }
                if (max > gMax)
                {
                    gMax = max;
                }
            }
            
            for (int i = 0; i < startIdx; ++i)
            {
                if ((max + arr[i]) >= arr[i])
                {
                    max = arr[i] + max;
                }
                else
                {
                    max = arr[i];
                }
                if (max > gMax)
                {
                    gMax = max;
                }
            }

            return gMax;

        }

    }

}
