using PizzaLibrary.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PizzaLibrary.Models;

namespace PizzaLibrary.Services
{
    public class ShoppingCart : IShoppingCart
    {
        private List<IOrderLine> _orderLines;

        public Customer Customer { get; set; }

        public ShoppingCart()
        {
            _orderLines = new List<IOrderLine>();
        }

        public List<IOrderLine> GetAll()
        {
            return _orderLines;
        }

        public void AddOrderLine(IOrderLine line)
        {
            line.Id = _orderLines.Count;
            _orderLines.Add(line);
        }

        public void RemoveLine(int id)
        {
            _orderLines.RemoveAt(id);
            for(int i =id; i<_orderLines.Count; i++)
            {
                _orderLines[i].Id = i;
            }
        }

    }
}
