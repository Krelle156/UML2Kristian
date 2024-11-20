using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaLibrary.Interfaces
{
    public interface IOrderRepository
    {
        int Count { get; set; }

        List<IOrder> GetAll();
        void AddOrder(IOrder order);
        IOrder GetOrderById(int id);
        void RemoveOrder(int id);
        void PrintALlOrders();

        string ToString();
    }
}
