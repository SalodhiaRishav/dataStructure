using System;
using System.Collections.Generic;
using System.Text;

namespace DS
{
    public class RecursionCodesOfTheString
    {
        public static void main()
        {
            string input = Console.ReadLine();
            List<string> answerList = GetStrings(input);
            int end = answerList.Count - 1;
            string answer = "[";
            for (int a = 0; a < end; ++a)
            {
                //Console.WriteLine(answerList[a]);
                answer = answer + answerList[a] + ", ";
            }
            answer = answer + answerList[end]+"]";
            Console.WriteLine(answer);
        }


        public static List<string> GetStrings(string inputNumber)
        {
            long length = inputNumber.Length;
            if(length==1)
            {
                List<string> answerString = new List<string>();
                int number = int.Parse(inputNumber);
                answerString.Add(numberToString(int.Parse(inputNumber)));
                return answerString;
            }

            if(length==2)
            {
                List<string> answerString = new List<string>();
                string lastString = numberToString(int.Parse(inputNumber[0].ToString()));
                lastString = lastString + numberToString(int.Parse(inputNumber[1].ToString()));
                answerString.Add(lastString);
                int number = int.Parse(inputNumber);
                if(number<27)
                {
                    answerString.Add(numberToString(number));                 
                }

                return answerString;

            }
            List<string> answerList = new List<string>();
           int firstNumber= int.Parse(inputNumber[0].ToString());
            string firstString = numberToString(firstNumber);
            string stringLeft = inputNumber.Substring(1);
            List<string> nextList = GetStrings(stringLeft);
            for(int idx=0;idx<nextList.Count;++idx)
            {
               string toAdd= firstString + nextList[idx];
                answerList.Add(toAdd);
            }
            nextList.Clear();
            int secondNumber = firstNumber*10 + int.Parse(inputNumber[1].ToString());
            if(secondNumber<27)
            {
                string secondString = numberToString(secondNumber);
                stringLeft = inputNumber.Substring(2);
                nextList = GetStrings(stringLeft);
                for (int idx = 0; idx < nextList.Count; ++idx)
                {
                    string toAdd = secondString + nextList[idx];
                    answerList.Add(toAdd);
                }
            }
            return answerList;
        }

        public static string numberToString(int number)
        {
            char character = (char)(96 + number);
            return character.ToString();
        }


    }

    

}
