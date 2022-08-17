using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace OnlineMenu.Service.ViewModels
{
    public class VMViewRestaurant
    {
        public System.Guid Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }

        [Display(Name = "Service Tax (%)")]
        public Nullable<decimal> ServiceTax { get; set; }

        [Display(Name = "Create Date")]
        public Nullable<System.DateTime> CreateDate { get; set; }

        [Display(Name = "Logo")]
        public string LogoPath { get; set; }

        [Display(Name = "Country")]
        public string CountryName { get; set; }

        [Display(Name = "Government Tax (%)")]
        public decimal GovernmentTax { get; set; }

        [Display(Name = "Currency Symbol")]
        public string CurrencySymbol { get; set; }

        [Display(Name = "Tables")]
        public Nullable<int> NoOfTables { get; set; }
    }
}