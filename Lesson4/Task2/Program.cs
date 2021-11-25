using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    /// <summary>
    /// 2. Реализуйте задачу 1 в виде статического класса StaticClass;
    /// а) Класс должен содержать статический метод, который принимает на вход массив и решает задачу 1;
    /// б) Добавьте статический метод для считывания массива из текстового файла.Метод должен возвращать массив целых чисел;
    /// в)* Добавьте обработку ситуации отсутствия файла на диске.
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = new int[] {0,1,2 };
            //Сделал просто. Можно конечно всё обернуть через ручной ввод через консоль массива или имени файла.
            //Если времени хватит - сделаю
            //StaticClass.TaskFromArray(arr);
            string fileName = AppDomain.CurrentDomain.BaseDirectory + "ArrayList.txt";
            StaticClass.TaskFromFile(fileName);
        }
    }
}
