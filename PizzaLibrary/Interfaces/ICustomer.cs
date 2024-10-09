using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaLibrary.Interfaces
{
    public interface ICustomer
    {
        string Address { get; set; }
        bool ClubMember { get; set; }
        int ID { get; }
        string Mobile {  get; set; }
        string Name { get; set; }
        string ToString();
    }
}
