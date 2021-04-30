using System;

namespace HW8_ComplexSorting
{
    partial class HW
    {
        public static int[] FillArray(int[] a)
        {
            Random r = new Random();
            for (int i = 0; i < a.GetLength(0); i++)
            {
                a[i] = r.Next(1, Max);
            }
            return a;
        }

        public static void PrintArray(int[] a)
        {
            for (int i = 0; i < a.GetLength(0); i++)
            {
                Console.Write("{0,5}", a[i]);
            }
            Console.WriteLine();
        }

        /*
         * 1. Реализовать сортировку подсчетом.
         */
        private static int N = 10; // Размер массива
        private static int Max = 100; // Максимальное значение эдементов в массиве

        public static int[] CountingSort(int[] a)
        {
            int[] C = new int[Max + 1];
            for (int i = 0; i < N; i++)
            {
                C[a[i]]++;
            }
            int b = 0;
            for (int i = 0; i < C.Length; i++)
            {
                for (int j = 0; j < C[i]; j++)
                {
                    a[b++] = i;
                }
            }
            return a;
        }



        public static void Task1()
        {
            int[] a = new int[N];
            Console.WriteLine("Исходный массив:");
            PrintArray(FillArray(a));
            Console.WriteLine("Отсортированный массив (сортировка подсчетом):");
            PrintArray(CountingSort(a));
        }

        /*
         * 2. Реализовать быструю сортировку.
         */
        public static void Task2()
        {

        }

        /*
         * 3. *Реализовать сортировку слиянием.
         */
        public static void Task3()
        {

        }
    }
}