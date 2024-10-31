using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaLibrary.Models
{
    public class Beverage : MenuItem
    {
        public bool Alcohol { get;}

        public Beverage(string name, double price, string description, MenuType type, bool hasEthanol) : base(name, price, description, type)
        {
            Alcohol = hasEthanol;
        }
    }
}
