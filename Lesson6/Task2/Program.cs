using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    /// <summary>
    /// 2. Модифицировать программу нахождения минимума функции так, чтобы можно было передавать функцию в виде делегата.
    /// а) Сделать меню с различными функциями и представить пользователю выбор, для какой функции и на каком отрезке находить минимум.
    /// Использовать массив(или список) делегатов, в котором хранятся различные функции.
    /// 
    /// б) * Переделать функцию Load, чтобы она возвращала массив считанных значений.
    /// Пусть она возвращает минимум через параметр(с использованием модификатора out).
    /// </summary>
    class Program
    {
        static public Fun[] functionsArr =
        {
            (x) => Math.Cos(x),
            (x) => x* x + 3*x + 8,
            (x) => 3*x* x*x + 5*x* x - 7,
            (x) => -x + 2,
            (x) => 1/x
        };

        private static double F(double x)
        {
            return x * x - 50 * x + 10;
        }

        public delegate double Fun(double x);
        public static void SaveFunc(string fileName, Fun F, double a, double b, double h)
        {
            FileStream fs = new FileStream(fileName, FileMode.Create, FileAccess.Write);
            BinaryWriter bw = new BinaryWriter(fs);
            double x = a;
            while (x <= b)
            {
                bw.Write(F(x));
                x += h;// x=x+h;
            }
            bw.Close();
            fs.Close();
        }
        public static double Load(string fileName)
        {
            FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read);
            BinaryReader bw = new BinaryReader(fs);
            double min = double.MaxValue;
            double d;
            for (int i = 0; i < fs.Length / sizeof(double); i++)
            {
                // Считываем значение и переходим к следующему
                d = bw.ReadDouble();
                if (d < min) min = d;
            }
            bw.Close();
            fs.Close();
            return min;
        }
        static void Main(string[] args)
        {
            while (true)
            {
                Fun UsingFunction = ChoseFunction();
                if (UsingFunction == null)
                {
                    Console.WriteLine("Exit...");
                    return;
                }


                Console.Write("Enter min x:");
                int xMin = EnterNumber();
                Console.Write("Enter max x:");
                int xMax = EnterNumber();

                SaveFunc("data.bin", UsingFunction, xMin, xMax, 0.5);
                Console.WriteLine(Load("data.bin"));

                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
            }
        }

        

        public static int EnterNumber()
        {
            do
            {
                Console.Write("Enter number:");
                bool flag = int.TryParse(Console.ReadLine(), out int number);
                if (flag)
                {
                    return number;
                }
                else
                {
                    Console.WriteLine("Incorrect input!");
                }
            } while (true);
        }

        public static Fun ChoseFunction()
        {
            do
            {
                PrintMenu();
                int funcNum = EnterNumber();
                switch (funcNum)
                {
                    case (0):
                        return null;
                    default:
                        if (funcNum > 0 && functionsArr.Length >= funcNum)
                            return functionsArr[funcNum - 1];
                        else
                            Console.WriteLine("Enter another number");
                        break;
                }

            } while (true);
        }

        static void PrintMenu()
        {
            Console.WriteLine("Functions");
            Console.WriteLine("1)3*Cos(x) - 1");
            Console.WriteLine("2)x ^ 2 + 3 * x + 8");
            Console.WriteLine("3)3x^3 + 5x^2 - 7");
            Console.WriteLine("4)-x +2");
            Console.WriteLine("5)1/x");
            Console.WriteLine("0)Exit");
        }
    }
}
