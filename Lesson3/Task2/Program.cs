using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    /// <summary>
    /// 2.
    /// а) С клавиатуры вводятся числа, пока не будет введён 0 (каждое число в новой строке).
    /// Требуется подсчитать сумму всех нечётных положительных чисел.
    /// Сами числа и сумму вывести на экран, используя tryParse.
    /// </summary>
    class Program
    {   
        public static void Main(string[] args)
        {
            Console.WriteLine("Program calculate the sum of all odd positive numbers.\nEnter numbers, when need to stop enter zero:");
            int number = 0;
            int sum = 0;
            bool correctInput;
            do
            {
                correctInput = int.TryParse(Console.ReadLine(),out number);
                if (correctInput)
                {
                    sum += !IsEven(number) && IsPositive(number) ? number : 0;
                }
                else
                {
                    Console.WriteLine("Incorrect input!");
                }
            } while (number != 0 || !correctInput);
            Console.WriteLine($"Sum is {sum}");
        }

        static bool IsEven(int number) => number % 2 == 0 ? true : false;

        static bool IsPositive(int number) => number > 0 ? true : false;
        
    }
}
