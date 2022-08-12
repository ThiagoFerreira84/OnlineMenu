using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace OnlineMenu.Service.ViewModels
{
    public class VMCountry
    {
        public System.Guid Id { get; set; }

        [Display(Name = "Country Name")]
        public string CountryName { get; set; }

        [Display(Name = "Currency Symbol")]
        public string CurrencySymbol { get; set; }

        [Display(Name = "Government Tax (%)")]
        public decimal GovernmentTax { get; set; }
    }
}