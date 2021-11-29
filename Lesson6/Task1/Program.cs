using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    /// <summary>
    /// 1. Изменить программу вывода таблицы функции так, чтобы можно было передавать функции типа double (double, double). 
    /// Продемонстрировать работу на функции с функцией a*x^2 и функцией a*sin(x).
    /// </summary>
    
    // Описываем делегат. В делегате описывается сигнатура методов, на
    // которые он сможет ссылаться в дальнейшем (хранить в себе)
    public delegate double Fun(double a, double x);
    class Program
    {// Создаем метод, который принимает делегат
        // На практике этот метод сможет принимать любой метод
        // с такой же сигнатурой, как у делегата
        public static void Table(Fun F, double a, double x, double b)
        {
            Console.WriteLine("----- A ----- X ----- Y -----");
            while (a <= b)
            {
                double startX = x;
                while (x <= b)
                {
                    Console.WriteLine("| {0,8:0.000} | {1,8:0.000} | {2,8:0.000} |", a, x, F(a, x));
                    x += 1;
                }
                a++;
                x = startX;
            }
            Console.WriteLine("---------------------");
        }

        static void Main()
        {
            Console.WriteLine("Таблица функции a*Sin(x):");
            Table((a,x)=>a*Math.Sin(x),-2, -2, 2);

            Console.WriteLine("Таблица функции a*x^2:");
            Table(delegate (double a, double x) { return a*x * x; }, -2, -2, 2);

        }
    }
}
