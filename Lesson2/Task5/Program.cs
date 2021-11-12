using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task5
{
    /*
     * а) Написать программу, которая запрашивает массу и рост человека, вычисляет его индекс массы и сообщает, 
     * нужно ли человеку похудеть, набрать вес или всё в норме.
     * б) *Рассчитать, на сколько кг похудеть или сколько кг набрать для нормализации веса.
     */
    public class Program
    {
        public static void Main(string[] args)
        {
            //Enter data
            float height;
            float weight;
            Console.WriteLine("This program shows your BMI.\nPlease enter your:");
            Console.Write("\tHeight(m)-");
            height = float.Parse(Console.ReadLine());
            Console.Write("\tWeight(kg)-");
            weight = float.Parse(Console.ReadLine());
            //Calculate BMI
            float BMI = CalculateBMI(height, weight);
            //BMI assessment
            TypeBMI typeBMI = AssessmentBMI(BMI);
            //BMI Recommendations
            RecommendationsBMI(height, weight, typeBMI);
        }

        private static void RecommendationsBMI(float height, float weight, TypeBMI typeBMI)
        {
            if (typeBMI == TypeBMI.SevereThinness || typeBMI == TypeBMI.MildThinness || typeBMI == TypeBMI.ModerateThinness)
            {
                float needBMI = 18.5f;
                float needWeight = needBMI * (height * height);
                Console.WriteLine("You need to gain {0:f2} kg of weight", needWeight - weight);
            }
            else if(typeBMI == TypeBMI.Overweigth || typeBMI == TypeBMI.ObeseClass1 
                || typeBMI == TypeBMI.ObeseClass2 || typeBMI == TypeBMI.ObeseClass3)
            {
                float needBMI = 25f;
                float needWeight = needBMI * (height * height);
                Console.WriteLine("You need to lose {0:f2} kg of weight", weight - needWeight);
            }
        }

        enum TypeBMI {SevereThinness, ModerateThinness, MildThinness, NormalRage,Overweigth,ObeseClass1,ObeseClass2,ObeseClass3,IncorrectData}
        private static TypeBMI AssessmentBMI(float BMI)
        {
            TypeBMI typeBMI = TypeBMI.IncorrectData;
            if (10 <= BMI && BMI < 16.0f)
                typeBMI = TypeBMI.SevereThinness;
            else if(16.0f <= BMI && BMI <17.0f)
                typeBMI = TypeBMI.ModerateThinness;
            else if (17.0f <= BMI && BMI < 18.5f) 
                typeBMI = TypeBMI.MildThinness;
            else if (18.5f <= BMI && BMI < 25.0f)
                typeBMI = TypeBMI.NormalRage;
            else if (25.0f <= BMI && BMI < 30.0f)
                typeBMI = TypeBMI.Overweigth;
            else if (30.0f <= BMI && BMI < 35.0f)
                typeBMI = TypeBMI.ObeseClass1;
            else if (35.0f <= BMI && BMI < 40.0f)
                typeBMI = TypeBMI.ObeseClass2;
            else if (40.0f <= BMI && BMI < 60.0f)
                typeBMI = TypeBMI.ObeseClass3;

            switch (typeBMI)
            {
                case TypeBMI.SevereThinness:
                    Console.WriteLine("You have a severe thinness, you need to gain weight urgently or consult a doctor!");
                    break;
                case TypeBMI.ModerateThinness:
                    Console.WriteLine("You have moderate thinness, you should gain weight and, just in case, consult a doctor.");
                    break;
                case TypeBMI.MildThinness:
                    Console.WriteLine("You have a mild thinness, you can gain some weight");
                    break;
                case TypeBMI.NormalRage:
                    Console.WriteLine("You in normal rage, keep up the good work!");
                    break;
                case TypeBMI.Overweigth:
                    Console.WriteLine("You are overweight, you should exercise a little more and lose a little weight.");
                    break;
                case TypeBMI.ObeseClass1:
                    Console.WriteLine("You are class 1 obesity, you need to consult a doctor and most likely play sports.");
                    break;
                case TypeBMI.ObeseClass2:
                    Console.WriteLine("You have class 3 obesity, you need to lose weight faster, see your doctor!");
                    break;
                case TypeBMI.ObeseClass3:
                    Console.WriteLine("You have class 3 obesity, you urgently need to lose weight, see your doctor!");
                    break;
                default:
                    Console.WriteLine("Incorrect data.\nPlease enter correct data.");
                    break;
            }
            return typeBMI;
        }

        static float CalculateBMI(float height, float weight)
        {
            float BMI = weight / (height * height);
            Console.WriteLine("\tYour BMI is: {0}", BMI);
            return BMI;
        }
    }
}
