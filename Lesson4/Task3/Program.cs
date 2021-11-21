using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyArrayDLL;

namespace Task3
{
    /// <summary>
    /// 3.а) Дописать класс для работы с одномерным массивом.
    /// Реализовать конструктор, создающий массив определенного размера и заполняющий массив числами от начального значения с заданным шагом.
    /// Создать свойство Sum, которое возвращает сумму элементов массива, 
    /// метод Inverse, возвращающий новый массив с измененными знаками у всех элементов массива(старый массив, остается без изменений), 
    /// метод Multi, умножающий каждый элемент массива на определённое число, 
    /// свойство MaxCount, возвращающее количество максимальных элементов.
    /// б)** Создать библиотеку содержащую класс для работы с массивом.Продемонстрировать работу библиотеки
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = { 2, 34, -1, 4, -5 };

            string fileName = AppDomain.CurrentDomain.BaseDirectory + "ArrayList.txt";
            Console.WriteLine(fileName);
            MyArray myArray = new MyArray(fileName);

            myArray.PrintArray();

            int element = myArray.GetElement(4);
            Console.WriteLine(element);

            Console.WriteLine(myArray[4]);
            myArray[4] = 10;

            MyArray inverseArray = myArray.Inverse();
            myArray.PrintArray();
            inverseArray.PrintArray();
            MyArray newArray = new MyArray(new int[0]);
            int d = newArray.MaxCount;
            Console.ReadKey();
        }
    }
}
