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

        private IWebHostEnvironment webHostEnvironment;

        [BindProperty] public Customer Customer { get; set; }

        public AddCustomerModel(ICustomerRepository customerRepository, IWebHostEnvironment webHost)
        {
            _repo = customerRepository;
            webHostEnvironment = webHost;
        }

        public void OnGet()
        {

        }

        public IActionResult OnPost()
        {
            
            if(!ModelState.IsValid)
            {
                return Page();
            }
            


            _repo.AddCustomer(Customer);
            return RedirectToPage("ShowCustomers");
        }

    }
}
