using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    /// <summary>
    /// Автор - Моисеев Даниил
    ///
    /// а) Написать программу, которая подсчитывает расстояние между точками с координатами x1, y1 и x2,y2 по формуле r=Math.Sqrt(Math.Pow(x2-x1,2)+Math.Pow(y2-y1,2). Вывести результат, используя спецификатор формата .2f (с двумя знаками после запятой);
    /// б) * Выполнить предыдущее задание, оформив вычисления расстояния между точками в виде метода.
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("We find distanse between points.\nPlease enter -\n\tx1:");
            double x1 = int.Parse(Console.ReadLine());
            Console.Write("\ty1:");
            double y1 = int.Parse(Console.ReadLine());
            Console.Write("\tx2:");
            double x2 = int.Parse(Console.ReadLine());
            Console.Write("\ty2:");
            double y2 = int.Parse(Console.ReadLine());
            double r = CalculateDistance(x1, y1, x2, y2);
            Console.WriteLine("Distanse is {0:f2}", r);
        }

        static double CalculateDistance(double x1, double y1, double x2, double y2)
            => Math.Sqrt(Math.Pow(x2 - x1, 2) + Math.Pow(y2 - y1, 2));
    }
}
