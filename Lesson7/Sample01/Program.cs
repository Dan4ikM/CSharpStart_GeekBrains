using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample01
{

    partial class Sample
    {

        public int A { get; set; }

    }

    class Program
    {
        static void Main(string[] args)
        {
            Sample sample = new Sample();
            sample.A = 1;
            sample.B = 2;
        }
    }
}
