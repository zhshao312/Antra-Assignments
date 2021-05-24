using System;

namespace Exercise4
{
    class Program
    {
        static void Main(string[] args)
        {
            Person person = new Person();
            Person student = new Student();
            Person teacher = new Teacher(30);

            person.SayHello();
            student.SetAge(21);
            student.SayHello();
            student.ShowAge();
            teacher.SayHello();
            teacher.Explain();
            
        }
    }
}
