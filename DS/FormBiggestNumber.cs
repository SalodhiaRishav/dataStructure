using System;
using System.Collections.Generic;
using System.Text;

namespace DS
{
   public class FormBiggestNumber
    {
        public static void main()
        {
            int testCases = int.Parse(Console.ReadLine());
           while (testCases > 0)
            { 
                int numberOfElements = int.Parse(Console.ReadLine());
                string input = Console.ReadLine();
                Console.WriteLine(GetBiggestNumber(input, numberOfElements));
                testCases--;
          }
        }

        public static string GetBiggestNumber(string input,int numberOfElements)
        {
            string answer=null;
            string[] numbers = input.Split(' ');
            Array.Sort(numbers,StrComparer);
         
            for(int a=numberOfElements-1;a>=0;--a)
            {
                answer += numbers[a];
            }
            return answer;
            
        }
        public static int StrComparer(string str1, string str2)
        {
            string firstString = str1 + str2;
            string secondString = str2 + str1;
            return firstString.CompareTo(secondString);
        }


    }
}
