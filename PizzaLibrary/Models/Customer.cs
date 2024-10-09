using PizzaLibrary.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace PizzaLibrary.Models
{
    public class Customer : ICustomer
    {
        #region Instance fields
        private int _id;
        private static int counter;
        #endregion


        public Customer(string name, string mobile, string address)
        {
            _id = counter;

            Name = name;
            Mobile = mobile;
            Address = address;

            counter++;
        }

        public string Address { get; set; }
        public bool ClubMember { get; set; }

        public int ID { get { return counter; } }

        public string Mobile { get; set; }
        public string Name {  get; set; }

        public override string ToString()
        {
            return $"{Name} har kundeid: {ID}" +
                $"\nDe er registreret på adressen {Address}" +
                $"\nTlf: {Mobile}" +
                $"\nDe er{(ClubMember ? " " : " ikke ")}medlem af pizzariaets klub";
        }
    }
}
