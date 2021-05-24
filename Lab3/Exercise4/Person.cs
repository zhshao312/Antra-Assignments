using System;
using System.Collections.Generic;
using System.Text;

namespace Exercise4
{
    class Person
    {
        public int Age { get; set; }
        
        public virtual void SetAge(int age)
        {
            this.Age = age;
        }

        public virtual void Explain()
        {

        }

        public virtual void SayHello()
        {
            Console.WriteLine("Hello");
        }

        public virtual void ShowAge()
        {
            Console.WriteLine($"My age is {Age}");
        }
    }
}
