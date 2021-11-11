using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task7
{
    /// <summary>
    /// 7.
    /// a) Разработать рекурсивный метод, который выводит на экран числа от a до b(a<b).
    /// б) * Разработать рекурсивный метод, который считает сумму чисел от a до b.
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Program print numbers from a to b (if a<b) and counts the sum of numbers from a to b");
            Console.Write("a:");
            int a = int.Parse(Console.ReadLine());
            Console.Write("b:");
            int b = int.Parse(Console.ReadLine());
            PrintNumbersFormTo(a, b);
            Console.WriteLine($"Sum from {a} to {b} is {PrintSumFormTo(a, b)}");
        }
        #region a) Разработать рекурсивный метод, который выводит на экран числа от a до b(a<b).
        static void PrintNumbersFormTo(int a,int b)
        {
            if (a < b)
            {
                Console.Write($"{a} ");
                PrintNumbersFormTo(++a, b);
            }
            else if(a==b)
            {
                Console.Write($"{a}\n");
            }
        }
        #endregion

        #region б) * Разработать рекурсивный метод, который считает сумму чисел от a до b.
        static int PrintSumFormTo(int a, int b)
        {
            if (a == b)
            {
                return a;
            }
            else
                return a + PrintSumFormTo((a<b) ? ++a : --a , b);
        }
        #endregion
    }
}
