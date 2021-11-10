using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    /// <summary>
    /// Автор - Моисеев Даниил
    ///
    /// Ввести вес и рост человека. Рассчитать и вывести индекс массы тела (ИМТ) по формуле I=m/(h*h); где m — масса тела в килограммах, h — рост в метрах.
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            float height;
            float weight;
            Console.Write("This program shows your BMI.\nPlease enter your:");
            Console.Write("\tHeight(m)-");
            height = int.Parse(Console.ReadLine());
            Console.Write("\tWeight(kg)-");
            weight = int.Parse(Console.ReadLine());
            float BMI = weight / (height * height);
            Console.WriteLine("Your BMI is: {0}", BMI);
        }
    }
}
