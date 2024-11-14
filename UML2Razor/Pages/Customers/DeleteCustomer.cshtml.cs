using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PizzaLibrary.Interfaces;

namespace UML2Razor.Pages.Customers
{
    public class DeleteCustomerModel : PageModel
    {
        private ICustomerRepository _repo;

        public DeleteCustomerModel(ICustomerRepository customerRepository)
        {
            _repo = customerRepository;
        }

        public void OnGet(int deleteId)
        {

        }
    }
}
