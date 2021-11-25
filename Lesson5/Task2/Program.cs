using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    /// <summary>
    /// 2. Разработать статический класс Message, содержащий следующие статические методы для обработки текста:
    /// а) Вывести только те слова сообщения, которые содержат не более n букв.
    /// б) Удалить из сообщения все слова, которые заканчиваются на заданный символ.
    /// в) Найти самое длинное слово сообщения.
    /// г) Сформировать строку с помощью StringBuilder из самых длинных слов сообщения.
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            string message = "За окном потоп, а я ем торт!";

            Message.PrintWordsLengthLess(message, 4);
        }
    }

    class Message
    {
        private static string[] separators = { ",", ".", "!", "?", ";", ":", " " };

        public static void PrintWords(string message)
        {
            string[] words = message.Split(separators, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < words.Length; i++)
            {
                //string s = words[i];
                //int l =  s.Length;

                string s = words[i];
                char firstElement = s[0];
                char lastElement = s[s.Length - 1];

                if (words[i].Length >= 3 && words[i][0] == words[i][words[i].Length - 1])
                    Console.WriteLine(words[i]);
            }

        }

        public static void PrintWordsLengthLess(string message, int lengthMax)
        {
            string[] words = message.Split(separators, StringSplitOptions.RemoveEmptyEntries);
            foreach (string word in words)
            {
                if(word.Length <= lengthMax)
                {
                    Console.WriteLine(word);
                }
            }
        }

    }
}
