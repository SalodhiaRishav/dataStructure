using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace DS
{
    public class StringSort
    {
        public static void main()
        {
            int numberOfElements = int.Parse(Console.ReadLine());
            string[] inputs = new string[numberOfElements];
            for (int i = 0; i < numberOfElements; ++i)
            {
                inputs[i] = Console.ReadLine();
            }

            // Console.WriteLine(StrComparer("abcgde","abchd"));
            Array.Sort(inputs,StrComparer);
            
            for (int i = 0; i < numberOfElements; ++i)
            {
                Console.WriteLine(inputs[i]);
            }
        }

        public static int StrComparer(string str1, string str2)
        {
            if (str1 == str2)
            {
                return 0;
            }

            int lengthStr1 = str1.Length;
            int lengthStr2 = str2.Length;
            int i = 0;
            while (i < lengthStr2 && i < lengthStr1)
            {
                if (str1[i] < str2[i])
                {
                    return -1;
                }
                else if (str1[i] > str2[i])
                {
                    return 1;
                }
                else
                {
                    i++;
                }
            }

            if (lengthStr1 > lengthStr2)
            {
                return -1;
            }
            return 1;


        }


    }
}
