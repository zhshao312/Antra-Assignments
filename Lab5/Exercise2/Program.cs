using System;

namespace Exercise2
{

    class A
    {
        protected int n = 1;

        public A()
        {
            n++;
            Console.WriteLine("n= " + n.ToString());
        }


    }

    class B
    {
        protected int n = 1;
        public B()
        {
            n = 10;
            Console.WriteLine("n= " + n.ToString());
        }
    }

    class Program
      
    {
        [STAThread]

        /*
         * output is 
         * n=2
         * n=10
         */
        static void Main(string[] args)
        {
            A a = new A();
            B b = new B();
        }
    }
}
