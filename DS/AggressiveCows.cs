using System;
using System.Collections.Generic;
using System.Text;

namespace DS
{
    public class AggressiveCows
    {
        public static void main()
        {
            string[] input = Console.ReadLine().Split(' ');
            long numberOfStalls = long.Parse(input[0]);
            long numberOfCows = long.Parse(input[1]);
            input = Console.ReadLine().Split(' ');
            long[] stallsLocation = new long[numberOfStalls];
            for(long idx=0;idx<numberOfStalls;++idx)
            {
                stallsLocation[idx] = long.Parse(input[idx]);
            }

            Console.WriteLine(GetMaximumSpace(numberOfStalls,stallsLocation,numberOfCows));
        }

        public static bool isValidSpace(long numberOfStalls, long[] stallLocations,long numberOfCows,long guess)
        {
            long cows = 1;
            long prevCowAt = stallLocations[0];

            for(long idx=1;idx<numberOfStalls;++idx)
            {
                if((stallLocations[idx]-prevCowAt)>=guess)
                {
                    
                    prevCowAt = stallLocations[idx];
                    cows++;
                    if (cows >= numberOfCows)
                        return true;                    
                }
                
            }
            if(cows<numberOfCows)
            {
                return false;
            }
            return true;
        }


        public static long GetMaximumSpace(long numberOfStalls,long[] stallLocations,long numberOfCows)
        {
            long bestAnswer = long.MinValue;
            Array.Sort(stallLocations);
            long minimumNumberOfSpaces = 0;
            long maximumNumberOfSpaces = stallLocations[numberOfStalls - 1]-stallLocations[0];

            while(minimumNumberOfSpaces<=maximumNumberOfSpaces)
            {
                long midPoint = (maximumNumberOfSpaces+maximumNumberOfSpaces)/2;
                if(isValidSpace(numberOfStalls,stallLocations,numberOfCows,midPoint))
                {
                    minimumNumberOfSpaces = midPoint + 1;
                    if(midPoint>bestAnswer)
                    {
                        bestAnswer = midPoint;
                    }
                }
                else
                {
                    maximumNumberOfSpaces = midPoint - 1;
                }
            }
            return bestAnswer;

        }


    }
}
