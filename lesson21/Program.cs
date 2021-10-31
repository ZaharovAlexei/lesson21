using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace lesson21
{
    //Имеется пустой участок земли (двумерный массив) и план сада, который необходимо реализовать.
    //Эту задачу выполняют два садовника, которые не хотят встречаться друг с другом.
    //Первый садовник начинает работу с верхнего левого угла сада и перемещается слева направо, сделав ряд, он спускается вниз.
    //Второй садовник начинает работу с нижнего правого угла сада и перемещается снизу вверх, сделав ряд, он перемещается влево.
    //Если садовник видит, что участок сада уже выполнен другим садовником, он идет дальше. Садовники должны работать параллельно.
    //Создать многопоточное приложение, моделирующее работу садовников.
    public class Garden
    {
        const int n = 10;
        const int m = 7;
        int[,] location = new int[n, m];

        public void WorkGardener1()
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    if (location[i, j] == 0)
                    {
                        location[i, j] = 1;
                        Thread.Sleep(1);
                    }
                }
            }
        }
        public void WorkGardener2()
        {
            for (int j = m - 1; j > -1; j--)
            {
                for (int i = n - 1; i > -1; i--)
                {
                    if (location[i, j] == 0)
                    {
                        location[i, j] = 2;
                        Thread.Sleep(1);
                    }
                }
            }
        }
        public void Rezult()
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    Console.Write(" {0}", location[i, j]);
                }
                Console.WriteLine();
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            
            Garden garden = new Garden();
            ThreadStart threadStart = new ThreadStart(garden.WorkGardener1);
            Thread thread = new Thread(threadStart);
            thread.Start();
            garden.WorkGardener2();
            garden.Rezult();
            Console.ReadKey();
        }
    }
}
