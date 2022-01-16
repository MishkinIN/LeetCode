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
            int nextColor, startColor = arr[0], endColor = arr[^1], vizited = int.MaxValue;
            if (startColor == endColor)
            {
                return 1;
            }
            int[] keys = new int[arr.Length];
            Array.Copy(arr, keys, arr.Length);
            int[] indexes = new int[arr.Length];
            int i = 0, j, key, index;
            // indexes[0] = -1;
            for (i = 1; i < arr.Length; i++)
            {
                indexes[i] = i;
            }
            Array.Sort(keys, indexes);
            HashSet<int> leftColors = new HashSet<int>(), leftColorsNextStep = new HashSet<int>();

            HashSet<int> rightColors = new HashSet<int>(), rightColorsNextStep = new HashSet<int>();
            leftColors.Add(startColor);
            leftColors.Add(arr[1]);
            arr[1] = startColor;
            arr[0] = vizited;
            rightColors.Add(endColor);
            rightColors.Add(arr[^2]);
            arr[^1] = vizited;
            arr[^2] = endColor;
            Func<int, bool> isVizited = (index => arr[index] == vizited);
            i = 1; j = 1;
            while (i < arr.Length)
            {
                foreach (var color in leftColors)
                {
                    if (color == endColor)
                    {
                        return i + j;
                    }
                    foreach (var p in SearceAll(keys, color))
                    {
                        index = indexes[p];
                        if (!isVizited(index))
                        {
                            if (arr[index] == endColor)
                            {
                                return i + j;
                            }
                            if (!(isVizited(index + 1) || arr[index + 1] == startColor))
                            {
                                //nextColor = arr[index + 1];
                                //if (nextColor == endColor)
                                //{
                                //    return i + j + 1;
                                //}
                                leftColorsNextStep.Add(arr[index + 1]);
                                arr[index + 1] = startColor;
                            }
                            if (!(isVizited(index - 1) || arr[index - 1] == startColor))
                            {
                                //nextColor = arr[index - 1];
                                //if (nextColor == endColor)
                                //{
                                //    return i + j + 1;
                                //}
                                leftColorsNextStep.Add(arr[index - 1]);
                                arr[index - 1] = startColor;
                            }
                            arr[index] = vizited;
                        }
                    }
                }
                var vs = leftColors;
                leftColors = leftColorsNextStep;
                leftColorsNextStep = vs;
                leftColorsNextStep.Clear();
                i++;

            }
            return i + j;

            //List<KeyValuePair<int, int>> nextStep = new();
            //Func<List<KeyValuePair<int, int>>, List<KeyValuePair<int, int>>> getNextStep = (step) =>
            //{
            //    List<KeyValuePair<int, int>> nextStep = new();
            //    foreach (var item in step)
            //    {
            //        int point = item.Value + 1;
            //        if (point == arrLenght - 1)
            //        {
            //            return null;
            //        }
            //        else //if (points[point]>0)
            //        {
            //            foreach (var p in SearceAll(keys, arr[point]))
            //            {
            //                if (indexes[p] == point)
            //                {
            //                    nextStep.Add(KeyValuePair.Create(arr[point], point));
            //                    indexes[p] = -1;
            //                    break;
            //                }
            //            }
            //        }
            //        // Поиск переходов по значению
            //        key = item.Key;
            //        foreach (var p in SearceAll(keys, key))
            //        {
            //            if (indexes[p] == arrLenght - 1)
            //            {
            //                return null;
            //            }
            //            else if (indexes[p] > 0)
            //            {
            //                if (indexes[p] == item.Value)
            //                {
            //                    indexes[p] = -1;
            //                }
            //                else
            //                {
            //                    nextStep.Add(KeyValuePair.Create(keys[p], indexes[p]));
            //                    indexes[p] = -1;
            //                }
            //            }
            //        }

            //        point = item.Value - 1;
            //        if (point > 1)
            //        {
            //            {
            //                foreach (var p in SearceAll(keys, arr[point]))
            //                {
            //                    if (indexes[p] == point)
            //                    {
            //                        nextStep.Add(KeyValuePair.Create(arr[point], point));
            //                        indexes[p] = -1;
            //                        break;
            //                    }
            //                }
            //            }
            //        }
            //    }
            //    return nextStep;
            //};
            //// [  0,  1,  2,  3,  4, 5, 6, 7,8,  9]
            //// [100,-23,-23,404,100,23,23,23,3,404]
            //List<KeyValuePair<int, int>> leftStep = new();
            //leftStep.Add(KeyValuePair.Create(arr[0], 0));
            //for (int nJump = 1; nJump < arrLenght; nJump++)
            //{
            //    leftStep = getNextStep(leftStep);
            //    if (leftStep == null)
            //    {
            //        return nJump;
            //    }
            //}
            //return arrLenght - 1;
        }
        private static IEnumerable<int> SearceAll(int[] nums, int value)
        {
            int point = Array.BinarySearch<int>(nums, value);
            if (point > -1)
            {
                for (int k = point; k < nums.Length && nums[k] == value; k++)
                {
                    yield return k;
                }
                for (int k = point - 1; k >= 0 && nums[k] == value; k--)
                {
                    yield return k;
                }
            }
        }
    }
}
