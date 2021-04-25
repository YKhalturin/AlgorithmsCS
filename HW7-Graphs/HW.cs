using System;
using System.IO;

namespace HW7_Graphs
{
    partial class HW
    {
        /*
         * 1. Написать функции, которые считывают матрицу смежности из файла и выводят ее на экран.
         */

        public static (int, int[,]) ReadMatrixFromFile()
        {
            var allLines = File.ReadAllLines("Matrix.txt");
            var n = Convert.ToInt32(allLines[0]);
            int[,] matrix = new int[n, n];
            int k = 0;
            for (int i = 1; i <= n; i++)
            {
                var row = allLines[i].Split(" ");
                for (int j = 0; j < row.Length; j++)
                {
                    matrix[k, j] = Convert.ToInt32(row[j]);
                }
                k++;
            }
            return (n, matrix);
        }

        public static void PrintMatrix(int[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                    Console.Write("{0,5}", matrix[i, j]);
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        public static void Task1()
        {
            var (n, matrix) = ReadMatrixFromFile();
            Console.WriteLine($"Печатаем матрицу размером {n} из файла:");
            PrintMatrix(matrix);
        }

        /*
         * 2. Написать рекурсивную функцию обхода графа в глубину.
         */
        public static void Task2()
        {
        }

        /*
         * 3. Написать функцию обхода графа в ширину.
         */
        public static void Task3()
        {
        }
    }
}