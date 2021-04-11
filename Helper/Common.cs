using System;

namespace Helper
{
    public static class Common
    {
        public static int GetValueInt(string message)
        {
            int x;
            string s;
            bool flag;
            do
            {
                Console.WriteLine(message);
                s = Console.ReadLine();
                flag = int.TryParse(s, out x);
                if (!flag) Console.WriteLine("Введено не целое число, повторите попытку. 0 - чтобы заввершить");

            }
            while (!flag);
            return x;
        }

    }
}
