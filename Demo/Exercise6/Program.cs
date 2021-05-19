﻿using System;

namespace Exercise6
{
    class Program {
        public void DrawDiamond()
        {
            int i, j, r;

            Console.WriteLine("Display the pattern like diamond:\n");
            Console.WriteLine("-----------------------------------");

            Console.WriteLine("Input number of rows (half of the diamond) :");
            r = Convert.ToInt32(Console.ReadLine());
            for (i = 0; i <= r; i++)
            {
                for (j = 1; j <= r - i; j++)
                    Console.Write(" ");
                for (j = 1; j <= 2 * i - 1; j++)
                    Console.Write("*");
                Console.Write("\n");
            }

            for (i = r - 1; i >= 1; i--)
            {
                for (j = 1; j <= r - i; j++)
                    Console.Write(" ");
                for (j = 1; j <= 2 * i - 1; j++)
                    Console.Write("*");
                Console.Write("\n");
            }
        }
        static void Main(string[] args)
        {
            Program program = new Program();
            program.DrawDiamond();
        }
    }
}
