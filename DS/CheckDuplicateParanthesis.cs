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
            if(CheckTheDuplicateParanthesis(input))
            {
                Console.WriteLine("true");
            }
            else
            {
                Console.WriteLine("false");
            }
           
        }

        public static bool CheckTheDuplicateParanthesis(string inputs)
        {

            int length = inputs.Length;
            char[] array = inputs.ToCharArray();
            Stack<char> stack = new Stack<char>();
            stack.Push('*');

            for(int i = 0;i<length;++i)
            {
                if(array[i]=='(')
                {
                    stack.Push(array[i]);
                }
                else if(array[i]!=')'&&stack.Peek()=='(')
                {
                    stack.Push(array[i]);
                }
                else if(array[i]==')')
                {
                    if(stack.Peek()=='*')
                    {
                        return false;
                    }
                    else
                    {
                        stack.Pop();
                        if (stack.Peek() == '*')
                        {
                            return false;
                        }
                        else
                        {
                            stack.Pop();     
                            if(stack.Peek()=='(')
                            {
                                return true;
                            }
                        }
                    }

                }
            }

            return false;
        }
    }
}
