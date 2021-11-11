using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task1;
using Task2;
using Task3;

namespace Task
{
    /// <summary>
    /// Автор - Моисеев Даниил
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            int taskNumber;
            do
            {
                Console.WriteLine("Complited tasks for lesson 2");
                Console.WriteLine("1)Task1");
                Console.WriteLine("2)Task2");
                Console.WriteLine("3)Task3");
                Console.WriteLine("4)Task4");
                Console.WriteLine("5)Task5");
                Console.WriteLine("6)Task6");
                Console.WriteLine("7)Task7");
                Console.Write("Enter task number or 0 to exit:");
                taskNumber = int.Parse(Console.ReadLine());
                if(taskNumber != 0)
                    StartTask(taskNumber);

                Console.WriteLine("\nPress any key to continue...");
                Console.ReadKey();
                Console.Clear();
            } while (taskNumber != 0);
        }

        static void StartTask(int taskNumber)
        {
            switch (taskNumber)
            {
                case (1):
                    Task1.Program.Main(new string[0]);
                    break;
                case (2):
                    Task2.Program.Main(new string[0]);
                    break;
                case (3):
                    Task3.Program.Main(new string[0]);
                    break;
                case (4):
                    Task4.Program.Main(new string[0]);
                    break;
                case (5):
                    Task5.Program.Main(new string[0]);
                    break;
                case (6):
                    Task6.Program.Main(new string[0]);
                    break;
                case (7):
                    Task7.Program.Main(new string[0]);
                    break;
                default:
                    Console.WriteLine("Invaild input");
                    break;
            }
        }
    }
}
