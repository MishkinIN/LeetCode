using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode {

    public class VersionControl {
        public bool IsBadVersion(int version) { return true; }
        /*
         * 278. First Bad Version
         * Easy
         * You are a product manager and currently leading a team to develop a new product. 
         * Unfortunately, the latest version of your product fails the quality check. 
         * Since each version is developed based on the previous version, 
         * all the versions after a bad version are also bad.
         * Suppose you have n versions [1, 2, ..., n] and you want to find out the first bad one, 
         * which causes all the following ones to be bad.
         * You are given an API bool isBadVersion(version) which returns whether version is bad. 
         * Implement a function to find the first bad version. You should minimize the number of calls to the API.
          * 
          */
        public int FirstBadVersion(int n) {
            int fbad = 1, bad = n, v;
            while (fbad < bad) {
                v = fbad + (bad - fbad) / 2;
                if (IsBadVersion(v)) {
                    bad = v;
                }
                else {
                    fbad = v + 1;
                }
            }
            return fbad;
        }

    }
}
