using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaLibrary.Interfaces
{
    public interface IOrder
    {
        int Id { get;}
        bool ToBeDelivered { get; set; }

        void AddToOrder(IOrderLine line);
        double CalculateTotal();
        void PrintReceipt();
        string ToString();
    }
}
