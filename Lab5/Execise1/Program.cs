using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Execise1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter a number=> ");
            int a = Convert.ToInt32(Console.ReadLine());
            if(a>0 && a <= 10)
            {
                for (int i = 0; i < 6; i++)
                {
                    a = a << 1;
                    Console.WriteLine("{0}", a);

                }
            }
            Console.ReadKey();
        }
    }
}
