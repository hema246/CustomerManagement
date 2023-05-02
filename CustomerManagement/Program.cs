using System.Collections.Generic;
using System.Net.Http.Headers;

namespace CustomerManagement
{

    class Customer
    {
        
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public int Age { get; set; }
        public long Phone { get; set; }
        public string City { get; set; }

        public int Id { get; set; }

    }
    class Management
    {   
        
        List<Customer> customers;
        public int CustId = 1;
        public Management()
        {
            customers = new List<Customer>()
            {

                new Customer {Id=CustId+1,FirstName = "Hema", LastName = "Priya", Email = "hema24@gmail.com", Age = 21, Phone = 9629734468, City = "Tirupur" },
                new Customer {Id=CustId+1,FirstName = "Mary", LastName = "Reshmiya", Email = "methu23@gmail.com", Age = 22, Phone = 8508392319, City = "Erode" },
            };
        }
        public void AddCustomer()
        {
            Console.WriteLine("Enter Customer First Name");
            string fname = Console.ReadLine();
            Console.WriteLine("Enter customer Last Name");
            string lname = Console.ReadLine();
            Console.WriteLine("Enter Customer Email Id");
            string emailid = Console.ReadLine();
            Console.WriteLine("Enter Customer Age");
            int age = Convert.ToInt16(Console.ReadLine());
            Console.WriteLine("Enter Customer Phone Number");
            long ph = Convert.ToInt64(Console.ReadLine());
            Console.WriteLine("Enter Customer City");
            string city = Console.ReadLine();
            int id = CustId + 1;
            customers.Add(new Customer() { Id = id, FirstName = fname, LastName = lname, Email = emailid, Age = age, Phone = ph, City = city });
            Console.WriteLine("Customer details added successfully");
        }
        public Customer GetRandomId(int id)

        {
            foreach(Customer c in customers)
            {
                if(c.Id == id) 
                    return c;
            }
            return null;
        }
             
        public List<Customer> GetCustomers()
        {
            return customers;
        }
        public bool DeleteCustomer(int id)
        {
            foreach (Customer c in customers)
            {
                if (c.Id == id)
                {
                    customers.Remove(c);
                    return true;
                }
            }
            return false;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Management obj = new Management();
            string result = "";
            do
            {
                Console.WriteLine("Select one from below:");
                Console.WriteLine("1. Add Customer");
                Console.WriteLine("2.Get Customer by Id");
                Console.WriteLine("3. Get All Customer");
                Console.WriteLine("4. Delete Customer By Id");
                int choice = Convert.ToInt16(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        {
                            obj.AddCustomer();
                            break;
                        }
                    case 2:
                        {
                            Console.WriteLine("Enter Customer Id");
                            int id = Convert.ToInt16(Console.ReadLine());
                            Customer? c = obj.GetRandomId(id);
                            if (c == null)
                            {
                                Console.WriteLine("Customer with specified id does not exists");
                            }
                            else
                            {
                                Console.WriteLine($"{c.Id} {c.FirstName} {c.LastName} {c.Email} {c.Age}{c.Phone}{c.City}");
                            }
                            break;
                        }
                    case 3:
                        {
                            foreach (var c in obj.GetCustomers())
                            {
                                Console.WriteLine($"{c.Id} {c.FirstName} {c.LastName} {c.Email} {c.Age}{c.Phone}{c.City}");
                            }
                            break;
                        }
                    case 4:
                        {
                            Console.WriteLine("Enter Customer Id");
                            int id = Convert.ToInt16(Console.ReadLine());
                            if (obj.DeleteCustomer(id))
                            {
                                Console.WriteLine("Customer Deleted Successfully");
                            }
                            else
                            {
                                Console.WriteLine("Customer not found");
                            }
                            break;
                        }
                }
                Console.WriteLine("Do you wish to continue? [y/n] ");
                result = Console.ReadLine();
            } while (result.ToLower() == "y");
        }
    }
}