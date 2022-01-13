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
        There are some spherical balloons taped onto a flat wall that represents the XY-plane.
        The balloons are represented as a 2D integer array points where points[i] = [xstart, xend]
        denotes a balloon whose horizontal diameter stretches between xstart and xend.
        You do not know the exact y-coordinates of the balloons.
        Arrows can be shot up directly vertically (in the positive y-direction) 
        from different points along the x-axis. A balloon with xstart and xend is burst by an arrow
        shot at x if xstart <= x <= xend. There is no limit to the number of arrows that can be shot.
        A shot arrow keeps traveling up infinitely, bursting any balloons in its path.
        Given the array points, return the minimum number of arrows that must be shot to burst all balloons. */
        /*На плоской стене, изображающей плоскость XY, приклеены несколько сферических воздушных шаров.
         * Воздушные шары представлены в виде двухмерного целочисленного массива точек,
         * где points[i] = [xstart, xend] обозначает воздушный шар,
         * горизонтальный диаметр которого простирается между xstart и xend.
         * Вы не знаете точные координаты y воздушных шаров.
         * Стрелки могут быть направлены прямо вертикально (в положительном направлении y)
         * из разных точек вдоль оси x. Воздушный шар с xstart и xend лопается от стрелы,
         * выпущенной в x, если xstart <= x <= xend. Количество стрел, которые можно выпустить, не ограничено.
         * Выпущенная стрела продолжает бесконечно лететь вверх, разрывая все воздушные шары на своем пути.
         * Учитывая точки массива, верните минимальное количество стрел, которое нужно пустить,
         * чтобы взорвать все воздушные шары.*/
        public static int FindMinArrowShots(int[][] points)
        {
            /* Мой план. назовем [xstart, xend] - отрезком.
             * 1. Выполнить сортировку массива по координатам начала отрезков. 
             * 1.1 Принимаем nArrows=1.
             * 1.2 Принимаем отрезок запуска первой стрелы dist1 как первый отрезок.
             * 2. Находим пересечение dist1 и следующего отрезка, заносим в dist1.
             * 3. Если dist1 не пусто, переходим к следующему отрезку. 
             *      иначе, увеличиваем nArrows++ и принимаем dist1 равным очередному отрезку.
             * 4. Так проходим весь массив.
             */
            if (points==null || points.Length==0)
            {
                return 0;
            }
            int nArrows = 1;
            Array.Sort<int[]>(points, (sec1, sec2) => sec1[0] - sec2[0]);
            var dist1 = points[0];
            for (int i = 1; i < points.Length; i++)
            {
                Union(dist1, points[i]);
                if (IsEmpty(dist1))
                {
                    nArrows++;
                    dist1 = points[i];
                }
            }
            return nArrows;
        }
        private static void Union(int[] one, int[] other)
        {
            one[0] = Math.Max(one[0], other[0]);
            one[1] = Math.Min(one[1], other[1]);
        }
        private static bool IsEmpty(int[] vs)
        {
            return vs[0] > vs[1];
        }
    }
}
