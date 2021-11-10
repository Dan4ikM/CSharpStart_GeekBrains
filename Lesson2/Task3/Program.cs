using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Program calculate the sum of all odd positive numbers.\nEnter numbers, when need to stop enter zero:");
            int number = 0;
            int sum = 0;
            do
            {
                number = int.Parse(Console.ReadLine());
                sum += !IsEven(number) && IsPositive(number) ? number : 0;

            } while (number != 0);
            Console.WriteLine($"Sum is {sum}");
        }

        static bool IsEven(int number) => number % 2 == 0 ? true : false;

        static bool IsPositive(int number) => number > 0 ? true : false;
    }
}
