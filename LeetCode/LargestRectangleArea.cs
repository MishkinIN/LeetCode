using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using System.Diagnostics;

namespace LeetCode {
    public static partial class Solution {
        /*
         * 84. Largest Rectangle in Histogram
         * Hard
         * Given an array of integers heights representing the histogram's bar height where the width of each bar is 1,
         * return the area of the largest rectangle in the histogram.
        Constraints:

    1 <= heights.length <= 10^5
    0 <= heights[i] <= 10^4


         */

        public record Interval_r(int min, int max) {
            public int Lenght => max - min;
            //public int Area => (max - min) * value;
            public bool Contains(int index) {
                return (index >= min) && (index < max);
            }
        }
        public struct Bar {
            public int Index;
            public int Value;
            public Bar(int value, int index) {
                Index = index;
                Value = value;
            }
        }
        /// <summary>
        /// Represent interval [min, max)
        /// </summary>
        [DebuggerDisplay("[{min}, {max})")]
        public struct Interval {
            public int min;
            public int max;

            public Interval(int[] vs) : this() {
                this.min=vs[0];
                this.max=vs[1];
            }

            public Interval(int min, int max) {
                this.min = min;
                this.max = max;
            }
            public int Lenght => max - min;
            //public int Area => (max - min) * value;
            public bool Contains(int index) {
                return (index >= min) && (index < max);
            }
        }
        private class IntervalComparer : IComparer<Interval> {
            public int Compare(Interval x, Interval y) {
                return x.min - y.min;
            }
        }
        // А надо было использовать стек и не ...
        public static int LargestRectangleArea(int[] heights) {
            int[] vs = new int[heights.Length];
            for (int i = 0; i < heights.Length; i++) {
                vs[i] = i;
            }
            Array.Sort(heights, vs);
            SortedSet<Interval> intervals = new(new IntervalComparer()) {
                new Interval(0, heights.Length)
            };
            int maxRectangleArea = 0;
            for (int i = 0; i < heights.Length; i++) {
                var value = heights[i];
                var index = vs[i];
                var interval = intervals.GetViewBetween(new Interval(0, 0), new Interval(index, index))
                    .Max;
                maxRectangleArea = System.Math.Max(maxRectangleArea, interval.Lenght * value);
                intervals.Remove(interval);
                {
                    if (index - interval.min > 0) {
                        intervals.Add(new Interval(interval.min, index));
                    }
                    if (interval.max - (index + 1) > 0) {
                        intervals.Add(new Interval(index + 1, interval.max));
                    }
                }
            }
            return maxRectangleArea;

        }
        public static int LargestRectangleArea_I(int[] heights) {
            int[] vs = new int[heights.Length];
            for (int i = 0; i < heights.Length; i++) {
                vs[i] = i;
            }
            Array.Sort(heights, vs);
            List<Interval> intervalList = new() {
                new Interval(0, heights.Length/*, int.MaxValue*/)
            };
            int maxRectangleArea = 0;
            for (int i = 0; i < heights.Length; i++) {
                var value = heights[i];
                var index = vs[i];
                var interval = intervalList.Last(il => il.Contains(index));
                intervalList.Remove(interval);
                var leftInterval = new Interval(interval.min, index); /*interval with { max = index };*/
                var rightInterval = new Interval(index, interval.max);  /*interval with { min = index + 1 };*/
                if (leftInterval.Lenght > 0) {
                    intervalList.Add(leftInterval);
                }
                if (rightInterval.Lenght > 0) {
                    intervalList.Add(rightInterval);
                }
                maxRectangleArea = System.Math.Max(maxRectangleArea, (interval.Lenght * value));
                intervalList.Remove(interval);
                //}

                //}
            }
            return maxRectangleArea;

        }
        public static int LargestRectangleArea_II(int[] heights) {
            var bars = heights.Select((v, i) => new Bar(v, i)).ToArray();
            Array.Sort(bars);
            List<Interval_r> intervalList = new() {
                new Interval_r(0, heights.Length/*, int.MaxValue*/)
            };
            int maxRectangleArea = 0;
            foreach (var bar in bars) {
                foreach (var interval in intervalList.Where(il => il.Contains(bar.Index)).ToArray()) {
                    //if (interval.value == bar.Value) {
                    //    continue;
                    //}
                    //else 
                    //if (interval.value<bar.Value) {
                    var leftInterval = interval with { max = bar.Index };
                    var rightInterval = interval with { min = bar.Index + 1 };
                    if (leftInterval.Lenght > 0) {
                        intervalList.Add(leftInterval);
                    }
                    if (rightInterval.Lenght > 0) {
                        intervalList.Add(rightInterval);
                    }
                    maxRectangleArea = System.Math.Max(maxRectangleArea, (interval.Lenght * bar.Value));
                    intervalList.Remove(interval);
                    //}

                }
            }
            return maxRectangleArea;

        }

    }
}
