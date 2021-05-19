using System;

namespace Exercise4
{
    class Program
    {
        static void Main(string[] args)
        {
            Spiral s = new Spiral();
            int[,] matrix = new int[,] { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 } };
            s.PrintSpiral(matrix, 3, 3); 
        }
    }
}
