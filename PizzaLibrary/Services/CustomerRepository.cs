using PizzaLibrary.Exeptions;
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

        #region Properties
        public int Count { get { return _customers.Count; } }
        #endregion

        #region Constructors
        public CustomerRepository()
        {
            _customers = new Dictionary<string, Customer>();
        }

        public CustomerRepository(Dictionary<string, Customer> repo)
        {
            _customers = repo;
        }
        #endregion

        #region Methods

        public void AddCustomer(Customer customer)
        {
            List<int> _IdsInUse = new List<int>();

            foreach(Customer c in _customers.Values)
            {
                _IdsInUse.Add(c.ID);
            }

            _IdsInUse.Sort();

            for(int i = 0; i<_IdsInUse.Count; i++)
            {
                if (i+1 != _IdsInUse[i])
                {
                    customer.ID = i + 1;
                    break;
                }
            }
            if (customer.ID == 0) customer.ID = _IdsInUse.Count + 1;

            if (_customers.ContainsKey(customer.Mobile)) throw new CustomerMobileNumberExistsException();
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

        public void PrintAllCustomers()
        {
            Console.WriteLine(ToString());
        }

        public List<Customer> AllClubMembersList()
        {
            List<Customer> resultList = new List<Customer>();
            foreach (Customer customer in _customers.Values)
            {
                if(customer.ClubMember) resultList.Add(customer);
            }
            return resultList;
        }

        public List<Customer> FromRoskildeList()
        {
            List<Customer> resultList = new List<Customer>();
            foreach (Customer customer in _customers.Values)
            {
                if (customer.Address.Contains("Roskilde") || customer.Address.Contains("4000")) resultList.Add(customer);
            }
            return resultList;
        }

        public void RemoveCustomer(string mobile)
        {

            _customers.Remove(mobile);
        }

        public void EditCustomer(string name, string address, string newMobile, bool clubMember, string mobile)
        {
            if (_customers.ContainsKey(newMobile) && newMobile != mobile) throw new CustomerMobileNumberExistsException();

            Customer tempRef = _customers[mobile];

            tempRef.Name = name;
            tempRef.Address = address;
            tempRef.ClubMember = clubMember;

            if(tempRef.Mobile != newMobile)
            {
                tempRef.Mobile = newMobile;
                _customers.Remove(mobile);
                _customers[newMobile] = tempRef;
            }
        }

        public override string ToString()
        {
            string result = $"Der er registreret {Count} kunder. De er:\n";
            foreach (Customer customer in _customers.Values)
            {
                result += "\n\n" + customer.ToString();
            }
            return result;
        }

        #endregion
    }
}
