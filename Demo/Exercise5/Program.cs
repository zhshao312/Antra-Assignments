using System;

namespace Exercise5
{
    class BinaryTriangle
    {
        int num;

        public void DrawTriangle()
        {
            Console.WriteLine("Enter the number of Rows: ");
            num = Convert.ToInt32(Console.ReadLine());

            for(int i=1; i <= num; i++)
            {
                for(int j=1; j<=i; j++)
                {
                    if (j == 1 || j == i)
                    {
                        Console.Write(1);
                    }
                    else
                    {
                        Console.Write(0);
                    }
                }
                Console.WriteLine();

            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            BinaryTriangle bt = new BinaryTriangle();
            bt.DrawTriangle();
            Console.ReadKey();
        }
    }
}
