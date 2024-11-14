using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PizzaLibrary.Data;
using PizzaLibrary.Interfaces;
using PizzaLibrary.Models;
using PizzaLibrary.Services;

namespace UML2Razor.Pages.Customers
{
    public class AddCustomerModel : PageModel
    {
        private ICustomerRepository _repo;

        [BindProperty] public Customer Customer { get; set; }

        public AddCustomerModel(ICustomerRepository customerRepository)
        {
            _repo = customerRepository;
        }

        public void OnGet()
        {

        }

        public IActionResult OnPost()
        {
            _repo.AddCustomer(Customer);
            return RedirectToPage("ShowCustomers");
        }
    }
}
