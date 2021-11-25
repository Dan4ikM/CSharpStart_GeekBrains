using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4
{
    /// <summary>
    /// 4. Решить задачу с логинами из урока 2, только логины и пароли считать из файла в массив. 
    /// Создайте структуру Account, содержащую Login и Password.
    /// 
    /// Метод считать логины пароли в массив
    /// Метод проверки в массиве
    /// </summary>
    class Program
    {
        public static void Main(string[] args)
        {
            if (Account.Authorization())
            {
                Console.WriteLine("Start Application...");
                //Menu();
            }
            Console.WriteLine("Exit Application...");
        }

        static bool IsCorrectData(string login, string password)
        {
            string rightLogin = "root";
            string rightPassword = "GeekBrains";
            return rightLogin.Equals(login) && rightPassword.Equals(password);
        }
    }
    struct Account
    {
        #region Fields
        private string login;
        private string password;

        private static List<Account> accounts;
        #endregion
        public Account(string login, string password)
        {
            this.login = login;
            this.password = password;
        }
        private static bool GetAccountsFromFile()
        {
            string fileName = AppDomain.CurrentDomain.BaseDirectory + "UsersData.txt";
            accounts = new List<Account>();
            if (File.Exists(fileName))
            {
                StreamReader reader = new StreamReader(fileName);

                while (!reader.EndOfStream)
                {
                    string login = reader.ReadLine();
                    if (reader.EndOfStream)
                    {
                        Console.WriteLine("We have login without password in file...");
                        break;
                    }
                    string password = reader.ReadLine();
                    accounts.Add(new Account(login, password));
                }
                if (accounts.Count == 0)
                {
                    Console.WriteLine("File haven't data!");
                    return false;
                }
                else 
                    return true;
            }
            else
            {
                Console.WriteLine("Can't find file with users data!");
                return false;
            }
        }
        private static bool IsCorrectData(string login, string password)
        {
            foreach (Account account in accounts)
            {
                if(account.login == login && account.password == password)
                {
                    Console.WriteLine("Authorization sucsess!");
                    return true;
                }
            }
            return false;
        }
        public static bool Authorization()
        {
            if (accounts == null || accounts?.Count == 0)
            {
                if (!GetAccountsFromFile())
                    return false;
            }

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
    }
}
