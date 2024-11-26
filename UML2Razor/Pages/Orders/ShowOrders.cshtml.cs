using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PizzaLibrary.Interfaces;

namespace UML2Razor.Pages.Orders
{
    public class ShowOrdersModel : PageModel
    {
        private int _currentOrder;

        private IOrderRepository _orderRepo;
        public List<IOrder> Orders { get; set; }
        public int CurrentOrder
        {
            get
            {
                if (CurrentOrder < 0) CurrentOrder = 0;
                if (CurrentOrder >= Orders.Count) CurrentOrder = Orders.Count - 1;
                return CurrentOrder;
            }

            set
            {
                if (value < 0) CurrentOrder = 0;
                else if (value >= Orders.Count) CurrentOrder = Orders.Count - 1;
                else CurrentOrder = value;
            }
        }

        public ShowOrdersModel(IOrderRepository OrderRepository)
        {
            _orderRepo = OrderRepository;
            Orders = _orderRepo.GetAll();

        }

        public void OnGet()
        {
        }
    }
}
