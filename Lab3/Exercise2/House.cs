using System;
using System.Collections.Generic;
using System.Text;

namespace Exercise2
{
    class House
    {
        protected int area;
        protected Door door;

        public House(int area)
        {
            this.area = area;
            door = new Door();
        }

        public int Area { get; set; }

        public Door Door { get; set; }

        public virtual void ShowData()
        {
            Console.WriteLine($"I am a house, my area is {area} m2");
        }
    }

    class SmallApartment:House
    {
        
        public SmallApartment() : base(50)
        {

        }

        public void Showdata()
        {
            Console.WriteLine($"I am a apartment, my are is {area} m2");
        }
    
    }
    

}
