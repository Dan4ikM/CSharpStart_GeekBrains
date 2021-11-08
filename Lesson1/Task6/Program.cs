using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task6
{
    class Program
    {
        static void Main(string[] args)
        {
            Profile newProfile = new Profile();
            newProfile.FillData();
            Console.WriteLine(newProfile.ToString()); ;
        }
    }
}
