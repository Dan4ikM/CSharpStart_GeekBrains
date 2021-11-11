using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4
{
    /// <summary>
    /// 4. Реализовать метод проверки логина и пароля. 
    /// На вход метода подается логин и пароль. 
    /// На выходе истина, если прошел авторизацию, и ложь, если не прошел (Логин: root, Password: GeekBrains). 
    /// Используя метод проверки логина и пароля, написать программу: пользователь вводит логин и пароль, программа пропускает его дальше или не пропускает. 
    /// С помощью цикла do while ограничить ввод пароля тремя попытками.
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            if (Authorization())
            {
                Console.WriteLine("Start Application...");
                //Menu();
            }
            Console.WriteLine("Exit Application...");
        }

        static bool Authorization()
        {
            Console.WriteLine("Start Authorization...");
            int attempts = 3;
            do
            {
                Console.Write("Login:");
                string login = Console.ReadLine();
                Console.Write("Password:");
                string password = Console.ReadLine();
                if (IsCorrectData(login, password))
                {
                    Console.WriteLine("Authorization sucsess!");
                    return true;
                }
                else
                {
                    Console.WriteLine("Wrong login or password!");
                    Console.WriteLine("You have {0} attempts.", --attempts);
                }
            } while (attempts > 0);
            Console.WriteLine("Authorization failed!");
            return false;
        }

        static bool IsCorrectData(string login, string password)
        {
            string rightLogin = "root";
            string rightPassword = "GeekBrains";
            return rightLogin.Equals(login) && rightPassword.Equals(password);
        }
    }
}
