using System;

namespace HW1_BaseAlgorithms
{
    /*
     * Халтурин Юрий
     */

    partial class HW
    {
        /*
         * 1. Ввести вес и рост человека. Рассчитать и вывести индекс массы тела по формуле I=m/(h*h);
         * где m-масса тела в килограммах, h - рост в метрах.
         */

        public static void Task1()
        {
            Console.Write("Введите вашу массу тела в килограммах: ");
            string weightStr = Console.ReadLine();
            int weight = Convert.ToInt32(weightStr);
            
            Console.Write("Введите ваш рост в метрах: ");
            string heightStr = Console.ReadLine();
            double height = Convert.ToDouble(heightStr);
            double index = weight / (height * height);

            Console.WriteLine($"Ваш индекс массы тела: {index:F1}");
            Console.ReadKey();
        }

        /*
         * 2. Найти максимальное из четырех чисел. Массивы не использовать.
         */


        public static int Min(int a, int b)
        {
            return a < b ? a : b;
        }
        public static int GetMin4Numbers(int a, int b, int c, int d)
        {
            return Min(Min(a,b), Min(c, d));
        }

        public static void Task2()
        {
            int a = 23;
            int b = 22;
            int c = 54;
            int d = -5;

            Console.WriteLine($"Минимальное из 4х чисел {a}, {b}, {c}, {d} : {GetMin4Numbers(a, b, c, d)}");
        }

        /*
         * 3. Написать программу обмена значениями двух целочисленных переменных:
         * a. с использованием третьей переменной;
         * b. *без использования третьей переменной.
         */

        public static void Task3()
        {


        }

        /*
         * 4. Написать программу нахождения корней заданного квадратного уравнения.
         */

        public static void Task4()
        {


        }

    }
}