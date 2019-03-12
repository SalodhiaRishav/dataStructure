using System;
using System.Collections.Generic;
using System.Text;

namespace DS
{
    public class ChewbaccaNumbers
    {
        public static void main()
        {
            string input = Console.ReadLine();
            Console.WriteLine(GetChewBaccaNumber(input));
        }

        public static string GetChewBaccaNumber(string input)
        {
            
            int digit = 0;
            int length = input.Length;
            char[] numbers = input.ToCharArray();
            digit = int.Parse(numbers[0].ToString());
            if(digit!=9)
            {
                if(digit>4)
                {
                    digit = 9 - digit;
                }
            }
            string answer = digit.ToString();
            for(int a=1;a<length;++a)
            {
                digit = int.Parse(numbers[a].ToString());
                if (digit>4)
                {
                    digit = 9 - digit;                    
                }
                answer += digit.ToString();
            }
            return answer;
        }
    }
}
