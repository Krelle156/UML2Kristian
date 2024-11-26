using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PizzaLibrary.Interfaces;

namespace UML2Razor.Pages.Orders
{
    public class ShowOrdersModel : PageModel
    {
        private int _currentOrder;

        private IOrderRepository _orderRepo;
        public List<IOrderLine> OrderLines { get; set; }
        public int CurrentOrder
        {
            get
            {
                if (_currentOrder < 0) _currentOrder = _orderRepo.Count - 1;
                if (_currentOrder >= _orderRepo.Count) _currentOrder = 0;
                return _currentOrder;
            }

            set
            {
                if (value < 0) _currentOrder = _orderRepo.Count - 1;
                else if (value >= _orderRepo.Count) _currentOrder = 0;
                else _currentOrder = value;
            }
        }

        public ShowOrdersModel(IOrderRepository OrderRepository)
        {
            _orderRepo = OrderRepository;
            CurrentOrder = _orderRepo.Count - 1;
            OrderLines = _orderRepo.GetAll()[CurrentOrder].GetAllLines();

        }

        public void OnGet()
        {
        }
    }
}
