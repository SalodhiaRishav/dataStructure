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
            long rows = lengthOfFirstString + 1;
            long columns = lengthOfSecondString + 1;
            long[,] matrix = new long[rows,columns];
            for(long idx=0;idx<rows;++idx)
            {
                matrix[idx,0] = 0;
            }
            for (long idx = 0; idx < columns; ++idx)
            {
                matrix[0, idx] = 0;
            }
            long rowIdx = 0;
            long colIdx = 0;
            for ( rowIdx=1;rowIdx<rows;++rowIdx)
            {
                for(colIdx=1;colIdx<columns;++colIdx)
                {
                    if(firstString[(int)rowIdx-1]==secondString[(int)colIdx-1])
                    {
                        matrix[rowIdx,colIdx]=matrix[rowIdx - 1, colIdx - 1] + 1;
                    }
                    else
                    {
                        matrix[rowIdx,colIdx]=Math.Max(matrix[rowIdx-1,colIdx],matrix[rowIdx,colIdx-1]);
                    }
                }
            }
            //for (rowIdx = 0; rowIdx < rows; ++rowIdx)
            //{
            //    for (colIdx = 0; colIdx < columns; ++colIdx)
            //    {
            //        Console.Write($"{matrix[rowIdx,colIdx]} ");
            //    }
            //    Console.WriteLine();
            //}

            rowIdx = rows - 1;
            colIdx = columns - 1;
            List<char> longestCommonSubsequence = new List<char>();
            while(matrix[rowIdx,colIdx]!=0)
            {
                if(firstString[(int)rowIdx-1]==secondString[(int)colIdx-1])
                {
                    longestCommonSubsequence.Add(firstString[(int)rowIdx-1]);
                    rowIdx -= 1;
                    colIdx -= 1;
                    continue;
                }
                if(matrix[rowIdx-1,colIdx]>matrix[rowIdx,colIdx-1])
                {
                    rowIdx = rowIdx - 1;                   
                }
                else
                {
                    colIdx = colIdx - 1;
                }
            }
            string answer = "";
            longestCommonSubsequence.Reverse();
            foreach(char chr in longestCommonSubsequence)
            {
                answer += chr.ToString();
            }
            return answer;
            
        }
    }
}
