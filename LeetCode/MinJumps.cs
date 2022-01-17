using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    public static partial class Solution
    {
        /*  Jump Game IV
          Given an array of integers arr, you are initially positioned at the first index of the array.

In one step you can jump from index i to index:

    i + 1 where: i + 1 < arr.length.
    i - 1 where: i - 1 >= 0.
    j where: arr[i] == arr[j] and i != j.

Return the minimum number of steps to reach the last index of the array.

Notice that you can not jump outside of the array at any time.
        Constraints:

    1 <= arr.length <= 5 * 104
    -108 <= arr[i] <= 108
*/
        private struct point { internal int i; internal int val; };
        public static int MinJumps(int[] arr)
        {

            switch (arr.Length)
            {
                case 0:
                case 1:
                    return 0;
                case 2:
                    return 1;
                default:
                    break;
            }
            /* Пусть 
             * nJump - расстояние в шагах от элемента 0 
             * key - значение элемента i
             * index - указатель на элемент (индекс элемента в массиве nums)
             * Для эффективного поиска по key строим вспомогательные массивы keys и indexes
             * Наиболее краткий путь находим методом прямой и обратной волны. 
             * Прямую волну строим, "закрашивая" обработанные элементы цветом vizited = int.MaxValue.
             * Цвет посещенного элемента и его соседних элементов вносим в список доступных на следующем шагу цветов.
             * 
             * nJump==0 => расстояние неизвестно. 
             * nJump>0 =>известно расстояние до начала, nJump <0 => известно расстояние до конечного элемента
             * iJumps = список указателей на ячейки, доступные следующим шагом от текущей
             */

            //int arrLenght = arr.Length;
            int color, leftColor = arr[0], rightColor = arr[^1];
            if (leftColor == rightColor)
            {
                return 1;
            }
            int[] keys = new int[arr.Length];
            Array.Copy(arr, keys, arr.Length);
            int[] indexes = new int[arr.Length];
            int i , j;
            // indexes[0] = -1;
            for (i = 1; i < arr.Length; i++)
            {
                indexes[i] = i;
            }
            Array.Sort(keys, indexes);
            List<point> leftPoints = new(), leftPointsNextStep = new(), rightPoints = new(), rightPointsNextStep = new();
            i = 1; j = 1;

            {
                //i++;
                if (arr[1] == rightColor)
                {
                    return 2;
                }
                else if (arr[1] != leftColor)
                {
                    leftPoints.Add(new point { i = 1, val = arr[1] });
                    arr[1] = leftColor;
                }
                foreach (var p_c in SearceAll(keys, indexes, leftColor))
                {
                    if (p_c > 0)
                    {
                        leftPoints.Add(new point { i = p_c, val = arr[p_c] });
                        arr[p_c] = leftColor;
                    }
                }
                //j++;

                var p = arr.Length - 1;
                if (arr[p - 1] == leftColor)
                {
                    return 2;
                }
                else if (arr[p - 1] != rightColor)
                {
                    rightPoints.Add(new point { i = p - 1, val = arr[p - 1] });
                    arr[p - 1] = rightColor;
                }
                foreach (var p_c in SearceAll(keys, indexes, rightColor))
                {
                    if (p_c < p)
                    {
                        rightPoints.Add(new point { i = p_c, val = arr[p_c] });
                        arr[p_c] = rightColor;
                    }
                }
                arr[p] = rightColor;
            }
            HashSet<int> levelColors = new();
            while (i < arr.Length)
            {
                i++;
                foreach (var pnt in leftPoints)
                {
                    var p = pnt.i;
                    color = pnt.val;
                    if (arr[p + 1] == rightColor)
                    {
                        return i + j;
                    }
                    else if (arr[p + 1] != leftColor)
                    {
                        leftPointsNextStep.Add(new point { i = p+1, val = arr[p+1] });
                        arr[p + 1] = leftColor;
                    }
                    if (arr[p - 1] == rightColor)
                    {
                        return i + j;
                    }
                    else if (arr[p - 1] != leftColor)
                    {
                        leftPointsNextStep.Add(new point { i = p-1, val = arr[p-1] });
                        arr[p - 1] = leftColor;
                    }
                    if (levelColors.Add(color))
                    {
                        foreach (var p_c in SearceAll(keys, indexes, color))
                        {
                            if (arr[p_c] == rightColor)
                            {
                                return i + j;
                            }
                            else if (arr[p_c] != leftColor & p_c != p)
                            {
                                leftPointsNextStep.Add(new point { i = p_c, val = arr[p_c] } );
                                arr[p_c] = leftColor;
                            }
                        }
                    }
                    //arr[p] = leftColor;
                }
                j++;
                levelColors.Clear();
                foreach (var pnt in rightPoints)
                {
                    var p = pnt.i;
                    color = pnt.val;
                    if (arr[p + 1] == leftColor)
                    {
                        return i + j;
                    }
                    else if (arr[p + 1] != rightColor)
                    {
                        rightPointsNextStep.Add(new point { i = p+1, val = arr[p+1] });
                        arr[p + 1] = rightColor;
                    }
                    if (arr[p - 1] == leftColor)
                    {
                        return i + j;
                    }
                    else if (arr[p - 1] != rightColor)
                    {
                        rightPointsNextStep.Add(new point { i = p-1, val = arr[p-1] });
                        arr[p - 1] = rightColor;
                    }
                    if (levelColors.Add(color))
                    {
                        foreach (var p_c in SearceAll(keys, indexes, color))
                        {
                            if (arr[p_c] == leftColor)
                            {
                                return i + j;
                            }
                            else if (arr[p_c] != rightColor & p_c != p)
                            {
                                rightPointsNextStep.Add(new point { i = p_c, val = arr[p_c] });
                                arr[p_c] = rightColor;
                            }
                        }
                    }

                    //arr[p] = rightColor;
                }
                levelColors.Clear();
                var points = leftPoints;
                points.Clear();
                leftPoints = leftPointsNextStep;
                leftPointsNextStep = points;
                points = rightPoints;
                points.Clear();
                rightPoints = rightPointsNextStep;
                rightPointsNextStep = points;
            }
            return i + j;
        }

        private static IEnumerable<int> SearceAll(int[] keys, int[] indexes, int value)
        {
            int point = Array.BinarySearch<int>(keys, value);
            if (point > -1)
            {
                for (int k = point; k < keys.Length && keys[k] == value; k++)
                {
                    yield return indexes[k];
                }
                for (int k = point - 1; k >= 0 && keys[k] == value; k--)
                {
                    yield return indexes[k];
                }
            }
        }
    }
}
