using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    public static partial class Solution
    {
        /// <summary>
        /// Given two sorted arrays nums1 and nums2 of size m and n respectively, return the median of the two sorted arrays.
        /// </summary>
        /// <param name="numsM">nums1 of size m</param>
        /// <param name="numsN">nums2 of size n</param>
        /// <returns>median of the two sorted arrays</returns>
        public static double FindMedianSortedArrays(int[] numsM, int[] numsN)
        {
            double GetMedian(int v1, int v2) => (double)(v1 + v2) / 2.0;
            int GetNext(int[] numsM, int m, int[] numsN, int n) 
            {
                if (m<numsM.Length-1)
                {
                    if (n<numsN.Length-1)
                    {
                        return Math.Min(numsM[m + 1], numsN[n + 1]);
                    }
                    else
                    {
                        return numsM[m + 1];
                    }
                }
                else
                {
                    if (n < numsN.Length - 1)
                    {
                        return numsN[n + 1];
                    }
                }
                throw new IndexOutOfRangeException();
            };
            int m = numsM.Length, n = numsN.Length;
            int medianIndex1 = (m + n) / 2-1+(m + n) % 2;
            int medianIndex2 = medianIndex1 +1 -(m + n) % 2;
            if (n == 0)
            {
                return GetMedian(numsM[medianIndex1], numsM[medianIndex2]);
            }
            if (m == 0)
            {
                return GetMedian(numsN[medianIndex1], numsN[medianIndex2]);
            }
            int m1=m/2, n1= medianIndex1-m1, stepM1=m, stepN1=n;
            while (stepM1!=0 | stepN1!=0)
            {
               
                if (numsM[m1]-numsN[n1]>0)
                {
                    if (stepN1==0)
                    {
                        return GetMedian(numsN[n1], GetNext(numsM, m1, numsN, n1));
                    }
                    stepM1 /= 2;
                    n1 = Math.Min(medianIndex1 - (m1 - stepM1),n-1);
                    m1 = medianIndex1 - n1;
                }
                if(numsM[m1] - numsN[n1] < 0)
                {
                    if (stepN1==0)
                    {
                        return GetMedian(numsM[m1], GetNext(numsM, m1, numsN, n1));
                    }
                    stepN1 /= 2;
                    m1 = Math.Min(medianIndex1 - (n1 - stepN1), m-1);
                    n1 = medianIndex1 - m1;
                }
                if (numsM[m1] - numsN[n1]==0)
                {
                    if (medianIndex1==medianIndex2)
                    {
                        return (double)numsM[m1];
                    }
                    else
                    {
                        return GetMedian(numsM[m1], GetNext(numsM, m1, numsN, n1));
                    }
                }
            }

            return GetMedian(Math.Max(numsM[m1], numsN[n1]), GetNext(numsM, m1, numsN, n1));
        }
    }
}
