using System;
using System.Collections.Generic;
using System.Text;

namespace Exercise5
{
    class Box
    {
        double length, breadth, height;

        public double GetVolumn()
        {
            return length * breadth * height;
        }

        public void SetLength(double len)
        {
            length = len;
        }

        public void SetBreadth(double bre)
        {
            breadth = bre;
        }

        public void SetHeight(double hei)
        {
            height = hei;
        }
    }
}
