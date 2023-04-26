using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using EfCorePlayground.Data;
using EfCorePlayground.Models;
using Microsoft.EntityFrameworkCore;

namespace EfCorePlayground.Processors {
    public class EfTester {
        public void Run() {

            //AddAnna();
            //GetAllCustomers();
           // GetAllWithEager();
            //GettAllWithProjection();
            //Customer customer = new Customer(){CustomerId = 2};
            //customer.FirstName = "Anna-1";
            //customer.DateOfBirth = DateTime.Today.AddYears(-25);

            //UpdateDisconnected(customer);

            //SearchCustomer("Bob","Test");

            //var customers = GetCustomerByName("anna");
            //UpdateCustomerAge(2, 33);
            //GetAllCustomers();

            AddCustomerWithAddress();
            GetAllWithEager();
        }

        private void GetAllWithEager()
        {
            using var context = new CustomerContext();
            var customers = context.Customers.Include(p => p.Addresses).ToList();

            foreach (var customer in customers) {
                Console.WriteLine($"{customer.FirstName} {customer.LastName} - {customer.DateOfBirth.ToShortDateString()}");
                Console.WriteLine($"    Customer has {customer.Addresses.Count} addresses");
                foreach (var address in customer.Addresses) {
                    Console.WriteLine($"      {address.Street} {address.City}, {address.State}, {address.Zip} ");
                }
            }


        }

        private void GettAllWithProjection() {
            using var context = new CustomerContext();
            var customers = context.Customers.Select(p => new { p.FirstName, p.LastName, p.Addresses }).ToList();

            foreach (var customer in customers) {
                Console.WriteLine($"{customer.FirstName} {customer.LastName}");
                Console.WriteLine($"    Customer has {customer.Addresses.Count} addresses");
                foreach (var address in customer.Addresses) {
                    Console.WriteLine($"      {address.Street} {address.City}, {address.State}, {address.Zip} ");
                }
            }
        }


        private void AddCustomerWithAddress() {
            using var context = new CustomerContext();

            var customer = new Customer() {
                FirstName = "Ella",
                LastName = "Smith",
                DateOfBirth = DateTime.Today.AddYears(-29)
            };

            var address = new Address() {
                Street = "1234 Main St",
                State = "PA",
                City = "Philadelphia",
                Zip = "19111"
            };

            customer.Addresses.Add(address);

            context.Customers.Add(customer);
            context.SaveChanges();

        }

        private void SearchCustomer(string firstName, string lastName, DateTime? dobTime = null) {
            using var context = new CustomerContext();

            //context.Customers.Where(p => EF.Functions.Like(p.FirstName ,"B%B"));

            var query = context.Customers.AsQueryable();

            if (!string.IsNullOrEmpty(firstName)) {
                query = query.Where(p => p.FirstName == firstName);
            }

            if (!string.IsNullOrEmpty(lastName)) {
                query = query.Where(p => p.LastName == lastName);
            }




            var customers = query.ToList();
        }

        private void UpdateDisconnected(Customer customer) {
            using var context = new CustomerContext();
            //var entity = context.Customers.Find(customer.CustomerId);
            //entity.FirstName=customer.FirstName;
            //entity.LastName=customer.LastName;
            //entity.DateOfBirth=customer.DateOfBirth;

            context.Customers.Update(customer);
            context.SaveChanges();
        }

        private void UpdateCustomerAge(int customerId, int age) {
            using var context = new CustomerContext();
            var customer = context.Customers.Find(customerId);
            if (customer != null) {
                customer.DateOfBirth = DateTime.Today.AddYears(-age);
                context.SaveChanges();
            }
        }

        private List<Customer> GetCustomerByName(string name) {
            using var context = new CustomerContext();
            var customerList = context.Customers.Where(p => p.FirstName == name).ToList();
            return customerList;
        }

        private Customer GetCustomerById(int customerId) {
            using var context = new CustomerContext();
            //var customer = context.Customers.FirstOrDefault(p => p.CustomerId == customerId);
            var customer = context.Customers.Find(customerId);

            return customer;
        }

        private void AddAnna() {
            var anna = new Customer() {
                FirstName = "Anna",
                LastName = "Test",
                DateOfBirth = DateTime.Today.AddYears(-30)
            };

            using (var context = new CustomerContext()) {
                //context.Customers.Add(anna);
                context.Add(anna);
                context.SaveChanges();
            }

        }

        private void GetAllCustomers() {
            var context = new CustomerContext();


            var customers = context.Customers.ToList();


            foreach (var customer in customers) {
                Console.WriteLine($"{customer.FirstName} {customer.LastName} - {customer.DateOfBirth.ToShortDateString()}");
                Console.WriteLine($"    Customer has {customer.Addresses.Count} addresses");
                foreach (var address in customer.Addresses) {
                    Console.WriteLine($"      {address.Street} {address.City}, {address.State}, {address.Zip} ");
                }
            }



        }
    }
}
