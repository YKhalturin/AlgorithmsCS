using System;
using System.Collections.Generic;

namespace HW2_Recursion
{
    partial class HW
    {
        /*
         * 1. Реализовать функцию перевода из десятичной системы в двоичную, используя рекурсию.
         */

        private static List<int> _binaryList = new();

        public static double DecimalToBinary(int x)
        {
            int binaryResult;
            if (x < 2)
            {
                _binaryList.Add(x);
                return x;
            }
            else
            {
                binaryResult = x % 2;
                _binaryList.Add(binaryResult);
                int nextNumber = x / 2;
                DecimalToBinary(nextNumber);
            }
            return binaryResult;
        }

        public static void Task1()
        {
            int x = Helper.Common.GetValueInt("Введите положительное целое число в десятичной СИ: ");
            DecimalToBinary(x);
            _binaryList.Reverse();
            Console.Write($"Число {x} в двоичной системе: ");
            foreach (var a in _binaryList)
            {
                Console.Write($"{a} ");
            }
            Console.WriteLine();
        }

        /*
         * 2. Реализовать функцию возведения числа a в степень b:
         * a. без рекурсии;
         * b. рекурсивно;
         */

        public static double Exponentiation(int a, int b)
        {
            if (b == 0) return 1;
            double result = a;
            for (int i = 1; i < Math.Abs(b); i++)
            {
                result *= a;
            }
            return b < 0 ? 1 / result : result;
        }

        public static double Exponentiation2(int a, int b)
        {
            if (b == 0) return 1;
            if (b == 1) return a;
            if (b > 0)
            {
                return a * Exponentiation2(a, b - 1);
            }
            return 1 / (a * Exponentiation2(a, -b - 1));

        }

        public static void Task2()
        {
            int a = Helper.Common.GetValueInt("Введите основание a: ");
            int b = Helper.Common.GetValueInt("Введите степень b: ");

            Console.WriteLine("Использование стнадартной функции Math.Pow(a, b)");
            Console.WriteLine($"{a} в степени {b} = {Math.Pow(a, b)}");

            Console.WriteLine("Не рекурсивный алгоритм.");
            Console.WriteLine($"{a} в степени {b} = {Exponentiation(a, b)}");

            Console.WriteLine("Рекурсивный алгоритм.");
            Console.WriteLine($"{a} в степени {b} = {Exponentiation2(a, b)}");
        }
    }
}