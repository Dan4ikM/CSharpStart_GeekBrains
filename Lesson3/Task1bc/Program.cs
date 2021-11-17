using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1bc
{
    /// <summary>
    /// 1.а) Дописать структуру Complex, добавив метод вычитания комплексных чисел.Продемонстрировать работу структуры.
    /// б) Дописать класс Complex, добавив методы вычитания и произведения чисел.Проверить работу класса.
    /// в) Добавить диалог с использованием switch демонстрирующий работу класса.
    /// </summary>

    class Complex
    {
        #region Fields
        //real part
        private double re;
        //imaginary part
        private double im;
        #endregion

        #region Properties

        #endregion

        #region Constructors
        public Complex(double re = 0, double im = 0)
        {
            this.re = re;
            this.im = im;
        }

        #endregion

        #region Methods
        public Complex Plus(Complex complex)
        {
            return this + complex;
        }
        public Complex Minus(Complex complex)
        {
            return this - complex;
        }
        public Complex Multiply(Complex complex)
        {
            return this * complex;
        }

        public Complex Divide(Complex complex)
        {
            return this / complex;
        }

        public static Complex operator +(Complex complex1, Complex complex2)
        {
            return new Complex(complex1.re + complex2.re, complex1.im + complex2.im);
        }

        public static Complex operator -(Complex complex1, Complex complex2)
        {
            return new Complex(complex1.re - complex2.re, complex1.im - complex2.im);
        }
        public static Complex operator *(Complex complex1, Complex complex2)
        {
            return new Complex(
                complex1.re * complex2.re - complex1.im * complex2.im,
                complex1.re * complex2.im - complex1.im * complex2.re);
        }

        public static Complex operator /(Complex complex1, Complex complex2)
        {
            try
            {
                if (complex2.re == 0 && complex2.im == 0) throw new DivideByZeroException();
            }
            catch (DivideByZeroException)
            {
                Console.WriteLine($"Message: second complex number is zero!");
            }

            double re = (complex1.re * complex2.re + complex1.im * complex2.im) / (complex2.re * complex2.re + complex2.im * complex2.im);
            double im = (complex1.im * complex2.re - complex1.re * complex2.im) / (complex2.re * complex2.re + complex2.im * complex2.im);

            return new Complex(re, im);
        }

        public static Complex ConsoleEnter()
        {
            double newRe = EnterRealNumber("Re:");

            double newIm = EnterRealNumber("Im:");

            return new Complex(newRe, newIm);
        }

        private static double EnterRealNumber(string name)
        {
            do
            {
                Console.Write(name);
                bool correct = double.TryParse(Console.ReadLine(), out double realNumber);
                if (!correct)
                {
                    Console.WriteLine("Incorrect input!");
                }
                else
                    return realNumber;
            } while (true);
        }

        public override string ToString()
        {
            return $"{re} + {im}i";
        }

        public bool IsZero()
        {
            return re == 0 && im == 0;
        }
        #endregion
    }
    class Program
    {
        static void Main(string[] args)
        {
            do
            {
                Console.WriteLine("This program performs simple operations on complex numbers.");

                char operationSymbol = GetOperationSymbol();

                if (operationSymbol == '0') break;

                Console.WriteLine("Please enter first complex number");
                Complex complex1 = Complex.ConsoleEnter();

                Console.WriteLine("Please enter second complex number");
                Complex complex2 = Complex.ConsoleEnter();
                while (operationSymbol != '/' || complex2.IsZero())
                {
                    Console.WriteLine("Second complex number can't be zero!");
                    Console.WriteLine("Please enter second complex number");
                    complex2 = Complex.ConsoleEnter();
                }

                Complex complex3 = Calculate(operationSymbol, complex1, complex2);

                Console.WriteLine($"{complex1} {operationSymbol} {complex2} = {complex3}");

                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
                Console.Clear();

            } while (true);
        }

        private static Complex Calculate(char operationSymbol, Complex complex1, Complex complex2)
        {
            Complex complex3 = new Complex();

            switch (operationSymbol)
            {
                case ('+'):
                    complex3 = complex1 + complex2;
                    break;
                case ('-'):
                    complex3 = complex1 - complex2;
                    break;
                case ('*'):
                    complex3 = complex1 * complex2;
                    break;
                case ('/'):
                    complex3 = complex1 / complex2;
                    break;
                default:
                    Console.WriteLine("Invalid operation!");
                    break;
            }

            return complex3;
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
