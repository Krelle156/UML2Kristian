using PizzaLibrary.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
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
        private static int counter = 0;
        #endregion

        #region Constructors

        public Customer()
        {
            _id = 0;
            CustomerImage = "default.jpeg";
        }
        public Customer(string name, string mobile, string address)
        {
            _id = counter;

            Name = name;
            Mobile = mobile;
            Address = address;
            CustomerImage = "default.jpeg";

            counter++;
        }
        #endregion

        #region Properties
        [Required(ErrorMessage = "Address is required"), MaxLength(40), DisplayName("Address")]
        public string Address { get; set; }
        public bool ClubMember { get; set; }

        public int ID { get; set; }

        [Required(ErrorMessage = "Your phone number is required, as we use it to identify you"), MaxLength(40), DisplayName("Phöne")]
        public string Mobile { get; set; }
        [Required (ErrorMessage = "Name is required"), MaxLength(40), DisplayName("Name")]
        public string Name {  get; set; }

        public string CustomerImage { get; set; }
        #endregion

        #region Methods
        public override string ToString()
        {
            return $"{Name} har kundeid: {ID}" +
                $"\nDe er registreret på adressen {Address}" +
                $"\nTlf: {Mobile}" +
                $"\nDe er{(ClubMember ? " " : " ikke ")}medlem af pizzariaets klub";
        }
        #endregion
    }
}
