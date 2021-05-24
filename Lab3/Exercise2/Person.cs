using System;
using System.Collections.Generic;
using System.Text;

namespace Exercise2
{
    class Person
    {
        protected string name;
        protected House house;

        public Person()
        {
            name = "Juan";
            house = new House(150);

        }

        public Person(string name, House house)
        {
            this.name = name;
            this.house = house;
        }

        public string Name { get; set; }

        public House House { get; set; }

        public void ShowData()
        {
            Console.WriteLine($"My name is {name}");
            house.ShowData();
            house.Door.ShowData();
        }


    }
}
