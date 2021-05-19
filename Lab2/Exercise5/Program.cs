using System;

namespace Exercise5
{
    class Program
    {
        static void Main(string[] args)
        {
            Box box1 = new Box();
            box1.SetLength(10);
            box1.SetBreadth(20);
            box1.SetHeight(30);
            Console.WriteLine($"Volumn of box1: {box1.GetVolumn()}");

            Box box2 = new Box();
            box1.SetLength(40);
            box1.SetBreadth(50);
            box1.SetHeight(60);
            Console.WriteLine($"Volumn of box2: {box1.GetVolumn()}");

            Box box3 = new Box();
            box1.SetLength(70);
            box1.SetBreadth(80);
            box1.SetHeight(90);
            Console.WriteLine($"Volumn of box3: {box1.GetVolumn()}");

        }
    }
}
