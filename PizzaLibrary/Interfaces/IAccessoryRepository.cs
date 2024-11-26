using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaLibrary.Interfaces
{
    public interface IAccessoryRepository
    {
        int Count { get; }

        List<IAccessoryRepository> GetALL();
        void AddAccessory(IAccessoryRepository accesory);
        IAccessoryRepository GetAccessoryById(int id);
        void RemoveAccessoryByID(int id);
        void PrintAllAccessories(); //
    }
}
