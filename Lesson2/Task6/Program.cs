using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task6
{
    /// <summary>
    /// 6. *Написать программу подсчета количества «хороших» чисел в диапазоне от 1 до 1 000 000 000. 
    /// «Хорошим» называется число, которое делится на сумму своих цифр. 
    /// Реализовать подсчёт времени выполнения программы, используя структуру DateTime.
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            int count = 0;
            DateTime start = DateTime.Now;
            for (int i = 1; i < Math.Pow(10,9); i++)
            {
                if(IsGoodNumber(i))
                    count++;
            }
            DateTime finish = DateTime.Now;
            Console.WriteLine($"Program works {finish - start} time");
            Console.WriteLine($"This range has {count} good numbers");
        }

        static bool IsGoodNumber(int number)
        {
            int sumDigits = SumDigitsOfNumber(number);
            return number % sumDigits == 0 ? true : false;
        }

        static int SumDigitsOfNumber(int number)
        {
            int sum = 0;
            do
            {
                sum += number % 10;
                number /= 10;
            } while (number > 0);
            return sum;
        }
    }
}
