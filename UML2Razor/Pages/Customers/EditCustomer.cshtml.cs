using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PizzaLibrary.Interfaces;
using PizzaLibrary.Models;
using PizzaLibrary.Services;

namespace UML2Razor.Pages.Customers
{
    public class EditCustomerModel : PageModel
    {
        private ICustomerRepository _repo;

        [BindProperty] public string Name { get; set; }
        [BindProperty] public string Address { get; set; }
        [BindProperty] public string newMobile { get; set; }
        [BindProperty] public bool Clubmember { get; set; }

        public EditCustomerModel(ICustomerRepository customerRepository)
        {
            _repo = customerRepository;
        }

        public void OnGet()
        {
            
        }

        public IActionResult OnPost(string mobile, bool chooseClub)
        {
            _repo.EditCustomer(Name, Address, newMobile, chooseClub, mobile);
            return RedirectToPage("ShowCustomers");
        }
    }
}
