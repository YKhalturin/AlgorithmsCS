using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW3_Sorting
{
    partial class HW
    {
        public class MyArray
        {
            public int[] a;
            public int Count = 0;

            public int[] FillArray(int n)
            {
                a = new int[n];
                Random r = new Random();
                for (int i = 0; i < a.GetLength(0); i++)
                {
                    a[i] = r.Next(1, 100);
                }
                return a;
            }

            public MyArray(int n)
            {
                Console.WriteLine($"Создаем массив. Размерность a[{n}]");
                FillArray(n);
            }

            public void Print(string s)
            {
                Console.WriteLine(s);
                for (int i = 0; i < a.GetLength(0); i++)
                {
                    Console.Write("{0,5}", a[i]);
                }
                Console.WriteLine();
            }

            (int, int) Swap(int a, int b)
            {
                int tmp = a;
                a = b;
                b = tmp;
                return (a, b);
            }

            public int[] BubbleSort(int[] arr)
            {
                //int count = 0;
                for (int i = arr.Length - 1; i > 0; i--)
                {
                    for (int j = 0; j < i; j++)
                    {
                        Count++;
                        if (arr[j] > arr[j + 1])
                        {
                            Count++;
                            (arr[j], arr[j + 1]) = Swap(arr[j], arr[j + 1]);
                        }
                    }
                }
                return arr;
            }

           public int[] ShakerSort(int[] arr)
           {
               for (int i = arr.Length - 1; i > 0; i -= 2)
               {
                   for (int j = 0; j < i; j++)
                   {
                       Count++;
                       if (arr[j] > arr[j + 1])
                       {
                           Count++;
                            (arr[j], arr[j + 1]) = Swap(arr[j], arr[j + 1]);
                       }
                   }
                   for (int j = arr.Length - 1; j > 1; j--)
                   {
                       Count++;
                       if (arr[j] < arr[j - 1])
                       {
                           Count++;
                            (arr[j], arr[j - 1]) = Swap(arr[j], arr[j - 1]);
                       }
                   }
               }
               return arr;
            }

           public int BinarySearch(int[] arr, int value)
           {
                int l = 0;
                int r = arr.Length - 1;
                int m = l + (r - l) / 2;
                while ((l < r) && (arr[m] != value))
                {
                    if (a[m] < value)
                    {
                        l = m + 1;
                    }
                    else
                    {
                        r = m - 1;
                    }
                    m = l + (r - l) / 2;
                }

                if (a[m] == value)
                {
                    Console.WriteLine($"Искомое значение {value} найдено под индексом a[{m}]");
                    return value;
                }
                else
                {
                    Console.WriteLine($"Искомое значение {value} не найдено в массиве");
                    return -1;
                }
           }
        }


    /*
     * 1. Попробовать оптимизировать пузырьковую сортировку. Сравнить количество операций сравнения оптимизированной и не оптимизированной программы. 
     * Написать функции сортировки, которые возвращают количество операций.
     */
    public static void Task1()
        {
            MyArray myArray = new MyArray(10);
            myArray.Print("Печатаем исходный массив: ");
            myArray.BubbleSort(myArray.a);
            myArray.Print($"Печатаем отсортированный массив (пузырьковая сортировка), количество операций = {myArray.Count}");

        }

        /*
         * 2. *Реализовать шейкерную сортировку.
         */

        public static void Task2()
        {
            MyArray myArray = new MyArray(10);
            myArray.Print("Печатаем исходный массив: ");
            myArray.ShakerSort(myArray.a);
            myArray.Print($"Печатаем отсортированный массив (шейкерная сортировка), количество операций = {myArray.Count}");
        }

        /*
         * 3. Реализовать бинарный алгоритм поиска в виде функции, которой передается отсортированный массив. 
         * Функция возвращает индекс найденного элемента или -1, если элемент не найден.
         * */

        public static void Task3()
        {
            MyArray myArray = new MyArray(20);
            myArray.Print("Печатаем исходный массив: ");
            myArray.ShakerSort(myArray.a);
            myArray.Print($"Печатаем отсортированный массив (шейкерная сортировка)");
            myArray.BinarySearch(myArray.a, 55);

        }

    }
}
