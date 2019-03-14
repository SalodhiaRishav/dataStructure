using System;
using System.Collections.Generic;
using System.Text;

namespace DS
{
    public class LongestCommonSubSequence
    {
        public static void main()
        {
            string firstString = Console.ReadLine();
            string secondString = Console.ReadLine();
            string longestSubSequence = GetLongestSubSequence(firstString,secondString);
            Console.WriteLine(longestSubSequence);
        }

        public static string GetLongestSubSequence(string firstString, string secondString)
        {
            long lengthOfFirstString = firstString.Length;
            long lengthOfSecondString = secondString.Length;
            string[,] matrix = new string[lengthOfFirstString, lengthOfSecondString];

            if(firstString[0]==secondString[0])
            {
                matrix[0, 0] = firstString[0].ToString();
            }
            else
            {
                matrix[0, 0] = null;
            }

            for(int column = 1;column<lengthOfSecondString;++column)
            {
                if(firstString[0]==secondString[column])
                {
                    matrix[0, column] = firstString[0].ToString();
                }
                else
                {
                    matrix[0, column] = matrix[0, column - 1];
                }
            }

            for (int row = 1; row < lengthOfFirstString; ++row)
            {
                if (secondString[0] == firstString[row])
                {
                    matrix[row,0] = secondString[0].ToString();
                }
                else
                {
                    matrix[row,0] = matrix[row-1,0];
                }
            }

            for (int row = 1; row < lengthOfFirstString; ++row)
            {
                for (int column = 1; column < lengthOfSecondString; ++column)
                {
                    if(firstString[row]==secondString[column])
                    {
                        string toAttach = matrix[row - 1, column];
                        if(toAttach==null)
                        {
                            matrix[row, column] = toAttach;
                        }
                        else
                        {
                            if(toAttach.Length<(column+1))
                            {
                                matrix[row, column] = matrix[row - 1, column] + firstString[row].ToString();
                            }
                            else
                            {
                                matrix[row, column] = toAttach;
                            }
                        }
                        
                    }
                    else
                    {
                        int upperLength = 0;
                        int leftLength = 0;
                        if (matrix[row, column - 1] == null)
                        {
                            leftLength = 0;
                        }
                        else
                        {
                            leftLength = matrix[row, column - 1].Length;
                        }
                        if (matrix[row - 1, column] == null)
                        {
                            upperLength = 0;
                        }
                        else
                        {
                            upperLength = matrix[row - 1, column].Length;
                        }

                        matrix[row, column] = leftLength > upperLength ? matrix[row, column - 1] : matrix[row - 1, column];
                      //  matrix[row, column] = matrix[row, column-1];
                    }
                }
            }

            for (int row = 0; row < lengthOfFirstString; ++row)
            {
                for (int column = 0; column < lengthOfSecondString; ++column)
                {
                    Console.Write(matrix[row, column] + " ");
                }
                Console.WriteLine();
            }

            return matrix[lengthOfFirstString - 1, lengthOfSecondString - 1];
        }
    }
}
