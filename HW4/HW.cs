using System;
using System.Security.Cryptography.X509Certificates;

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

            // добавляем запретные клетки
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
        public static int n, m;
        public static int[,] c = new int[20, 20];
        public static char[] x = new char [20];
        public static char[] y = new char[20];
        public static char[,] b = new char[20, 20];

        public static void PrintSequence(int i, int j)
        {
            if (i == 0 || j == 0)
                return;
            if (b[i, j] == 'c')
            {
                PrintSequence(i - 1, j - 1);
                Console.Write(x[i - 1]);
            }
            else if (b[i, j] == 'u')
                PrintSequence(i - 1, j);
            else
                PrintSequence(i, j - 1);
        }

        public static void Lcs()
        {
            m = x.Length;
            n = y.Length;

            for (int i = 0; i < m; i++)
            {
                c[i, 0] = 0;
            }

            for (int i = 0; i < n; i++)
            {
                c[0, i] = 0;
            }
            //c, u и l обозначают поперечное, восходящее и нисходящее направления соответственно(cross upper left)
            //m - длина первой строки
            //n - длина второй строки

            for (int i = 1; i <= m; i++)
            {
                for (int j = 1; j <= n; j++)
                {
                    if (x[i - 1] == y[j - 1])
                    {
                        c[i, j] = c[i - 1, j - 1] + 1;
                        b[i, j] = 'c';
                    }
                    else if (c[i - 1, j] >= c[i, j - 1])
                    {
                        c[i, j] = c[i - 1, j];
                        b[i, j] = 'u';
                    }
                    else
                    {
                        c[i, j] = c[i, j - 1];
                        b[i, j] = 'l';
                    }
                }
            }
        }

        public static void Task2()
        {
            Console.WriteLine("Введите первую последовательность:");
            x = Console.ReadLine().ToCharArray();
            Console.WriteLine("Введите вторую последовательность:");
            y = Console.ReadLine().ToCharArray();
            Console.WriteLine("Наибольшая общая последовательность:");
            Lcs();
            PrintSequence(m, n);
            Console.WriteLine();

        }
    }
}