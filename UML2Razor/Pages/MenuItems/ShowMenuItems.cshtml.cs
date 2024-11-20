using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PizzaLibrary.Interfaces;
using PizzaLibrary.Models;

namespace UML2Razor.Pages.MenuItems
{
    public class ShowMenuItemsModel : PageModel
    {
        private IMenuItemRepository _repo;

        public List<MenuItem> MenuItems { get; private set; }

        public ShowMenuItemsModel(IMenuItemRepository menuItemRepository)
        {
            _repo = menuItemRepository;
        }

        public void OnGet()
        {
            MenuItems = _repo.GetAll();
        }
    }
}
