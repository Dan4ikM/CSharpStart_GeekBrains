using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4
{
    /// <summary>
    /// Написать программу обмена значениями двух переменных типа int без использования вспомогательных методов.
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            int a = 1;
            int b = 7;
            SwapVariables(ref a, ref b);
            Console.WriteLine($"a:{a},b:{b}");
            SwapVariablesWithoutAnAdditionalVariable(ref a, ref b);
            Console.WriteLine($"a:{a},b:{b}");
            Console.ReadLine();
        }
        #region а) с использованием третьей переменной;
        static void SwapVariables(ref int v1, ref int v2)
        {
            int t = v1;
            v1 = v2;
            v2 = t;
        }
        #endregion

        #region б) *без использования третьей переменной.
        //XOR, видел просто суммой и вычитанием, не знаю насколько тот вариант хуже
        static void SwapVariablesWithoutAnAdditionalVariable(ref int v1, ref int v2)
        {
            Console.WriteLine($"v1:{v1},v2:{v2}");
            v1 ^= v2;
            Console.WriteLine($"v1:{v1},v2:{v2}");
            v2 ^= v1;
            Console.WriteLine($"v1:{v1},v2:{v2}");
            v1 ^= v2;
        }
        #endregion
    }
}
