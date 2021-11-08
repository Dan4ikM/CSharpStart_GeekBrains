using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task6
{
    class Profile
    {
        public string FisrtName { get; private set; }
        public string LastName { get; private set; }
        public int Age { get; private set; }
        public float Height { get; private set; }
        public float Weight { get; private set; }
        public string City { get; private set; }

        public override string ToString()
        {
            return $"{LastName} {FisrtName} - {Age} age, {Height}(m) height and {Weight}(kg) weight. Lives in {City}";
        }

        public void FillData()
        {
            Console.WriteLine("Enter profile data:");

            Console.Write("\tFirst Name:");
            FisrtName = Console.ReadLine();

            Console.Write("\tLast Name:");
            LastName = Console.ReadLine();

            Console.Write("\tAge:");
            Age = int.Parse(Console.ReadLine());

            Console.Write("\tHeight(m):");
            Height = float.Parse(Console.ReadLine());

            Console.Write("\tWeight(kg):");
            Weight = float.Parse(Console.ReadLine());

            Console.Write("\tCity:");
            City = Console.ReadLine();
        }
    }
}
