using PizzaLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaLibrary.Interfaces
{
    public interface IOrderLine
    {
        int Amount { get; set; }
        string Comment { get; set; }
        IMenuItem MenuItem { get; set; }

        //void AddExtraAccessory(Acessory accesory);
        double SubTotal();
        string ToString();
    }
}
