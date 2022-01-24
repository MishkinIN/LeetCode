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
         * There are n gas stations along a circular route, 
         * where the amount of gas at the ith station is gas[i].
         * You have a car with an unlimited gas tank and it costs cost[i] of gas
         * to travel from the ith station to its next (i + 1)th station.
         * You begin the journey with an empty tank at one of the gas stations.
         * Given two integer arrays gas and cost, return the starting gas station's index
         * if you can travel around the circuit once in the clockwise direction,
         * otherwise return -1. If there exists a solution, it is guaranteed to be unique
         Constraints:

    gas.length == n
    cost.length == n
    1 <= n <= 10^5
    0 <= gas[i], cost[i] <= 10^4
*/
        public static int CanCompleteCircuit(int[] gas, int[] cost) {
            //{
            //    int mapLenght = gas.Length;
            //    (int i, int residue) refill, lastRefill, startRefill; //reside - запас бензина на подъезде к следующей станции заправки
            //    lastRefill = new(mapLenght - 1, 0);
            //    startRefill = lastRefill;
            //    int lastRefillCost = gas[mapLenght - 1] - cost[mapLenght - 1], mapCost = lastRefillCost;
            //    for (int i = 0; i < mapLenght - 1; i++) {
            //        refill = new(i, lastRefill.residue + lastRefillCost);
            //        if (refill.residue < startRefill.residue) {
            //            startRefill = refill;
            //        }
            //        lastRefillCost = gas[i] - cost[i];
            //        mapCost += lastRefillCost;
            //        lastRefill = refill;
            //    }
            //    if (mapCost >= 0) {
            //        return startRefill.i;
            //    }
            //    else
            //        return -1;
            //}
            {
                int mapLenght = gas.Length;
                int start= 0, mapCost = gas[mapLenght - 1] -cost[mapLenght - 1], minResidue=mapCost;
                for (int i = 0; i < mapLenght-1; i++) {
                    mapCost += gas[i] - cost[i];
                    if (mapCost< minResidue) {
                        minResidue = mapCost;
                        start = i + 1;
                    }
                }
                if (mapCost >= 0) {
                    return start;
                }
                else
                    return -1;
            }
           
        }
        public static int[] TwoSumII(int[] numbers, int target) {
            int index1, index2;
            for (index1 = 1; index1 < numbers.Length; index1++) {
                index2 = Array.BinarySearch(numbers, target - numbers[index1]);
                if (index2>0) {
                    return new int[] { index1, index2 };
                }
            }
            return null;
        }
    }
}
