using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode {

    public static partial class Solution {
        /*        733. Flood Fill
         * Easy
         * An image is represented by an m x n integer grid image 
         * where image[i][j] represents the pixel value of the image.
         * You are also given three integers sr, sc, and newColor. 
         * You should perform a flood fill on the image starting from the pixel image[sr][sc].
         * To perform a flood fill, consider the starting pixel,
         * plus any pixels connected 4-directionally to the starting pixel
         * of the same color as the starting pixel, 
         * plus any pixels connected 4-directionally to those pixels
         * (also with the same color), and so on. 
         * Replace the color of all of the aforementioned pixels with newColor.
         * Return the modified image after performing the flood fill.
         * Constraints:

    m == image.length
    n == image[i].length
    1 <= m, n <= 50
    0 <= image[i][j], newColor < 2^16
    0 <= sr < m
    0 <= sc < n
        */
        public static int[][] FloodFill(int[][] image, int sr, int sc, int newColor) {
            int oldColor = image[sr][sc];
            if (oldColor==newColor) {
                return image;
            }
            //var m = image.Length;
            //var n = image[0].Length;
            Fill(image,sr, sc, oldColor, newColor);
            return image;

        }
        private static int Fill(int[][] image, int sr, int sc, int oldColor, int newColor) {
            image[sr][sc] = newColor;
            int area = 1;
            if (sr > 0 && image[sr - 1][sc] == oldColor) {
               area += Fill(image, sr - 1, sc, oldColor, newColor);
            }
            if (sc > 0 && image[sr][sc - 1] == oldColor) {
                area += Fill(image, sr, sc - 1, oldColor, newColor);
            }
            if (sr < image.Length - 1 && image[sr + 1][sc] == oldColor) {
                area += Fill(image, sr + 1, sc, oldColor, newColor);
            }
            if (sc < image[0].Length - 1 && image[sr][sc + 1] == oldColor) {
                area += Fill(image, sr, sc + 1, oldColor, newColor);
            }
            return area;

        }
        /*695. Max Area of Island
         * Medium
         * You are given an m x n binary matrix grid. 
         * An island is a group of 1's (representing land) connected 4-directionally
         * (horizontal or vertical.) 
         * You may assume all four edges of the grid are surrounded by water.
         * The area of an island is the number of cells with a value 1 in the island.
         * Return the maximum area of an island in grid. If there is no island, return 0
         Constraints:

    m == grid.length
    n == grid[i].length
    1 <= m, n <= 50
    grid[i][j] is either 0 or 1.

         */
        public static int MaxAreaOfIsland(int[][] grid) {
            //var m = grid.Length;
            var n = grid[0].Length;
            int maxArea = 0;
            int sr = 0;
            foreach (var row in grid) {
                int sc = 0;
                foreach (var val in row) {
                    if (val==island) {
                        maxArea = System.Math.Max(maxArea, Fill(grid, sr, sc, island, filled)); 
                    }
                    sc++;
                }
                sr++;
            }
            return maxArea;
        }
        const int island = 1;
        const int filled = -1;
    }
}
