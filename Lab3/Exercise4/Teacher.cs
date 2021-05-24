using System;
using System.Collections.Generic;
using System.Text;

namespace Exercise4
{
    class Teacher:Person
    {
        private string subject;
        public new int Age { get; set; }

        public Teacher(int age)
        {
            this.Age = age;
        }
        public override void Explain()
        {
            Console.WriteLine("Explaination Begins");
        }

        public override void SetAge(int age)
        {
            base.SetAge(age);
        }

        public override void SayHello()
        {
            base.SayHello();
        }
    }
}
