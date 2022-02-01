using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    public static partial class Solution
    {
        /*
         * You are given an array representing a row of seats 
         * where seats[i] = 1 represents a person sitting in the ith seat,
         * and seats[i] = 0 represents that the ith seat is empty (0-indexed).
         * 
         * There is at least one empty seat, and at least one person sitting.
         * 
         * Alex wants to sit in the seat such that the distance between him and the closest person
         * to him is maximized. 
         * 
         * Return that maximum distance to the closest person.
         Constraints:

    2 <= seats.length <= 2 * 10^4
    seats[i] is 0 or 1.
    At least one seat is empty.
    At least one seat is occupied.
*/
        public static int MaxDistToClosest(int[] seats)
        {
            int dist = 0, maxCenterDist = 0,  rightDist = 0;
            int i= seats.Length;
            while (i>0) // from left
            {
                if (seats[--i] == 1)
                {
                    if (rightDist > i)
                    {
                        return rightDist;
                    }
                    else
                    {
                        break;
                    }
                }
                else
                    rightDist++;
            }
            while (i>0)
            {
                if (seats[--i] == 1)
                {
                    if (dist > maxCenterDist)
                    {
                        maxCenterDist = dist;
                    }
                    if ((maxCenterDist + 1) / 2 > i)
                    {
                        dist = (maxCenterDist + 1) / 2;
                        return System.Math.Max(dist, rightDist);
                    }
                    dist = 0;
                }
                else
                    dist++;
            }
            return System.Math.Max(dist, System.Math.Max((maxCenterDist + 1) / 2, rightDist));
        }

    }
}
