using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Task1
{
    /// <summary>
    /// ФИО - Моисеев Даниил
    /// 
    /// 1. Создать программу, которая будет проверять корректность ввода логина. 
    /// Корректным логином будет строка от 
    ///     2 до 10 символов, 
    ///     содержащая только 
    ///         буквы латинского алфавита или 
    ///         цифры, при этом цифра не может быть первой:
    /// а) без использования регулярных выражений;
    /// б) ** с использованием регулярных выражений.
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            string login = Console.ReadLine();

            if (IsCorrectLogin(login.ToCharArray()))
            {
                Console.WriteLine("Login is correct!");
            }
            else
            {
                Console.WriteLine("Login is incorrect!");
            }

            login = Console.ReadLine();

            Regex regexLogin = new Regex("^[A-Za-z]{1}[A-Za-z0-9]{1,9}$"); 
            if (regexLogin.IsMatch(login))
            {
                Console.WriteLine("Login is correct!");
            }
            else
            {
                Console.WriteLine("Login is incorrect!");
            }

        }

        static bool IsCorrectLogin(char[] login)
        {
            if (2 > login.Length || login.Length > 10) 
                return false;

            for (int i = 0; i < login.Length; i++)
            {
                if (i == 0 && IsCharNumber(login[i]))
                {
                    return false;
                }
                else if (!(IsCharNumber(login[i]) || IsCharLetter(login[i])))
                    return false;
            }
            return true;
        }

        static bool IsCharLetter(char c)
        {
           return ('A' <= c && c <= 'z') ? true : false;
        }
        static bool IsCharNumber(char c)
        {
            return ('0' <= c && c <= '9') ? true : false;
        }
    }
}
