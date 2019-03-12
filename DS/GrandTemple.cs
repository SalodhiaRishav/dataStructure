using System;
using System.Collections.Generic;
using System.Text;

namespace DS
{
    public class GrandTemple
    {
        public static void main()
        {
            long numberOfPoints = long.Parse(Console.ReadLine());
            string[] inputs = new string[numberOfPoints];
            for(int a=0;a<numberOfPoints;++a)
            {
                inputs[a]=Console.ReadLine();
            }
            Console.WriteLine(GetMaxArea(numberOfPoints,inputs));
        }

        public static long GetMaxArea(long numberOfPoints,string[] coordinates)
        {
            if(numberOfPoints==1)
            {
                return 0;
            }
            long maxArea = 0;
            long[] xCoordinates = new long[numberOfPoints];
            long[] yCoordinates = new long[numberOfPoints];
            for(int a=0; a<numberOfPoints;++a)
            {
               string[] coords= coordinates[a].Split(' ');
                xCoordinates[a] = long.Parse(coords[0]);
                yCoordinates[a] = long.Parse(coords[1]);
            }

            Array.Sort(xCoordinates);
            Array.Sort(yCoordinates);
            long maxX = 0;
            long maxY = 0;
            for(int a=1;a<numberOfPoints;++a)
            {
              long tempX= xCoordinates[a] - xCoordinates[a - 1]-1;
                if(tempX>maxX)
                {
                    maxX = tempX;
                }
            }

            for (int a = 1; a < numberOfPoints; ++a)
            {
                long tempY = yCoordinates[a] - yCoordinates[a - 1]-1;
                if (tempY > maxY)
                {
                    maxY = tempY;
                }
            }
            maxArea = maxX * maxY;
            return maxArea;
        }
    }
}
