using System;
using System.Collections.Generic;
using System.Text;

namespace DS
{
    public class CheckDuplicateParanthesis
    {
        public static void main()
        {
            string input = Console.ReadLine();
            if(CheckTheDuplicateParanthesis2(input))
            {
                Console.WriteLine("true");
            }
            else
            {
                Console.WriteLine("false");
            }
           
        }

     
        public static bool CheckTheDuplicateParanthesis2(string input)
        {
           
                int length = input.Length;
                Stack<char> stack = new Stack<char>();
                for (int idx = 0; idx < length; ++idx)
                {
                    if (input[idx] == ')')
                    {
                        long count = 0;
                        char topElement = stack.Pop();
                        while (topElement != '(')
                        {
                            topElement = stack.Pop();
                            count++;
                        }
                        if (count <= 1)
                        {
                            return true;
                        }
                    }
                    else
                    {
                        stack.Push(input[idx]);
                    }

               
            }
            return false;


        }
    }
}
