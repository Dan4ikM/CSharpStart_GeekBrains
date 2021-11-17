using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    class Fraction
    {
        #region Fields
        private int numerator;
        private int denominator;
        #endregion

        #region Properties
        public int Numerator
        {
            get { return numerator; }
            set { numerator = value; }
        }
        public int Denominator
        {
            get { return denominator; }
            set
            {
                if (value == 0)
                    throw new ArgumentException("Denominator can't be zero!");
                denominator = value;
            }
        }
        public double Decimal
        {
            get { return (double)numerator / denominator; }
        }
        #endregion

        #region Constructors
        public Fraction(int numerator, int denominator)
        {
            Numerator = numerator;
            Denominator = denominator;
        }
        public Fraction() { }
        #endregion

        #region Methods
        public override string ToString()
        {
            return $"{Numerator}/{Denominator}";
        }

        public static Fraction ConsoleEnter()
        {
            int newNumerator = EnterInteger("Numerator:");
            while (true)
            {
                try
                {
                    int newDenominator = EnterInteger("Denominator:");

                    Fraction fraction = new Fraction(newNumerator, newDenominator);
                    return TryReduce(fraction);
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.WriteLine("Retry enter again...");
                }
            }
        }

        public static Fraction TryReduce(Fraction fraction)
        {
            int nod = GCD(fraction.Numerator, fraction.Denominator);
            if(nod != 1)
            {
                fraction.Numerator /= nod;
                fraction.Denominator /= nod;
                Console.WriteLine($"Reduce fraction to {fraction}");
            }
            return new Fraction(fraction.Numerator, fraction.Denominator);
        }

        private static int GCD(int a, int b)
        {
            a = Math.Abs(a);
            b = Math.Abs(b);
            while(a != b)
                if (a > b) 
                    a = a - b; 
                else 
                    b = b - a;
            return a;
        }

        private static int LCM(int a,int b)
        {
            return Math.Abs(a * b) / GCD(a, b);
        }

        private static int EnterInteger(string name)
        {
            do
            {
                Console.Write(name);
                bool correct = int.TryParse(Console.ReadLine(), out int integer);
                if (!correct)
                {
                    Console.WriteLine("Incorrect input!");
                }
                else
                    return integer;
            } while (true);
        }

        public static Fraction operator +(Fraction fraction1, Fraction fraction2)
        {
            int denominator = LCM(fraction1.Denominator, fraction2.Denominator);
            int numerator = fraction1.Numerator*(denominator/fraction1.denominator) + fraction2.Numerator * (denominator / fraction2.denominator);
            return TryReduce(new Fraction(numerator, denominator));
        }

        public static Fraction operator -(Fraction fraction1, Fraction fraction2)
        {
            int denominator = LCM(fraction1.Denominator, fraction2.Denominator);
            int numerator = fraction1.Numerator * (denominator / fraction1.denominator) - fraction2.Numerator * (denominator / fraction2.denominator);
            return TryReduce(new Fraction(numerator, denominator));
        }

        public static Fraction operator *(Fraction fraction1, Fraction fraction2)
        {
            int denominator = fraction1.Denominator * fraction2.Denominator;
            int numerator = fraction1.Numerator * fraction2.Numerator;
            return TryReduce(new Fraction(numerator, denominator));
        }

        public static Fraction operator /(Fraction fraction1, Fraction fraction2)
        {
            int denominator = fraction1.Denominator * fraction2.Numerator;
            int numerator = fraction1.Numerator * fraction2.Denominator;
            return TryReduce(new Fraction(numerator, denominator));
        }
        #endregion
    }
}
