using System;

namespace HW6_Trees
{
    class Program
    {
        static int Menu()
        {
            int m;
            do
            {
                Console.WriteLine("1 - Task1");
                Console.WriteLine("2 - Task2");
                Console.WriteLine("0 - Exit");
                m = Convert.ToInt32(Console.ReadLine());
            } while (m < 0 && m > 4);

            return m;
        }

        static void Main(string[] args)
        {
            int menu;
            do
            {
                menu = Menu();
                switch (menu) //goto menu
                {
                    case 1:
                        HW.Task1();
                        break;
                    case 2:
                        HW.Task2();
                        break;
                    default:
                        Console.WriteLine("Bye!");
                        break;
                }
            } while (menu != 0);
        }
    }
}
