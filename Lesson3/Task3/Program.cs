using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    /// <summary>
    /// 3. *Описать класс дробей — рациональных чисел, являющихся отношением двух целых чисел. 
    /// Предусмотреть методы сложения, вычитания, умножения и деления дробей. Написать программу, демонстрирующую все разработанные элементы класса.
    /// Добавить свойства типа int для доступа к числителю и знаменателю; +
    /// Добавить свойство типа double только на чтение, чтобы получить десятичную дробь числа; +
    /// ** Добавить проверку, чтобы знаменатель не равнялся 0. Выбрасывать исключение ArgumentException("Знаменатель не может быть равен 0"); 
    /// *** Добавить упрощение дробей.
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            do
            {
                Console.WriteLine("This program performs simple operations on fractions.");

                char operationSymbol = GetOperationSymbol();

                if (operationSymbol == '0') break;

                Console.WriteLine("Please enter first fraction");
                Fraction fraction1 = Fraction.ConsoleEnter();

                Console.WriteLine("Please enter second fraction");
                Fraction fraction2 = Fraction.ConsoleEnter();

                Fraction fraction3 = Calculate(operationSymbol, fraction1, fraction2);

                Console.WriteLine($"{fraction1} {operationSymbol} {fraction2} = {fraction3} or {fraction3.Decimal}");

                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
                Console.Clear();
            } while (true);
        }

        private static Fraction Calculate(char operationSymbol, Fraction fraction1, Fraction fraction2)
        {
            Fraction fraction3 = new Fraction(0,1);

            switch (operationSymbol)
            {
                case ('+'):
                    fraction3 = fraction1 + fraction2;
                    break;
                case ('-'):
                    fraction3 = fraction1 - fraction2;
                    break;
                case ('*'):
                    fraction3 = fraction1 * fraction2;
                    break;
                case ('/'):
                    fraction3 = fraction1 / fraction2;
                    break;
                default:
                    Console.WriteLine("Invalid operation!");
                    break;
            }

            return fraction3;
        }

        private static char GetOperationSymbol()
        {
            char operationSymbol;
            do
            {
                Console.Write("Please enter operation(+,-,*,/) for calculation or 0 to exit:");

                char.TryParse(Console.ReadLine(), out operationSymbol);
                if (operationSymbol == '+' || operationSymbol == '-' || operationSymbol == '*' || operationSymbol == '/' || operationSymbol == '0')
                {
                    return operationSymbol;
                }
                else
                {
                    Console.WriteLine("Incorrect input!");
                }
            }
            while (true);
        }

    }
}
