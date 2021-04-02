using System;

namespace HW1_BaseAlgorithms
{
    partial class HW
    {
        /*
         * 1. Ввести вес и рост человека. Рассчитать и вывести индекс массы тела по формуле I=m/(h*h);
         * где m-масса тела в килограммах, h - рост в метрах.
         *
         * Халтурин Юрий
         */
        public static void Task1()
        {
            Console.WriteLine("Добро пожаловать в прогрумму Анкета");
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
         *
         *
         *
         */

        public static void Task2()
        {


        }

        /*
         *
         *
         *
         */

        public static void Task3()
        {


        }

        /*
         *
         *
         *
         */
        public static void Task4()
        {


        }

    }
}