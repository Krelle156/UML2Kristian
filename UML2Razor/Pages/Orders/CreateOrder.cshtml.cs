using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using PizzaLibrary.Interfaces;
using PizzaLibrary.Models;
using PizzaLibrary.Services;

namespace UML2Razor.Pages.Orders
{
    public class CreateOrderModel : PageModel
    {
        private ICustomerRepository _cRepo;
        private IMenuItemRepository _mRepo;
        private IShoppingCart _sCart;

        [BindProperty]
        public string SearchCustomerMobile { get; set; }
        public Customer TheCustomer { get; set; }

        public string OrderWarningMSG { get; set; }
        public string CustomerWarningMSG { get; set; }

        [BindProperty]
        public int ChosenMenuItem { get; set; }

        [BindProperty]
        public int Amount { get; set; }
        [BindProperty]
        public string Comment { get; set; }

        public List<SelectListItem> MenuItemSelectList { get; set; }
        public List<IOrderLine> OrderLines { get; set; }

        public CreateOrderModel(
            ICustomerRepository customerRepository,
            IMenuItemRepository menuItemRepository,
            IShoppingCart shoppingCart)
        {
            _cRepo = customerRepository;
            _mRepo = menuItemRepository;
            _sCart = shoppingCart;
            createMenuSelectList();

            TheCustomer = _sCart.Customer;
            OrderLines = _sCart.GetAll();
        }

        private void createMenuSelectList()
        {
            MenuItemSelectList = new List<SelectListItem>();
            MenuItemSelectList.Add(new SelectListItem("Select an item","-1"));
            foreach(MenuItem item in _mRepo.GetAll())
            {
                SelectListItem sli = new SelectListItem(item.Name, item.No.ToString());
                MenuItemSelectList.Add(sli);
            }
        }

        public void OnGet()
        {

        }

        public void OnPostCustomer()
        {
            TheCustomer = _cRepo.GetCustomerByMobile(SearchCustomerMobile);
            _sCart.Customer = TheCustomer;
            if(TheCustomer == null)
            {
                //Replace with le exception???
            }
        }

        public void OnPostAddToOrder()
        {
            if(Amount > 0)
            {
                MenuItem menuItemToOrder = _mRepo.GetMenuItemByNo(ChosenMenuItem);
                if(menuItemToOrder != null)
                {
                    OrderLine tempLine = new OrderLine(menuItemToOrder, Amount, Comment);
                    _sCart.AddOrderLine(tempLine);
                }
            }
        }

        public IActionResult OnPostCreateOrder()
        {
            if (TheCustomer == null && OrderLines.Count < 1) OrderWarningMSG = "Empty order?";
            else if (TheCustomer == null) OrderWarningMSG = "You must assign a customer to this order";
            else if (OrderLines.Count < 1) OrderWarningMSG = "You have not added anything to the order";
            else
            {

                return RedirectToPage("ShowOrders");
            }
            return Page();
        }
        public void OnPostDeleteLine(int id)
        {
            _sCart.RemoveLine(id);
        }
    }
}
