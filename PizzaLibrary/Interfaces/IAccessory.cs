using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaLibrary.Interfaces
{
    public interface IAccessory
    {
        int Id { get; set; }
        string Name { get; set; }
        double Price { get; set; }

        string ToString();

    }
}
