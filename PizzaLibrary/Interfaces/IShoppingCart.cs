using PizzaLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaLibrary.Interfaces
{
    public interface IShoppingCart
    {
        public Customer Customer { get; set; }
        List<IOrderLine> GetAll();
        void AddOrderLine(IOrderLine line);

        void RemoveLine(int id) { }
    }
}
