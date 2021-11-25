using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4
{
    class MyArray
    {
        #region Fields

        private int[] arr;

        #endregion

        #region Constructors

        /// <summary>
        /// Инициализация массива через параметр
        /// </summary>
        /// <param name="arr">Внешний массив</param>
        public MyArray(int[] arr)
        {
            this.arr = arr;
        }

        /// <summary>
        /// Загрузить массив из файла
        /// </summary>
        /// <param name="fileName">Наименование файла</param>
        public MyArray(string fileName)
        {
            arr = LoadArrayFromFile(fileName);
        }
        //Реализовать конструктор, создающий массив определенного размера и заполняющий массив числами от начального значения с заданным шагом.
        /// <summary>
        /// Инициализация массива выбранного размера с арифметической прогрессией
        /// </summary>
        /// <param name="n">Размер массива</param>
        /// <param name="startValue">Значение первого элемента</param>
        /// <param name="step">Значение арифметической прогрессии</param>
        public MyArray(int n, int startValue, int step)
        {
            arr = new int[n];
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = startValue + i * step;
            }
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Обратиться к элементу массива по индексу
        /// </summary>
        /// <param name="index">Индекс элемента массива</param>
        /// <returns></returns>
        public int this[int index]
        {
            get
            {
                return arr[index];
            }

            set
            {
                arr[index] = value;
            }
        }
        // Создать свойство Sum, которое возвращает сумму элементов массива
        /// <summary>
        /// Возвращает сумму элементов массива
        /// </summary>
        public int Sum
        {
            get
            {
                int sum = 0;
                foreach (int i in arr)
                {
                    sum += i;
                }
                return sum;
            }
        }

        // свойство MaxCount, возвращающее количество максимальных элементов.
        /// <summary>
        /// Возвращает количество максимальных элементов
        /// </summary>
        public int MaxCount
        {
            get
            {
                int count = 0;
                if (arr.Length == 0)
                {
                    Console.WriteLine("Array is empty!");
                }
                else
                {
                    int maxValue = arr[0];
                    count++;
                    for (int i = 1; i < arr.Length; i++)
                    {
                        if(maxValue == arr[i])
                        {
                            count++;
                        }
                        else if(maxValue < arr[i])
                        {
                            count = 1;
                            maxValue = arr[i];
                        }
                    }
                }
                return count;
            }
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Распечатать массив
        /// </summary>
        public void PrintArray()
        {
            foreach (int element in arr)
            {
                Console.Write($"{element}\t");
            }
            Console.WriteLine();
        }

        /// <summary>
        /// Вернуть элемент массива по индексу
        /// </summary>
        /// <param name="index">Индекс элемента массива</param>
        /// <returns>Элемент массива</returns>
        public int GetElement(int index)
        {
            return arr[index];
        }

        #endregion

        #region Private Methods

        private int[] LoadArrayFromFile(string fileName)
        {
            if (File.Exists(fileName))
            {
                //StreamWriter
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
            else
                throw new FileNotFoundException();
        }

        // метод Inverse, возвращающий новый массив с измененными знаками у всех элементов массива(старый массив, остается без изменений)
        /// <summary>
        /// Возвращает новый массив с измененными знаками у всех элементов массива
        /// </summary>
        /// <returns></returns>
        public MyArray Inverse()
        {
            int[] inverseArr = new int[arr.Length];
            for (int i = 0; i < arr.Length; i++)
            {
                inverseArr[i] = arr[i] * -1; 
            }
            return new MyArray(inverseArr);
        }

        // метод Multi, умножающий каждый элемент массива на определённое число,
        /// <summary>
        /// Умножает каждый элемент массива на определённое число
        /// </summary>
        /// <param name="multiplier"></param>
        public void Multi(int multiplier)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] *= multiplier;
            }
        }

        #endregion



    }
}
