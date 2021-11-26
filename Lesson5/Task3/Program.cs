using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    /// <summary>
    /// 3. *Для двух строк написать метод, определяющий, является ли одна строка перестановкой другой.
    /// Например: badc являются перестановкой abcd.
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            string s1 = "badc";
            string s2 = "badc";

            if(CheckSameSetChars(s1, s2))
            {
                Console.WriteLine($"Строка {s1}  является перестановкой строки {s2}");
            }
            else
            {
                Console.WriteLine("Одна строка не является перестановкой другой");
            }
        }

        public static bool CheckSameSetChars(string s1, string s2)
        {
            if(s1.CompareTo(s2) == 0)
            {
                //Подумал если они изначально одинаковые, то это частный случай, который нам не подходит
                Console.WriteLine("Обе строки одинаковые!");
                return false;
            }

            List<char> cS1 = s1.ToCharArray().ToList();
            List<char> cS2 = s2.ToCharArray().ToList();
            cS1.Sort();
            cS2.Sort();

            string sortS1 = new string(cS1.ToArray());
            string sortS2 = new string(cS2.ToArray());

            return string.Compare(sortS1, sortS2) == 1 ? false : true;
        }
    }
}
