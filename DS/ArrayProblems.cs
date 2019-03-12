using System;
using System.Collections.Generic;
using System.Text;

namespace DS
{
    class ArrayProblems
    {
        
        public static void main()
        {
            int testCases = int.Parse(Console.ReadLine());
          
            while (testCases > 0)
            {
                testCases--;
                int numberOfElements = int.Parse(Console.ReadLine());
                string input = Console.ReadLine();
                LargestSubArray(input, numberOfElements);
            }
        }

        public static void LargestSubArray(string input,int numberOfElements)
        {
            string[] arr = input.Split(' ');
            int i = 0;
            int j = numberOfElements - 1;
            int numberOfOnes = 0;
            int numberOfZeroes = 0;
         
            for (int k=0;k<numberOfElements;++k)
            {
                if(arr[k]=="1")
                {
                    numberOfOnes++;
                }
            }
            numberOfZeroes = numberOfElements - numberOfOnes;
          //  Console.WriteLine(" 0 : {0} ,1 : {1}", numberOfZeroes, numberOfOnes);
            if (numberOfZeroes==0||numberOfOnes==0)
            {
                Console.WriteLine("None");
                return;
            }

            while(numberOfOnes!=numberOfZeroes)
            {
                if(numberOfZeroes<numberOfOnes)
                {
                    if(arr[j]=="0")
                    {
                        j--;
                        numberOfZeroes--;
                    }
                    else if(arr[i]=="0")
                    {
                        i++;
                        numberOfZeroes--;
                    }
                    else
                    {
                        numberOfOnes--;
                        j--;
                    }
                }
                else
                {
                    if (arr[j] == "1")
                    {
                        j--;
                        numberOfOnes--;
                    }
                    else if (arr[i] == "1")
                    {
                        i++;
                        numberOfOnes--;
                    }
                    else
                    {
                        numberOfZeroes--;
                        j--;
                    }
                }
            }

            Console.WriteLine("{0} {1}", i, j);
        }
    }
}
