using System;

namespace HW4
{
    partial class HW
    {
        /*
         * 1. *Количество маршрутов с препятствиями. Реализовать чтение массива с препятствием и нахождение количество маршрутов.
         */

        public const int N = 8;
        public const int M = 8;

        public static void PrintArray(int[,] a, string s)
        {
            Console.WriteLine(s);
            for (int i = 0; i < a.GetLength(0); i++)
            {
                for (int j = 0; j < a.GetLength(1); j++)
                    Console.Write("{0,5}", a[i, j]);
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        public static void Task1()
        {
            int[,] a = new int[N, M];
            int[,] map = new int[N, M];

            for (int j = 0; j < M; j++)
            {
                a[0, j] = 1;
            }

            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < M; j++)
                {
                    map[i, j] = 1;
                }
            }

            map[1, 1] = 0;
            map[2, 2] = 0;
            map[3, 3] = 0;
            map[4, 4] = 0;
            PrintArray(map, "Карта запретных клеток: 0 - ходить запрещено, 1 - можно");

            for (int i = 1; i < N; i++)
            {
                a[i, 0] = 1;
                for (int j = 1; j < M; j++)
                {
                    if (map[i, j] == 0)
                    {
                        a[i, j] = 0;
                    }
                    if (map[i, j] == 1)
                    {
                        a[i, j] = a[i - 1, j] + a[i, j - 1];
                    }
                }
            }
            PrintArray(a, "Количество маршрутов с препятствиями:");
        }


        /*
         * 2. Решить задачу о нахождении длины максимальной последовательности с помощью матрицы.
         */
        public static void Task2()
        {

        }

    }
}