using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    /// <summary>
    /// Автор - Моисеев Даниил
    /// 
    /// Написать программу «Анкета». Последовательно задаются вопросы (имя, фамилия, возраст, рост, вес). 
    /// В результате вся информация выводится в одну строчку:
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            string firstName;
            string lastName;
            int age;
            float height;
            float weight;
            Console.Write("Hello, stranger!\nLet's edit your profile.\nPlease enter:\n\tFirst Name:");
            firstName = Console.ReadLine();
            Console.Write("\tLast Name:");
            lastName = Console.ReadLine();
            Console.Write("\tAge:");
            age = int.Parse(Console.ReadLine());
            Console.Write("\tHeight(cm):");
            height = int.Parse(Console.ReadLine());
            Console.Write("\tWeight(kg):");
            weight = int.Parse(Console.ReadLine());

            #region а) используя склеивание;

            Console.WriteLine("Your profile - First Name:" + firstName +
                ", Last Name:" + lastName +
                ", Age:" + age +
                ", Height:" + height +
                ", Weight:" + weight);
            #endregion

            #region б) используя форматированный вывод;

            Console.WriteLine("Your profile - First Name:{0}, Last Name:{1}, Age:{2}, Height:{3}, Weight:{4}"
                , firstName, lastName, age, height, weight);

            #endregion

            #region в) используя вывод со знаком $.

            Console.WriteLine($"Your profile - First Name:{firstName}, Last Name:{lastName}, Age:{age}, Height:{height}, Weight:{weight}");

            #endregion
        }
    }
}
