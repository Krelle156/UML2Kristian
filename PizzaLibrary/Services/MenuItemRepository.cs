using PizzaLibrary.Interfaces;
using PizzaLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaLibrary.Services
{
    public class MenuItemRepository : IMenuItemRepository
    {
        private List<MenuItem> _menuItemList;

        public int Count => throw new NotImplementedException();

        public void AddMenuItem(MenuItem menuItem)
        {
            throw new NotImplementedException();
        }

        public List<MenuItem> GetAll()
        {
            throw new NotImplementedException();
        }

        public MenuItem GetMenuItemByNo(int no)
        {
            throw new NotImplementedException();
        }

        public void PrintAllMenuItems()
        {
            throw new NotImplementedException();
        }

        public void RemoveMenuItem(int no)
        {
            throw new NotImplementedException();
        }
    }
}
