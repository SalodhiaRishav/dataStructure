using System;
using System.Collections.Generic;
using System.Text;

namespace DS
{
    class MaximumSubArray
    {

        public static void main()
        {

            int testCases = 0;
            testCases = int.Parse(Console.ReadLine());
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

                Console.WriteLine(MaxSubArray(arr, numberOfElements));
                testCases--;
            }
           
        }

        public static int MaxSubArray(int[] arr, int numberOfElements)
        {
            
            int max = arr[0];
            int gMax = max;

            for (int i=1;i<numberOfElements;++i)
            {
                if((max+arr[i])>=arr[i])
                {                  
                    max = arr[i] + max;                  
                }
                else
                {                 
                    max = arr[i];                  
                }
                if(max>gMax)
                {
                    gMax = max;
                }
            }

            return gMax;
                
        }
            
    }
}

