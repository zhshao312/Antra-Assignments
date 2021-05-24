using System;
using System.Collections.Generic;

namespace NewLanguageFeatures
{
    public delegate bool KeyValueFilter<K, V>(K key, V value);

    public static class Extensions
    {

        public static List<T> Append<T>(this List<T> a, List<T> b)
        {
            var newList = new List<T>(a);
            newList.AddRange(b);
            return newList;
        }
        public static bool Compare(this Customer customer1, Customer customer2)
        {
            if(customer1.CustomerID == customer2.CustomerID &&
                customer1.Name == customer2.Name &&
                customer1.City == customer2.City)
            {
                return true;
            }
            return false;
        }

        public static List<K> FilterBy<K,V>(this Dictionary<K, V> items, KeyValueFilter<K, V> filter)
        {
            var result = new List<K>();
            foreach(KeyValuePair<K,V> element in items)
            {
                if (filter(element.Key, element.Value))
                    result.Add(element.Key);
            }
            return result;
        }



    }
    public class Customer {

        public int CustomerID { get; private set; }
        public string Name { get; set; }

        public string City { get; set; }

        public Customer(int ID)
        {
            CustomerID = ID;

        }
        public override string ToString()
        {
            return Name + "\t" + City + "\t" + CustomerID;
        }
        


        public static List<Customer> FindCustomersByCity(List<Customer> customers, string city)
        {
            return customers.FindAll((Customer c) => c.City == city);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            //Customer c = new Customer(1);
            //c.Name = "Maria Anders";
            //c.City = "Berlin";

            //Customer c = new Customer(1) { Name = "Maria Anders", City = "Berlin" };
            //List<Customer> customers = CreateCustomers();

            //Console.WriteLine("Customers: \n");
            //foreach (var c in customers)
            //    Console.WriteLine(c);

            //Exercise 4 Task2
            //var customers = CreateCustomers();

            //var addedCustomers = new List<Customer>
            //{
            //    new Customer(9) {Name = "Paolo Accorti", City = "Torino"},
            //    new Customer(10) {Name = "Diego Roel", City = "Madrid"}
            //};

            //var updatedCustomers = customers.Append(addedCustomers);


            ////Exercise 4 Task1
            //var newCustomer = new Customer(10)
            //{
            //    Name = "Diego Roel",
            //    City = "Madrid"
            //};

            //foreach (var c in updatedCustomers)
            //{
            //    if (newCustomer.Compare(c))
            //    {
            //        Console.WriteLine("The new cutomer was already in the list");
            //        return;
            //    }

            //}
            //Console.WriteLine("The new cutomer was not in the list");

            //exercise5 task1
            //var customers = CreateCustomers();

            //foreach (var c in FindCustomersByCity(customers, "London"))
            //    Console.WriteLine(c);

            static List<Customer> CreateCustomers()
            {
                return new List<Customer>
                {
                    new Customer(1){ Name = "Maria Anders", City = "Berlin" },
                    new Customer(2) { Name = "Laurence Lebihan", City = "Marseille" },
                    new Customer(3) { Name = "Elizabeth Brown", City = "London" },
                    new Customer(4) { Name = "Ann Devon", City = "London" },
                    new Customer(5) { Name = "Paolo Accorti", City = "Torino" },
                    new Customer(6) { Name = "Fran Wilson", City = "Protland" },
                    new Customer(7) { Name = "Simon Crowther", City = "London" },
                    new Customer(8) { Name = "Liz Nixon", City = "Portland" }

                };

            }
            //exercise5 task2
            var customers = CreateCustomers();
            var customerDictionary = new Dictionary<Customer, string>();
            foreach (var c in customers)
                customerDictionary.Add(c, c.Name.Split(' ')[1]);

            var matches = customerDictionary.FilterBy(
                (customer, lastName) => lastName.StartsWith("A"));

            Console.WriteLine("Number of the Matches: {0}", matches.Count);
        }



    }
}
