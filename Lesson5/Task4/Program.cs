using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4
{
    /// <summary>
    /// 4. *Задача ЕГЭ.
    /// На вход программе подаются сведения о сдаче экзаменов учениками 9-х классов некоторой средней школы.
    /// В первой строке сообщается количество учеников N, которое не меньше 10, но не превосходит 100, каждая из следующих N строк имеет следующий формат:
    /// <Фамилия> <Имя> <оценки>,
    /// где<Фамилия> — строка, состоящая не более чем из 20 символов,
    /// <Имя> — строка, состоящая не более чем из 15 символов, 
    /// <оценки> — через пробел три целых числа, соответствующие оценкам по пятибалльной системе. 
    /// <Фамилия> и<Имя>, а также<Имя> и<оценки> разделены одним пробелом. Пример входной строки:
    /// Иванов Петр 4 5 3
    /// Требуется написать как можно более эффективную программу, которая будет выводить на экран фамилии и имена трёх худших по среднему баллу учеников. 
    /// Если среди остальных есть ученики, набравшие тот же средний балл, что и один из трёх худших, следует вывести и их фамилии и имена.
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            short count = short.Parse(Console.ReadLine());
            StringBuilder[,] students = new StringBuilder[count, 2];

            List<short>[] markSumIds = new List<short>[16];
            for (short i = 0; i < count; i++)
            {
                string[] lineArray = Console.ReadLine().Split(' ');
                students[i, 0] = new StringBuilder(lineArray[0],20);
                students[i, 1] = new StringBuilder(lineArray[1], 15);

                short marksSum = 0;
                for (short j = 2; j < lineArray.Length; j++)
                {
                    marksSum += short.Parse(lineArray[j]);
                }
                if (markSumIds[marksSum] == null)
                    markSumIds[marksSum] = new List<short>();

                markSumIds[marksSum].Add(i);
            }

            int printCount = 0;
            for (int i = 0; i < markSumIds.Length; i++)
            {
                if (markSumIds[i] != null)
                {
                    //На всякий случай добавил
                    Console.WriteLine("Average mark:" + (float)i/3);
                    foreach (short id in markSumIds[i])
                    {
                        Console.WriteLine(students[id, 0] + " " + students[id, 1]);
                        printCount++;
                    }
                    if (printCount > 3)
                        break;
                }
            }
        }
    }
}
