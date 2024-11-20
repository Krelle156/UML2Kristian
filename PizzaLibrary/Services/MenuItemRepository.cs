using PizzaLibrary.Data;
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
        #region instance fields
        private List<MenuItem> _menuItemList;
        #endregion

        #region Constructors
        public MenuItemRepository()
        {
            //_menuItemList = new List<MenuItem>();
            _menuItemList = MockData.MenuItemData;
        }

        public MenuItemRepository(List<MenuItem> repo)
        {
            _menuItemList = repo;
        }
        #endregion

        #region Properties
        public int Count { get { return _menuItemList.Count; } }
        #endregion

        #region Metods
        public void AddMenuItem(MenuItem menuItem)
        {
            for(int i = 0;  i < _menuItemList.Count; i++)
            {
                if (_menuItemList[i].TheMenuType == menuItem.TheMenuType)
                {
                    _menuItemList.Insert(i, menuItem); //The intention is to group the positions of the menuitems by type
                    return;
                }
            }
            _menuItemList.Add(menuItem);
        }

        public List<MenuItem> GetAll()
        {
            return _menuItemList;
        }

        #region "advanced" searches
        public List<MenuItem> GetAbovePrice(double price)
        {
            List<MenuItem> resultList = new List<MenuItem>();
            foreach (MenuItem menuItem in _menuItemList)
            {
                if (price > menuItem.Price) resultList.Add(menuItem);
            }
            return resultList;
        }

        public List<MenuItem> GetMenuItemsOfTypes(MenuType type)
        {
            return _menuItemList.FindAll(listObject => listObject.TheMenuType == type);
        }

        public MenuItem GetMostExpensiveItem()
        {
            if (_menuItemList.Count == 0) return null;

            MenuItem result = _menuItemList[0];
            foreach(MenuItem menuItem in _menuItemList)
            {
                if(result.Price < menuItem.Price) result = menuItem;
            }
            return result;
        }

        public MenuItem GetMostExpensiveItem(MenuType type)
        {
            if (_menuItemList.Count == 0) return null;

            MenuItem result = null;

            int index = 0;
            while (index < _menuItemList.Count && result == null)
            {
                if (_menuItemList[index].TheMenuType == type)
                {
                    result = _menuItemList[index];
                }
                index++;
            }
            while (index < _menuItemList.Count)
            {
                if (_menuItemList[index].TheMenuType == type && _menuItemList[index].Price > result.Price)
                {
                    result = _menuItemList[index];
                }
                index++;
            }
            return result;
            return result;
        }

        public MenuItem GetMostExpensiveItem(MenuType[] type)
        {
            if (_menuItemList.Count == 0) return null;

            MenuItem result = null;

            int index = 0;
            while(index < _menuItemList.Count && result == null)
            {
                foreach (MenuType menuType in type)
                {
                    if (_menuItemList[index].TheMenuType == menuType)
                    {
                        result = _menuItemList[index];
                    }
                }
                index++;
            }
            while(index < _menuItemList.Count)
            {
                foreach (MenuType menuType in type)
                {
                    if (_menuItemList[index].TheMenuType == menuType && _menuItemList[index].Price > result.Price)
                    {
                        result = _menuItemList[index];
                    }
                }
                index++;
            }
            return result;
        }

        #endregion

        public MenuItem GetMenuItemByNo(int no)
        {
            if (no > _menuItemList.Count) return null;
            return _menuItemList[no-1];
        }

        public void PrintAllMenuItems()
        {
            Console.WriteLine(ToString());
        }

        public void RemoveMenuItem(int no)
        {
            _menuItemList.Remove(GetMenuItemByNo(no));

        }

        public override string ToString()
        {
            string result = $"Der er {Count} genstande på menuen, de er:";
            foreach (MenuItem menuItem in _menuItemList)
            {
                result += "\n\n" + menuItem.ToString();
            }
            return result;
        }
        #endregion
    }
}
