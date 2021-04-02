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

        static (int, int) ReverseValuesA(int a, int b)
        {
            var temp = a;
            a = b;
            b = temp;
            return (a, b);
        }

        static (int, int) ReverseValuesB(int a, int b)
        {
            b = a + b;
            a = b - a;
            b = b - a;
            return (a, b);
        }

        public static void Task3()
        {
            var a = 2;
            var b = 9;
            Console.WriteLine($"Иходные данные: a={a}, b={b}");
            Console.WriteLine("Меняем значения двух переменных a И b...");
            var tupleOptionA = ReverseValuesA(a, b);
            Console.WriteLine($"Результат с использованием третьей переменной: a={tupleOptionA.Item1}, b={tupleOptionA.Item2}");
            var tupleOptionB = ReverseValuesB(a, b);
            Console.WriteLine($"Результат *без использования третьей переменной: a={tupleOptionB.Item1}, b={tupleOptionB.Item2}");
            Console.ReadKey();

        }

        /*
         * 4. Написать программу нахождения корней заданного квадратного уравнения.
         */

        public static double GetValue(string str)
        {
            Console.WriteLine(str);
            string input = Console.ReadLine();
            double d;
            if (!Double.TryParse(input, out d))  Console.WriteLine("Ввведено значение не типа 'Double'");
            return d;
        }

        // true == '+', false == '-'
        public static double QuadraticSolution(double a, double b, double c, bool sign)
        {
            double d = b * b - 4 * a * c;
            return sign ? (-b + Math.Sqrt(d)) / 2 * a : (-b - Math.Sqrt(d)) / 2 * a;
        }

        public static void Task4()
        {
            //double a = 1;
            //double b = -3;
            //double c = -4;

            double a = GetValue("Введите коэффициент a: ");
            double b = GetValue("Введите коэффициент b: ");
            double c = GetValue("Введите коэффициент c: ");

            Console.WriteLine($"Решим квадратное уравнение вида: {a}x*x + {b}x + {c} = 0");

            var x1 = QuadraticSolution(a, b, c, true);
            var x2 = QuadraticSolution(a, b, c, false);

            Console.WriteLine($"Ответ: x1 = {x1:F1}, x2 = {x2:F1}");
        }

    }
}