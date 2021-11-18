using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    /// <summary>
    /// 1. Дан целочисленный массив из 20 элементов. 
    /// Элементы массива могут принимать целые значения от –10 000 до 10 000 включительно. 
    /// Заполнить случайными числами. 
    /// Написать программу, позволяющую найти и вывести количество пар элементов массива, в которых только одно число делится на 3. 
    /// В данной задаче под парой подразумевается два подряд идущих элемента массива.
    /// Например, для массива из пяти элементов: 6; 2; 9; –3; 6 ответ — 2.
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            //generate start array
            int[] arr = new int[20];

            arr = GenerateElements(arr);

            //program start here
            int count = CountPairXORModThree(arr);

            Console.WriteLine(count);

            Console.ReadKey();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="arr"></param>
        /// <returns>Количество пар элементов массива, в которых только одно число делится на 3. 
        /// Под парой подразумевается два подряд идущих элемента массива.</returns>
        private static int CountPairXORModThree(int[] arr)
        {
            int count = 0;
            for (int i = 0; i < arr.Length - 1; i++)
            {
                if (arr[i] % 3 == 0 ^ arr[i + 1] % 3 == 0)
                {
                    count++;
                }

                Console.WriteLine("{0} {1} {2}", arr[i] % 3 == 0, arr[i + 1] % 3 == 0, count);
            }

            return count;
        }

        private static int[] GenerateElements(int[] arr)
        {
            Random rand = new Random();

            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = rand.Next(-10, 11);
            }
            return arr;
        }

        public static void PrintArray(int[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write(arr[i] + "\t");
            }
            Console.WriteLine();
        }
    }
}
