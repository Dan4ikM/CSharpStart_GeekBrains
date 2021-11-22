using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTwoDimensionalArrayDLL
{
    public class MyTwoDimensionalArray
    {
        private int[,] arr;

        public int Min
        {
            get
            {
                int min = int.MaxValue;
                foreach (int i in arr)
                {
                    if (i < min)
                        min = i;
                }
                return min;
            }
        }

        public int Max
        {
            get
            {
                int max = int.MinValue;
                foreach (int i in arr)
                {
                    if (i < max)
                        max = i;
                }
                return max;
            }
        }

        public MyTwoDimensionalArray(int n, int m, int minRange = int.MinValue, int maxRange = int.MaxValue)
        {
            arr = new int[n, m];
            SetRandomValues(minRange, maxRange);
        }

        public MyTwoDimensionalArray(string fileName)
        {
            try
            {
                LoadFromFile(fileName);
            }
            catch (FileLoadException)
            {
                Console.WriteLine("Can't find file!");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void WriteInFile(string fileName)
        {
            fileName = AppDomain.CurrentDomain.BaseDirectory + fileName;

            string text = arr.GetLength(0).ToString() + "\n" + arr.GetLength(1).ToString() + "\n";
            foreach (int i in arr)
            {
                text += i.ToString() + "\n";
            }
            File.WriteAllText(fileName, text);
        }

        private void LoadFromFile(string fileName)
        {
            if (!File.Exists(fileName))
                throw new FileLoadException();

            StreamReader reader = new StreamReader(fileName);

            if (int.TryParse(reader.ReadLine(), out int n) && int.TryParse(reader.ReadLine(), out int m))
            {
                int[,] buffer = new int[n, m];
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < m; j++)
                    {
                        if (reader.EndOfStream)
                            throw new Exception("Unexpected end of file");
                        else
                        {
                            if (int.TryParse(reader.ReadLine(), out int number))
                                buffer[i, j] = number;
                            else
                                throw new Exception("Incorrect array data");
                        }
                    }
                }
            }
            else
            {
                throw new Exception("Incorrect length data!");
            }

        }

        private void SetRandomValues(int minRange, int maxRange)
        {
            Random rand = new Random();
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    arr[i, j] = rand.Next(minRange, maxRange);
                }
            }
        }

        public int SumAllElements()
        {
            int sum = 0;
            foreach (int i in arr)
            {
                sum += i;
            }
            return sum;
        }

        public int SumGreaterElements(int minValue)
        {
            int sum = 0;
            foreach (int i in arr)
            {
                if (i > minValue)
                    sum += i;
            }
            return sum;
        }

        public void IndexMaxValue(out int n, out int m)
        {
            if (arr.Length == 0)
            {
                Console.WriteLine("Array is empty!");
                n = -1;
                m = -1;
            }

            n = 0;
            m = 0;
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    if (arr[i, j] > arr[n, m])
                    {
                        n = i;
                        m = j;
                    }
                }
            }
        }
    }
}
