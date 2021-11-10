using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task5
{
    /// <summary>
    ///  Автор - Моисеев Даниил
    ///
    /// а) Написать программу, которая выводит на экран ваше имя, фамилию и город проживания.
    /// б) Сделать задание, только вывод организовать в центре экрана.
    /// в) * Сделать задание б с использованием собственных методов(например, Print(string ms, int x, int y).
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            string firstName;
            string lastName;
            string cityName;

            Console.Write("First Name:");
            firstName = Console.ReadLine();
            Console.Write("Last Name:");
            lastName = Console.ReadLine();
            Console.Write("City:");
            cityName = Console.ReadLine();
            Console.Clear();

            string text = $"{firstName} {lastName} lives in {cityName}";
            int pointX = CenterXCordinatText(text);
            int pointY = Console.WindowHeight / 2 - 1;
            Print(text,pointX,pointY);

            Console.SetCursorPosition(0, Console.WindowHeight);
        }

        static void Print(string message, int x, int y)
        {
            Console.SetCursorPosition(x, y);
            Console.WriteLine(message);
        }

        static int CenterXCordinatText(string text)
            => (Console.WindowWidth / 2) - (text.Length / 2);
    }
}
