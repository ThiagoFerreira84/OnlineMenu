using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineMenu.Service.ViewModels
{
    public class VMCountry
    {
        public System.Guid Id { get; set; }
        public string CountryName { get; set; }
        public string CurrencySymbol { get; set; }
        public decimal GovernmentTax { get; set; }

        public virtual ICollection<VMRestaurant> Restaurants { get; set; }
    }
}