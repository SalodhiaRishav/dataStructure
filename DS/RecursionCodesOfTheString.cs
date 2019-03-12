using System;
using System.Collections.Generic;
using System.Text;

namespace DS
{
    public class RecursionCodesOfTheString
    {
        public static void main()
        {
            char[] input = Console.ReadLine().ToCharArray();
            List<string> answerList = GetPermutationString(input, 0);
            //for(int a=0;a<answerList.Count;++a)
            //{
            //    Console.WriteLine(answerList[a]);
            //}
        }

        public static List<string> GetPermutationString(char[] input, long startIdx)
        {

            List<string> answer = new List<string>() ;
            long length = input.Length;
            if(startIdx>=length)
            {
                return null;
            }
            if ((startIdx+1) >= length)
            {
                string numbe =numberToString(int.Parse(input[startIdx].ToString()));
                answer.Add(numbe);
                return answer;
            }
            List<string> firstList = GetPermutationString(input, startIdx + 1);

            string firstletter=numberToString(int.Parse(input[startIdx].ToString()));
            if(firstList!=null)
            {
                long endIdx = firstList.Count;
                for (int a = 0; a < endIdx; ++a)
                {
                    answer.Add(firstletter + firstList[a]);
                    Console.WriteLine(firstletter + firstList[a]);
                }
            }
          
            long number = (long.Parse(input[0].ToString()) * 10) + long.Parse(input[1].ToString());
            if (number < 27)
            {
                firstletter = numberToString((int)number);
                List<string> secondList = GetPermutationString(input, startIdx + 2);
                if(secondList!=null)
                {
                    long endIdx2 = secondList.Count;
                    for (int a = 0; a < endIdx2; ++a)
                    {
                        answer.Add(firstletter + secondList[a]);
                        Console.WriteLine(firstletter + firstList[a]);
                    }
                }
              

            }
            return answer;


        }

        public static string numberToString(int number)
        {
            char character = (char)(96 + number);
            return character.ToString();
        }
    }

    

}
