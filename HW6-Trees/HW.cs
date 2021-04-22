using System;
using System.Xml;

namespace HW6_Trees
{
    partial class HW
    {

        /*
         * 1. Реализовать простейшую хеш-функцию. На вход функции подается строка, на выходе сумма кодов символов.
         */

        public static int SimpleHash(string str)
        {
            int z, res = 0;
            foreach (var ch in str)
            {
                z = (int) ch % 100;
                res += z;
            }
            return res;
        }

        public static void Task1()
        {
            var str = "Hello World";
            Console.Write($"Hash('{str}') = " + SimpleHash(str));
            Console.WriteLine();
        }


        /*
         * 2. Переписать программу, реализующую двоичное дерево поиска.
         * а) Добавить в него обход дерева различными способами;
         * б) Реализовать поиск в двоичном дереве поиска;
         */

        class BinarySearchTree
        {
            public class Node
            {
                public int key;
                public Node left, right;

                public Node(int item)
                {
                    key = item;
                    left = right = null;
                }
            }
            public Node root;


            public BinarySearchTree()
            {
                root = null;
            }

            public void Insert(int key)
            {
                root = InsertRec(root, key);
            }


            Node InsertRec(Node root, int key)
            {
                if (root == null)
                {
                    root = new Node(key);
                    return root;
                }

                if (key < root.key)
                    root.left = InsertRec(root.left, key);
                else if (key > root.key)
                    root.right = InsertRec(root.right, key);

                return root;
            }

            public void printTree(Node root)
            {
                if (root != null)
                {
                    Console.Write(root.key);
                    if (root.left != null || root.right != null)
                    {
                        Console.Write("(");
                        if (root.left != null)
                        {
                            printTree(root.left);
                        }
                        else
                        {
                            Console.Write("NULL");
                        }
                        Console.Write(",");
                        if (root.right != null)
                        {
                            printTree(root.right);
                        }
                        else
                        {
                            Console.Write("NULL");
                        }
                        Console.Write(")");
                    }
                }
            }

            public void InOrder()
            {
                InOrderRec(root);
            }

            public void PreOrder()
            {
                PreOrderRec(root);
            }

            public void PostOrder()
            {
                PostOrderRec(root);
            }

            void PreOrderRec(Node root)
            {
                if (root != null)
                {
                    Console.WriteLine(root.key);
                    PreOrderRec(root.left);
                    PreOrderRec(root.right);
                }
            }

            void InOrderRec(Node root)
            {
                if (root != null)
                {
                    InOrderRec(root.left);
                    Console.WriteLine(root.key);
                    InOrderRec(root.right);
                }
            }

            void PostOrderRec(Node root)
            {
                if (root != null)
                {
                    PostOrderRec(root.left);
                    PostOrderRec(root.right);
                    Console.WriteLine(root.key);
                }
            }

            public Node Searh(int key, Node root)
            {
                if (root != null)
                {
                    if (key == root.key)
                    {
                        return root;
                    }
                    if (key < root.key)
                    {
                        return Searh(key, root.left);
                    }
                    else
                    {
                        return Searh(key, root.right);
                    }
                }
                else
                {
                    return null;
                }
            }
        }

        public static void Task2()
        {
            BinarySearchTree tree = new BinarySearchTree();
            /* 
                  50
               /     \
              30      70
             /  \    /  \
           20   40  60   80 */

            tree.Insert(50);
            tree.Insert(30);
            tree.Insert(20);
            tree.Insert(40);
            tree.Insert(70);
            tree.Insert(60);
            tree.Insert(80);

            Console.WriteLine("Печатаем дерево в скобочной записи:");
            tree.printTree(tree.root);
            Console.WriteLine("");
            Console.WriteLine("Прямой обход:");
            tree.PreOrder();
            Console.WriteLine("Симметричный обход:");
            tree.InOrder();
            Console.WriteLine("Обратный обход:");
            tree.PostOrder();
            
            var searchKey = 60;
            Console.WriteLine($"Ищем: {searchKey}");
            if (tree.Searh(searchKey, tree.root) != null)
            {
                Console.WriteLine($"Значение {searchKey} найдено");
            }
            else
            {
                Console.WriteLine($"Значение {searchKey} не найдено");
            }

            Console.ReadKey();
        }
    }
}