using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW3_Sorting
{
    partial class HW
    {
        public class MyMultiArray
        {
            public int[,] a;
            public int[,] FillArray(int i, int j)
            {
                a = new int[i, j];
                Random r = new Random();
                for (i = 0; i < a.GetLength(0); i++)
                {
                    for (j = 0; j < a.GetLength(1); j++)
                    {
                        a[i, j] = r.Next(1, 100);
                    }
                }
                return a;
            }

            public MyMultiArray(int i, int j)
            {
                Console.WriteLine($"Создаем массив. Размерность a[{i},{j}]");
                FillArray(i, j);
            }

            public void Print()
            {
                Console.WriteLine("Печатаем массив: ");
                for (int i = 0; i < a.GetLength(0); i++)
                {
                    for (int j = 0; j < a.GetLength(1); j++)
                        Console.Write("{0,5}", a[i, j]);
                    Console.WriteLine();
                }
                Console.WriteLine();
            }
        }


    /*
     * 1. Попробовать оптимизировать пузырьковую сортировку. Сравнить количество операций сравнения оптимизированной и не оптимизированной программы. 
     * Написать функции сортировки, которые возвращают количество операций.
     */
    public static void Task1()
        {
            MyMultiArray myMultiArray = new MyMultiArray(3, 4);
            myMultiArray.Print();
        }

        /*
         * 2. *Реализовать шейкерную сортировку.
         */

        public static void Task2()
        {

        }

        /*
         * 3. Реализовать бинарный алгоритм поиска в виде функции, которой передается отсортированный массив. 
         * Функция возвращает индекс найденного элемента или -1, если элемент не найден.
         * */

        public static void Task3()
        {

        }

    }
}
