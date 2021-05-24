using System;

namespace Exercise1
{
    class Program
    {
        public static void Calculate(Shape1 S)
        {
            Console.WriteLine("Area: {0}", S.Area());
            Console.WriteLine("Circumference: {0}", S.Circumference());
        }
        static void Main(string[] args)
        {
            Shape1 rectangle = new Rectangle();
            rectangle.getData();
            Calculate(rectangle);

            Shape1 circle = new Circle();
            circle.getData();
            Calculate(circle);
        }
    }
}
