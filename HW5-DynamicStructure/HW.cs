using System;

namespace HW5_DynamicStructure
{
    partial class HW
    {

        /*
        * 1. Реализовать перевод из десятичной в двоичную систему счисления с использованием стека.
        */

        // Стек на основе массива
        public class StackByArray<T>
        {
            private T[] items;
            private int count;
            
            public StackByArray(int length)
            {
                items = new T[length];
            }
            
            public bool IsEmpty
            {
                get { return count == 0; }
            }
            
            public int Count
            {
                get { return count; }
            }
            
            public void Push(T item)
            {
                if (count == items.Length)
                    throw new InvalidOperationException("Переполнение стека");
                items[count++] = item;
            }
            
            public T Pop()
            {
                if (IsEmpty)
                    throw new InvalidOperationException("Стек пуст");
                T item = items[--count];
                items[count] = default(T);
                return item;
            }

            public T Peek()
            {
                return items[count - 1];
            }
        }

        private static readonly StackByArray<int> BinaryList = new StackByArray<int>(100);

        public static double DecimalToBinary(int x)
        {
            int binaryResult;
            if (x < 2)
            {
                BinaryList.Push(x);
                return x;
            }
            else
            {
                binaryResult = x % 2;
                BinaryList.Push(binaryResult);
                int nextNumber = x / 2;
                DecimalToBinary(nextNumber);
            }
            return binaryResult;
        }


        public static void Task1()
        {
            int x = Helper.Common.GetValueInt("Введите положительное целое число в десятичной СИ: ");
            DecimalToBinary(x);
            Console.Write($"Число {x} в двоичной системе: ");
            while (!BinaryList.IsEmpty)
            {
                Console.Write(BinaryList.Pop() + " ");
            }
            Console.WriteLine();

        }

        /*
        * 2. Добавить в программу «реализация стека на основе односвязного списка» проверку на выделение памяти. Если память не выделяется, то выводится соответствующее сообщение.
        * Постарайтесь создать ситуацию, когда память не будет выделяться (добавлением большого количества данных).
        */

        // Стек на основе списка
        public class Node
        {
            public Node Next { get; set; }
            public int Value { get; set; }
            public Node _head, _tail;
        }
        
        public class StackByList : Node
        {
            public int Count { get; private set; }
            public void Push(int value)
            {
                Node n = new Node { Value = value };
                if (_head == null)
                {
                    _head = n;
                    _tail = n;
                }
                else
                {
                    _tail.Next = n;
                    _tail = n;
                }
                Count++;
            }
            public int Pop()
            {
                if (Count < 1)
                    throw new Exception("Стек пуст!");
                if (Count == 1)
                {
                    Count = 0;
                    int t = _head.Value;
                    _head = _tail = null;
                    return t;
                }

                Node prev = _head;
                while (prev.Next != _tail)
                {
                    prev = prev.Next;
                }

                int tmp = prev.Next.Value;

                _tail = prev;

                Count--;
                return tmp;
            }
        }


        public static void Task2()
        {
            var s = new StackByList();
            s.Push(44);
            s.Push(12);
            s.Push(45);
            s.Push(56);
            s.Push(90);
            
            Console.Write("Печатаем стек на основе списка: ");
            while (s.Count > 0)
            {
                Console.Write(s.Pop() + " ");
            }
            Console.WriteLine();
        }

        /*
        * 3. Написать программу, которая определяет, является ли введенная скобочная последовательность правильной.
        * Примеры правильных скобочных выражений: (), ([])(), {}(), ([{}]), неправильных — )(, ())({), (, ])}), ([(]) для скобок [,(,{.
        */

        public static bool CorrectBracketSequence(string str)
        {
            var bracketSequence = new StackByArray<char>(100);

            if (str[0] == ')' || str[0] == ']' || str[0] == '}') return false;

            foreach (var item in str)
            {
                switch (item)
                {
                    case '(':
                        bracketSequence.Push('(');
                        break;
                    case '[':
                        bracketSequence.Push('[');
                        break;
                    case '{':
                        bracketSequence.Push('{');
                        break;
                    case ')':
                        if (!bracketSequence.IsEmpty && bracketSequence.Peek() == '(') bracketSequence.Pop();
                        else return false;
                        break;
                    case ']':
                        if (!bracketSequence.IsEmpty && bracketSequence.Peek() == '[') bracketSequence.Pop();
                        else return false;
                        break;
                    case '}':
                        if (!bracketSequence.IsEmpty && bracketSequence.Peek() == '{') bracketSequence.Pop();
                        else return false;
                        break;
                    default:
                        return false;
                }
            }
            return bracketSequence.Count <= 0;
        }

        public static void Task3()
        {
            var s1 = "()";
            var s2 = "([])()";
            var s3 = "{}()";
            var s4 = "([{}])";
            var s5 = ")(";
            var s6 = "())({)";
            var s7 = "(";
            var s8 = "])})";
            var s9 = "([(])";
            var s10 = "([{()({[][]}){()()}(){}{}{[()]}}])";

            Console.WriteLine($"Последовательность {s1} корректна: {CorrectBracketSequence(s1)}");
            Console.WriteLine($"Последовательность {s2} корректна: {CorrectBracketSequence(s2)}");
            Console.WriteLine($"Последовательность {s3} корректна: {CorrectBracketSequence(s3)}");
            Console.WriteLine($"Последовательность {s4} корректна: {CorrectBracketSequence(s4)}");
            Console.WriteLine($"Последовательность {s5} корректна: {CorrectBracketSequence(s5)}");
            Console.WriteLine($"Последовательность {s6} корректна: {CorrectBracketSequence(s6)}");
            Console.WriteLine($"Последовательность {s7} корректна: {CorrectBracketSequence(s7)}");
            Console.WriteLine($"Последовательность {s8} корректна: {CorrectBracketSequence(s8)}");
            Console.WriteLine($"Последовательность {s9} корректна: {CorrectBracketSequence(s9)}");
            Console.WriteLine($"Последовательность {s10} корректна: {CorrectBracketSequence(s10)}");
        }
    }
}