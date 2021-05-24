using System;
using System.Collections.Generic;
using System.Linq;

namespace Exercise7
{
    public class Store
    {
        public string Name { get; set; }

        public string City { get; set; }

        public override string ToString()
        {
            return Name + "\t" + City;
        }
    }

    public class Customer
    {

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

        static List<Store> CreateStores()
        {
            return new List<Store>
            {
                new Store{ Name = "Jim's Hardware", City = "Berlin"},
                new Store{ Name = "John's Books", City = "London"},
                new Store{ Name = "Lisa's Flowers", City = "Torino"},
                new Store{ Name = "Dana's Hardware", City = "London"},
                new Store{ Name = "Tim's Pets", City = "Portland"},
                new Store{ Name = "Scott's Books", City = "London"},
                new Store{ Name = "Paula's Cafe", City = "Marseille"}

            };
        }

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

        static void Query()
        {   
            //Exercise 7:
            //var stores = CreateStores();
            //foreach (var store in stores.Where((Store c) => c.City == "London"))
            //    Console.WriteLine(store);

            //IEnumerable<Store> results = from s in stores
            //                             where s.City == "London"
            //                             select s;
            //foreach (var s in results)
            //    Console.WriteLine(s);

            //var numLondon = stores.Count(s => s.City == "London");
            //Console.WriteLine("There are {0} stores in London.", numLondon);
            
            foreach (var c in CreateCustomers())
            {
                var customerStores = new
                {
                    //CustomersID = c.CustomerID,
                    //City = c.City,
                    c.CustomerID,
                    c.City,
                    CustomerName = c.Name,
                    Stores = from s in CreateStores()
                             where s.City == c.City
                             select s
                };

                Console.WriteLine("{0}\t{1}", customerStores.City, customerStores.CustomerName);
                foreach (var store in customerStores.Stores)
                    Console.WriteLine("\t<{0}>", store.Name);

            }


        }
        static void Main(string[] args)
        {
            Query();
        }
    }
}
