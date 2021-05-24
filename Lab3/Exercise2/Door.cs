using System;
using System.Collections.Generic;
using System.Text;

namespace Exercise2
{
    class Door
    {
        protected string color;

        public Door()
        {
            color = "brown";    
        }

        public Door(string color)
        {
            this.color = color;
        }
        public string Color { get; set; }

        public void ShowData() {

            Console.WriteLine($"I am a door, my color is {color}.");

        }


    }
}
