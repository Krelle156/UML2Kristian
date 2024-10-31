using PizzaLibrary.Exeptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaLibrary.Models
{
    public class VIPCustomer : Customer
    {
        private double _minDiscount = 0.01, _maxDiscount = 0.25;

        public double Discount { get; set; }
        public VIPCustomer(string name, string mobile, string address, double discount) : base(name, mobile, address)
        {
            if (discount < _minDiscount || discount > _maxDiscount) throw new TooHighDiscountException();
            Discount = discount;
        }

        public override string ToString()
        {
            return "VIP-kunde:\n" + base.ToString() + $"\n deres discount er {Discount}";
        }
    }
}
