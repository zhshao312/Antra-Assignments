using System;
using System.Collections.Generic;
using System.Text;

namespace Exercise1
{
    abstract class Shape1
    {
        protected float R, L, B;
        public abstract float Area();
        public abstract float Circumference();

        public abstract void getData();
    }

    class Rectangle:Shape1
    {
        public float length { get; set; }
        public float breadth { get; set; }

        public override void getData()
        {
            Console.Write("Enter the length of rectangle: ");
            this.length = float.Parse(Console.ReadLine());
            Console.Write("Enter the breadth of rectangle: ");
            this.breadth = float.Parse(Console.ReadLine());
        }

        public override float Area()
        {

            return length * breadth;
        }

        public override float Circumference()
        {

            return (length + breadth) * 2;
        }
    }

    class Circle : Shape1
    {
        public float radius { get; set; }

        public override void getData()
        {
            Console.Write("Enter the radius of Circle: ");
            this.radius = float.Parse(Console.ReadLine());

        }

        public override float Area()
        {

            return radius * radius * 3.14f;
        }

        public override float Circumference()
        {

            return radius * 2 * 3.14f;
        }
    }
}
