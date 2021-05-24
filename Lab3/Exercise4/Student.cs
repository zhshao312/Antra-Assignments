using System;
using System.Collections.Generic;
using System.Text;

namespace Exercise4
{
    class Student:Person
    {
        public new int Age { get; set; }

        public Student()
        {
            
        }
        public void GoToClass()
        {
            Console.WriteLine("I'm going to class");
        }

        public override void SetAge(int age)
        {
            base.SetAge(age);
        }

        public override void SayHello()
        {
            base.SayHello();
        }
        public void ShowAge()
        {
            Console.WriteLine($"My age is {Age} years old");
        }
    }
}
