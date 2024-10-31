using PizzaLibrary.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleMenu.Controllers.MenuItems
{
    public class ShowCustomerController
    {
        private ICustomerRepository _customerRepository;
        public ShowCustomerController(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public void ShowAllCustomers()
        {
            _customerRepository.PrintAllCustomers();
        }

    }
}
