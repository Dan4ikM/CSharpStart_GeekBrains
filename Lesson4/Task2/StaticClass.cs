using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    static class StaticClass
    {
        public static void TaskFromFile(string fileName)
        {
            TaskFromArray(GetArrayFromFile(fileName));
            //arr = GenerateElements(arr);
        }

        public static void TaskFromArray(int[] arr)
        {
            int count = CountPairXORModThree(arr);

            Console.WriteLine(count);

            Console.ReadKey();
        }

        private static int CountPairXORModThree(int[] arr)
        {
            int count = 0;
            for (int i = 0; i < arr.Length - 1; i++)
            {
                if (arr[i] % 3 == 0 ^ arr[i + 1] % 3 == 0)
                {
                    count++;
                }

                //Console.WriteLine("{0} {1} {2}", arr[i] % 3 == 0, arr[i + 1] % 3 == 0, count);
            }

            return count;
        }

        private static void PrintArray(int[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write(arr[i] + "\t");
            }
            Console.WriteLine();
        }

        public static string CheckExistOrGetFileName(string fileName)
        {
            while (true)
            {
                if (File.Exists(fileName))
                {
                    return fileName;
                }
                else
                {
                    Console.Write($"File {fileName} not exist!\nEnter exist file name:");
                    fileName = Console.ReadLine();
                }
            }
        }

        private static int[] GetArrayFromFile(string fileName)
        {
            fileName = CheckExistOrGetFileName(fileName);

            StreamReader reader = new StreamReader(fileName);

            int[] arr = new int[1000];
            int counter = 0;

            while (!reader.EndOfStream)
            {
                int number = int.Parse(reader.ReadLine());
                arr[counter] = number;
                counter++;
            }

            int[] buf = new int[counter];

            Array.Copy(arr, buf, counter);

            reader.Close();

            return buf;
        }
    }
}
