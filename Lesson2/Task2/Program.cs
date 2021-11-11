using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    /// <summary>
    /// 2. Написать метод подсчета количества цифр числа.
    /// </summary>
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.Write("Program counting the number of digits of a number.\nEnter numbers:");
            int number = int.Parse(Console.ReadLine());
            Console.WriteLine("Total digits is {0}", TotalNumberOfDigits(number));
        }

        static int TotalNumberOfDigits(int number)
        {
            int count = 1;
            while (Math.Abs(number) > 9)
            {
                number = number / 10;
                count++;
            }
            return count;
        }
    }
}
