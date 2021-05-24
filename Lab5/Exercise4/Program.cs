using System;

namespace Exercise4
{

    class A {

        static int n = 1;
        public void f()
        {
            n++;
        }

        public void Report()
        {
            Console.WriteLine(n.ToString());
        }
    }
    class Program
    {
        [STAThread]
        /*
         * output is 
         * 2
         * 3
         */
        static void Main(string[] args)
        {
            A x = new A(), y = new A();
            x.f();
            x.Report();

            y.f();
            y.Report();
        }
    }
}
