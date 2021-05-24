
using System;

namespace Exercise2
{
    class Program
    {
        static void Main(string[] args)
        {
           bool debug = true;

            SmallApartment mySmallApartment = new SmallApartment();
            Person myPerson = new Person();

            myPerson.Name = "Kishore";
            myPerson.House = mySmallApartment;
            myPerson.ShowData();

            if (debug)
            {
                Console.ReadLine();
            }
        }
    }
}
