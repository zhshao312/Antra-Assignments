using System;

namespace Exercise3
{
    class Reverse
    {
        string text;

        public void ReverseFunction()
        {
            Console.WriteLine("Enter a string: ");
            text = Console.ReadLine();

            char[] cArray = text.ToCharArray();
            Array.Reverse(cArray);

            Console.WriteLine("String reversed: "+ new String(cArray));
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Reverse r = new Reverse();
            r.ReverseFunction();
            Console.WriteLine("Press <N> to exit...");
            while (Console.ReadKey().Key != ConsoleKey.N) ;
        }
    }
}
