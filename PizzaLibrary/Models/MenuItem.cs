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
        private static int counter;
        private int _no;

        public MenuItem(string name, double price, string description, MenuType menuType)
        {
            counter++;
            _no = counter;

            Name = name;
            Price = price;
            Description = description;
            TheMenuType = menuType;
        }
        public string Description { get; set; }
        public string Name { get; set; }

        public int No { get { return _no; } }
        public double Price {  get; set; }
        public MenuType TheMenuType { get; set; }

        public override string ToString()
        {
            return $"Nr. {_no}: {Name}      {TheMenuType}" +
                $"\n{Description}        {Price}";
        }
    }
}
