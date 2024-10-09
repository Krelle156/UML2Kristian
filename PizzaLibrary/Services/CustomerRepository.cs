using PizzaLibrary.Interfaces;
using PizzaLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaLibrary.Services
{
    public class CustomerRepository : ICustomerRepository
    {
        #region Instance fields
        private Dictionary<string, Customer> _customers;
        #endregion
        public int Count { get { return _customers.Count; } }

        public CustomerRepository()
        {
            _customers = Data.MockData.CustomerData;
        }

        #region Methods

        public void AddCustomer(Customer customer)
        {
            if (_customers.ContainsKey(customer.Mobile)) return;
            _customers[customer.Mobile] = customer;
        }

        public List<Customer> GetAll()
        {
            return _customers.Values.ToList();
        }

        public Customer GetCustomerByMobile(string mobile)
        {
            if(_customers.ContainsKey(mobile)) return _customers[mobile];
            return null;
        }

        public void printAllCustomers()
        {
            foreach (Customer customer in _customers.Values)
            {
                Console.WriteLine(customer.Name);
            }
        }

        public void RemoveCustomer(string mobile)
        {
            _customers.Remove(mobile);
        }

        #endregion
    }
}
