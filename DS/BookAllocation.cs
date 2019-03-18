using System;
using System.Collections.Generic;
using System.Text;

namespace DS
{
    public class BookAllocation
    {
        public static void main()
        {
            long testCases = long.Parse(Console.ReadLine());
            while (testCases > 0)
            {
                string[] input = Console.ReadLine().Split(' ');
                long numberOfBooks=long.Parse(input[0]);
                long numberOfStudents=long.Parse(input[1]);
                input = Console.ReadLine().Split(' ');
                long[] pagesOfBooks = new long[numberOfBooks];
                for(long i=0;i<numberOfBooks;++i)
                {
                    pagesOfBooks[i]=long.Parse(input[i]);
                }
                Console.WriteLine(GetMinimumPagesToAllocate(pagesOfBooks,numberOfStudents,numberOfBooks));
                testCases--;
            } 
        }

        public static bool IsCurrentNumberValid(long[] pagesOfBooks,long numberOfStudents,long numberOfBooks,long numberToCheck)
        {
            long numberOfStudentsDone = 1;
            long totalPages = 0;
            for(long idx=0;idx<numberOfBooks;++idx)
            {
                if (pagesOfBooks[idx] > numberToCheck)
                    return false;

                if ((totalPages+pagesOfBooks[idx])>numberToCheck)
                {
                    numberOfStudentsDone += 1;
                    totalPages = pagesOfBooks[idx];
                    if(numberOfStudentsDone>numberOfStudents)
                    {
                        return false;
                    }
                }
                else
                {
                    totalPages += pagesOfBooks[idx];
                }
            }
            return true;
        }

        public static long GetMinimumPagesToAllocate(long[] pagesOfBooks,long numberOfStudents,long numberOfBooks)
        {
            long minimumPagesToAllocate = long.MaxValue;
            long sum = 0;
            
            for(long idx =0;idx<numberOfBooks;++idx)
            {
                sum += pagesOfBooks[idx];
            }
            long minimumPages = 0;
            long maximumPages = sum;
            while(minimumPages<=maximumPages)
            {
               long mid=(minimumPages+maximumPages)/ 2;
                if(IsCurrentNumberValid(pagesOfBooks,numberOfStudents,numberOfBooks,mid))
                {
                    if(mid<minimumPagesToAllocate)
                    {
                        minimumPagesToAllocate = mid;
                    }
                    maximumPages = mid-1;
                }
                else
                {
                    minimumPages = mid + 1;
                }
            }

            return minimumPagesToAllocate;

        }

      
    }
}
