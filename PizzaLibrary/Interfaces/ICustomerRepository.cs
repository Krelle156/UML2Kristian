using PizzaLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaLibrary.Interfaces
{
    public interface ICustomerRepository
    {
        public int Count { get; }
        List<Customer> GetAll();
        void AddCustomer(Customer customer);
        Customer GetCustomerByMobile(string mobile);
        void PrintAllCustomers();
        void RemoveCustomer(string mobile);

        void EditCustomer(string name, string address, string newMobile, bool clubMember, string mobile);
    }
}
