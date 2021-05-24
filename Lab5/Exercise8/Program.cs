using System;

namespace Exercise8
{
    /*
     * Error at x = n
     * There is no type of n as operator.
     */
    class A
    {
        int x;

        public abstract void f(int n);
        private virtual void g(unsigned n)
        {
            x = n as int;
        }

        public string ToString()
        {
            return x.ToString();
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}
