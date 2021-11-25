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

            string[] words = Message.DeleteAllWordEndsWithChar(message, 'м');

            foreach (string word in words)
            {
                Console.WriteLine(word);
            }

            Console.WriteLine(Message.FindLongestWord(message));

            Console.WriteLine(Message.NewStringWithLongestWords(message));
        }
    }

    class Message
    {
        private static string[] separators = { ",", ".", "!", "?", ";", ":", " " };

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

        public static string[] DeleteAllWordEndsWithChar(string message, char c)
        {
            string[] words = message.Split(separators, StringSplitOptions.RemoveEmptyEntries);
            List<string> remainingWords = new List<string>();
            foreach (string word in words)
            {
                if (word[word.Length-1] != c)
                {
                    remainingWords.Add(word);
                }
            }
            return remainingWords.ToArray();
        }
        /// <summary>
        /// Находит первое самое длинное слово
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public static string FindLongestWord(string message)
        {
            string[] words = message.Split(separators, StringSplitOptions.RemoveEmptyEntries);
            string longestWord = "";
            foreach (string word in words)
            {
                if (word.Length > longestWord.Length)
                    longestWord = word;
            }
            return longestWord;
        }

        public static string NewStringWithLongestWords(string message)
        {
            List<string> longestWords = FindAllLongestWords(message);

            StringBuilder longestWordsString = new StringBuilder();

            foreach (string word in longestWords)
            {
                longestWordsString.Append(word + " ");
            }

            return longestWordsString.ToString();
        }

        public static List<string> FindAllLongestWords(string message)
        {
            string[] words = message.Split(separators, StringSplitOptions.RemoveEmptyEntries);
            List<string> longestWords = new List<string>();
            int maxWordLength = 0;
            foreach (string word in words)
            {
                if (maxWordLength < word.Length)
                {
                    maxWordLength = word.Length;
                    longestWords.Clear();
                    longestWords.Add(word);
                }
                else if (maxWordLength == word.Length)
                {
                    longestWords.Add(word);
                }
            }

            return longestWords;
        }
    }
}
