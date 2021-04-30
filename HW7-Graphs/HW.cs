using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace HW7_Graphs
{
    partial class HW
    {
        /*
         * 1. Написать функции, которые считывают матрицу смежности из файла и выводят ее на экран.
         */

        public static (int, int[,]) ReadMatrixFromFile(string filePath)
        {
            var allLines = File.ReadAllLines(filePath);
            var n = Convert.ToInt32(allLines[0]);
            int[,] matrix = new int[n, n];
            int k = 0;
            for (int i = 1; i <= n; i++)
            {
                var row = allLines[i].Split(" ");
                for (int j = 0; j < row.Length; j++)
                {
                    matrix[k, j] = Convert.ToInt32(row[j]);
                }
                k++;
            }
            return (n, matrix);
        }

        public static void PrintMatrix(int[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                    Console.Write("{0,5}", matrix[i, j]);
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        public static void Task1()
        {
            var (n, matrix) = ReadMatrixFromFile("Matrix.txt");
            Console.WriteLine($"Печатаем матрицу размером {n}x{n} из файла:");
            PrintMatrix(matrix);
        }

        public class DoublyNode<T>
        {
            public DoublyNode(T data)
            {
                Data = data;
            }
            public T Data { get; set; }
            public DoublyNode<T> Previous { get; set; }
            public DoublyNode<T> Next { get; set; }
        }

        public class Deque<T> : IEnumerable<T>  
        {
            DoublyNode<T> head; // головной/первый элемент
            DoublyNode<T> tail; // последний/хвостовой элемент
            int count;  // количество элементов в списке

            // добавление элемента
            public void AddLast(T data)
            {
                DoublyNode<T> node = new DoublyNode<T>(data);

                if (head == null)
                    head = node;
                else
                {
                    tail.Next = node;
                    node.Previous = tail;
                }
                tail = node;
                count++;
            }
            public void AddFirst(T data)
            {
                DoublyNode<T> node = new DoublyNode<T>(data);
                DoublyNode<T> temp = head;
                node.Next = temp;
                head = node;
                if (count == 0)
                    tail = head;
                else
                    temp.Previous = node;
                count++;
            }
            public T RemoveFirst()
            {
                if (count == 0)
                    throw new InvalidOperationException();
                T output = head.Data;
                if (count == 1)
                {
                    head = tail = null;
                }
                else
                {
                    head = head.Next;
                    head.Previous = null;
                }
                count--;
                return output;
            }
            public T RemoveLast()
            {
                if (count == 0)
                    throw new InvalidOperationException();
                T output = tail.Data;
                if (count == 1)
                {
                    head = tail = null;
                }
                else
                {
                    tail = tail.Previous;
                    tail.Next = null;
                }
                count--;
                return output;
            }
            public T First
            {
                get
                {
                    if (IsEmpty)
                        throw new InvalidOperationException();
                    return head.Data;
                }
            }
            public T Last
            {
                get
                {
                    if (IsEmpty)
                        throw new InvalidOperationException();
                    return tail.Data;
                }
            }

            public int Count { get { return count; } }
            public bool IsEmpty { get { return count == 0; } }
            
            IEnumerator IEnumerable.GetEnumerator()
            {
                return ((IEnumerable)this).GetEnumerator();
            }

            IEnumerator<T> IEnumerable<T>.GetEnumerator()
            {
                DoublyNode<T> current = head;
                while (current != null)
                {
                    yield return current.Data;
                    current = current.Next;
                }
            }
        }


        /*
         * 2. Написать рекурсивную функцию обхода графа в глубину.
         */
        public class Graph
        {
            private int _numVertices;
            private LinkedList<int>[] _adjLists;
            private bool[] _visited;

            public Graph(int vertices)
            {
                _numVertices = vertices;
                _adjLists = new LinkedList<int>[vertices];
                _visited = new bool[vertices];

                for (int i = 0; i < vertices; i++)
                    _adjLists[i] = new LinkedList<int>();
            }

            public void addEdge(int src, int dest)
            {
                _adjLists[src].AddFirst(dest);
            }

            public void DFS(int vertex)
            {
                _visited[vertex] = true;
                Console.WriteLine($"Посетили вершину: {vertex}");
                foreach (var item in _adjLists[vertex])
                {
                    if (!_visited[item]) DFS(item);
                }

            }
        }

        public static void Task2()
        {
            var graph = new Graph(5);
            graph.addEdge(0, 1);
            graph.addEdge(0, 2);
            graph.addEdge(0, 3);
            graph.addEdge(1, 2);
            graph.addEdge(2, 4);

            Console.WriteLine("Обход графа в глубину:");
            graph.DFS(0);
        }

        /*
         * 3. Написать функцию обхода графа в ширину.
         */
        public static bool CheckPeakStatus(int[] peakStatus) => peakStatus.Any(x => x < 3);

        public static void PrintArray(int[] peakStatus)
        {
            Console.Write("Статусы массива с вершинами на очередном шаге: ");
            for (int i = 0; i < peakStatus.GetLength(0); i++)
            {
                Console.Write("{0,5}", peakStatus[i]);
            }
            Console.WriteLine();
        }

        public static void BFS(int[,] w, int n)
        {
            int[] peakStatus = new int[n];
            var deq = new Deque<int>();

            for (int i = 0; i < n; i++)
            {
                peakStatus[i] = 1;
            }

            peakStatus[0] = 2;
            deq.AddFirst(0);
            int currentPeak;
            do
            {
                currentPeak = deq.RemoveFirst();
                if (peakStatus[currentPeak] == 2)
                {
                    for (int i = 0; i < n; i++)
                    {
                        if (w[currentPeak, i] != 0)
                        {
                            if (peakStatus[i] == 1)
                            {
                                deq.AddLast(i);
                                peakStatus[i] = 2;
                            }
                        }
                    }
                    peakStatus[currentPeak] = 3;
                    PrintArray(peakStatus);
                }

            } while (CheckPeakStatus(peakStatus));
        }
        public static void Task3()
        {
            var (n, w) = ReadMatrixFromFile("GraphM.txt");
            Console.WriteLine($"Печатаем матрицу смежности размером {n}x{n} из файла:");
            PrintMatrix(w);
            Console.WriteLine("Обход графа в ширину:");
            BFS(w, n);
        }
    }
}