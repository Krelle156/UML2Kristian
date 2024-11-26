using PizzaLibrary.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaLibrary.Models
{
    public class OrderLine : IOrderLine
    {

        private IMenuItem _menuItem;

        public OrderLine(IMenuItem item, int amount)
        {
            _menuItem = item;
            Amount = amount;
            Comment = "";
        }

        public OrderLine(IMenuItem item, int amount, string comment)
        {
            _menuItem = item;
            Amount = amount;
            Comment = comment;
        }

        public int Id { get; set; }
        public int Amount { get; set; }
        public string Comment { get; set; }
        public IMenuItem MenuItem
        {
            get { return _menuItem; }
            set { _menuItem = value; }
        }

        public void AddExtraAccessory(IAccessory accesory)
        {
            throw new NotImplementedException();
        }

        public double SubTotal()
        {
            return MenuItem.Price * Amount;
        }
    }
}
