using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using MyTwoDimensionalArrayDLL;

namespace Task5
{
    /// <summary>
    /// 5 а) Реализовать библиотеку с классом для работы с двумерным массивом.
    /// Реализовать конструктор, заполняющий массив случайными числами.
    /// Создать методы, которые:
    ///     возвращают сумму всех элементов массива, 
    ///     сумму всех элементов массива больше заданного,
    ///     возвращающий номер максимального элемента массива(через параметры, используя модификатор ref или out).
    /// Свойства: 
    ///     возвращающее минимальный элемент массива, 
    ///     возвращающее максимальный элемент массива,
    ///     
    /// * б) Добавить конструктор и методы, которые загружают данные из файла и записывают данные в файл.
    /// ** в) Обработать возможные исключительные ситуации при работе с файлами.
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            MyTwoDimensionalArray array = new MyTwoDimensionalArray(3, 4, -10, 10);

            array.WriteInFile("Array.txt");
        }
    }

}
