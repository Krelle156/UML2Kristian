using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PizzaLibrary.Interfaces;
using PizzaLibrary.Models;

namespace UML2Razor.Pages.MenuItems
{
    public class DeleteMenuItemModel : PageModel
    {
        private IMenuItemRepository _repo;

        [BindProperty] public MenuItem MenuItem { get; set; }

        public DeleteMenuItemModel(IMenuItemRepository menuItemRepository)
        {
            _repo = menuItemRepository;
        }

        public void OnGet(int deleteNo)
        {
            MenuItem = _repo.GetMenuItemByNo(deleteNo);
        }

        public IActionResult OnPost(int deleteNo)
        {
            _repo.RemoveMenuItem(deleteNo);
            return RedirectToPage("ShowMenuItems");
        }
    }
}
