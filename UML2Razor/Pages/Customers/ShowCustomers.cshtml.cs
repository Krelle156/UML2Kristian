using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PizzaLibrary.Data;
using PizzaLibrary.Interfaces;
using PizzaLibrary.Models;
using PizzaLibrary.Services;

namespace UML2Razor.Pages.Customers
{
    public class ShowCustomersModel : PageModel
    {
        private ICustomerRepository _customerRepository;

        public List<Customer> Customers { get; private set; }

        public ShowCustomersModel(ICustomerRepository customerRepository)
        {
            _customerRepository = new CustomerRepository(MockData.CustomerData);
        }

        public void OnGet()
        {
            Customers = _customerRepository.GetAll();
        }
    }
}
