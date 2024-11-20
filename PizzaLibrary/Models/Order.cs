using PizzaLibrary.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaLibrary.Models
{
    public class Order : IOrder
    {
        #region instance fields
        private static int _counter;

        private List<IOrderLine> _lines;
        private ICustomer _customer;
        private DateTime _created;
        #endregion

        #region properties
        public int Id { get;}
        public bool ToBeDelivered { get; set; }
        #endregion

        public Order(ICustomer customer)
        {
            _counter++;

            _lines = new List<IOrderLine>();
            _customer = customer;
            _created = DateTime.Now;

            Id = _counter;
        }

        #region methods
        public void AddToOrder(IOrderLine line)
        {
            _lines.Add(line);
        }

        public double CalculateTotal()
        {
            double result = 0;
            foreach (IOrderLine line in _lines)
            {
                result += line.SubTotal();
            }
            return result;
        }

        public void PrintReceipt()
        {
            foreach (IOrderLine line in _lines)
            {
                Console.WriteLine($"{line.MenuItem.Name} x {line.Amount} : {line.SubTotal}");
            }

            Console.WriteLine($"Total: {CalculateTotal}");
        }

        public override string ToString()
        {
            string lineStrings ="";
            foreach (IOrderLine line in _lines)
            {
                lineStrings += "\n" + line.ToString();
            }
            return $"The Order with ID {Id}, created {_created}, belongs to customer {_customer} and {(ToBeDelivered ? "has been resolved" : "has yet to be resolved")}\n" +
                $"It has the following items:" + lineStrings;
        }
        #endregion
    }
}
