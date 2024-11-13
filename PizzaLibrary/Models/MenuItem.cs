using PizzaLibrary.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaLibrary.Models
{
    public class MenuItem : IMenuItem
    {
        #region Instance Fields
        private static int counter;
        private int _no;
        #endregion

        #region Constructors

        public MenuItem()
        {
            
        }

        public MenuItem(string name, double price, string description, MenuType menuType)
        {
            counter++;
            _no = counter;

            Name = name;
            Price = price;
            Description = description;
            TheMenuType = menuType;
        }
        #endregion

        #region Properties
        public string Description { get; set; }
        public string Name { get; set; }

        public int No { get { return _no; } }
        public double Price {  get; set; }
        public MenuType TheMenuType { get; set; }
        #endregion

        #region Methods
        public override string ToString()
        {
            return $"Nr. {_no}: {Name}\t\t\t{TheMenuType}" +
                $"\n{Description}\t\t\t{Price}-";
        }
        #endregion
    }
}
