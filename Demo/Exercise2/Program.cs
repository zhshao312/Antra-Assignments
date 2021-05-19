using System;

namespace Exercise2
{
    class Arithmetic
    {
        int a, b;
        
        public void Addition()
        {
            Console.WriteLine("Please enter 1st number: ");
            a = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Please enter 2nd number: ");
            b = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Your Addition result is: " + (a + b));
        }

        public void Subtraction()
        {
            Console.WriteLine("Please enter 1st number: ");
            a = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Please enter 2nd number: ");
            b = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Your Subtraction result is: " + (a - b));
        }

        public void Multiplication()
        {
            Console.WriteLine("Please enter 1st number: ");
            a = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Please enter 2nd number: ");
            b = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Your Multiplication result is: " + (a * b));
        }

        public void Division()
        {
            Console.WriteLine("Please enter 1st number: ");
            a = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Please enter 2nd number: ");
            b = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Your Division result is: " + (a / b));
        }
    }
    class ProgramS
    {
        static void Main(string[] args)
        {
            Arithmetic a1 = new Arithmetic();
            a1.Addition();
            a1.Subtraction();
            a1.Multiplication();
            a1.Division();
            Console.ReadKey();

        }
    }
}
