using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    /// <summary>
    /// 1. Написать метод, возвращающий минимальное из трёх чисел.
    /// </summary>
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Program find minimum of three numbers\nEnter three numbers-");
            Console.Write("First number:");
            int a = int.Parse(Console.ReadLine());
            Console.Write("Second number:");
            int b = int.Parse(Console.ReadLine()); 
            Console.Write("Third number:");
            int c = int.Parse(Console.ReadLine());
            Console.WriteLine("Minimum of three numbers is {0}",Min(a,b,c));
        }

        static int Min(int a, int b, int c)
            => Min(a, b) == a ? Min(a, c) : Min(b, c); 

        static int Min(int a, int b)
            => (a < b) ? a : b;

        static int MinOfThree(int a,int b, int c)
        {
            int min = a < b ? a : b;
            return min < c ? min : c;
        }
    }
}
