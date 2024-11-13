using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaLibrary.Models
{
    public class CompanyInfo
    {
        CompanyInfo _instance;

        private CompanyInfo(double vat, string name, double discount)
        {
            CVR = "90157085178791"; //er der en "korrekt" cvr kombination for "Big Mamma"?
            Vat = vat;
            Name = name;
            ClubDiscount = discount;
        }

        public CompanyInfo GetCompanyInfo()
        {
            if(_instance == null) _instance = new CompanyInfo(0.25, "Big Mamma", 0.25);
            return _instance;
        }

        public CompanyInfo UpdateCompanyInfo(double vat, string cvr, string name, double discount)
        {
            if (_instance == null) _instance = new CompanyInfo(vat, name, discount);
            return _instance;
        }

        public double Vat { get; set; }
        public string CVR { get; }
        public string Name { get; set; }
        public double ClubDiscount { get; set; }
    }
}
