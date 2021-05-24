using System;

namespace Exercise5
{
    public class Myclass
    {
        public delegate void LogHandler(string message);

        public void Process(LogHandler logHandler)
        {
            if (logHandler != null)
            {
                logHandler("begin");
            }
            if (logHandler != null)
            {
                logHandler("End");
            }
        }
    }

    public class MyLogger
    {
        public void Logger(string s)
        {
            Console.WriteLine(s);
        }
    }
    class Program
    {
        static void Logger(string s)
        {
            Console.WriteLine(s);
        }
        /*
         * output is 
         * begin
         * begin
         * End
         * End
         */
        static void Main(string[] args)
        {
            MyLogger f1 = new MyLogger();
            Myclass myclass = new Myclass();
            Myclass.LogHandler myLogger = null;
            
            myLogger += new Myclass.LogHandler(Logger);

            myLogger += new Myclass.LogHandler(f1.Logger);

            myclass.Process(myLogger);

            return;
        }
        /*
         * output is 
         * 
         * 
         * 
         */
    }
}
