using System;
using System.Collections.Generic;
using System.Text;

namespace DS
{
    class StackProblem
    {
        public static void main()
        {
            string input = Console.ReadLine();
            if (CheckBalancedParanthesis(input))
            {
                Console.WriteLine("Yes");
            }
            else
            {
                Console.WriteLine("No");
            }
        }

        public static bool CheckBalancedParanthesis(string input)
        {
            char[] inputString = input.ToCharArray();
            Stack<char> stack = new Stack<char>();
            stack.Push('*');
            int length = input.Length;
            for (int i = 0; i < length; ++i)
            {
                char character = inputString[i];
                if (character == '(' || character == '{' || character == '[')
                {
                    stack.Push(character);
                }
                else
                {
                    if (character == ')')
                    {
                        if (stack.Peek() == '(')
                        {
                            stack.Pop();
                        }
                        else
                        {
                            stack.Push(character);
                        }

                    }
                    else if (character == ']')
                    {
                        if (stack.Peek() == '[')
                        {
                            stack.Pop();
                        }
                        else
                        {
                            stack.Push(character);
                        }

                    }
                    else
                    {
                        if (character == '{')
                        {
                            if (stack.Peek() == '}')
                            {
                                stack.Pop();
                            }
                            else
                            {
                                stack.Push(character);
                            }

                        }
                    }

                }
            }

            if (stack.Peek() == '*')
            {
                return true;
            }

            return false;

        }
    }


}
