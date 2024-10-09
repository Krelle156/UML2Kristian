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

        public int Count { get { return _menuItemList.Count; } }

        public void AddMenuItem(MenuItem menuItem)
        {
            for(int i = 0;  i < _menuItemList.Count; i++)
            {
                if (_menuItemList[i].TheMenuType == menuItem.TheMenuType) _menuItemList.Insert(i, menuItem); //The intention is to group the positions of the menuitems by type
                return;
            }
            _menuItemList.Add(menuItem);
        }

        public List<MenuItem> GetAll()
        {
            return _menuItemList;
        }

        public MenuItem GetMenuItemByNo(int no)
        {
            if (no > _menuItemList.Count) return null;
            return _menuItemList[no-1];
        }

        public void PrintAllMenuItems()
        {
            foreach(MenuItem menuItem in _menuItemList)
            {
                Console.WriteLine(menuItem.ToString());
            }
        }

        public void RemoveMenuItem(int no)
        {
            throw new NotImplementedException();
        }
    }
}
