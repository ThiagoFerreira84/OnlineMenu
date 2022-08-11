using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace OnlineMenu.Service.ViewModels
{
    public class VMRestaurant
    {
        public System.Guid Id { get; set; }

        [Required]
        [Display(Name = "Country")]
        public System.Guid CountryId { get; set; }

        [Required]
        [Display(Name = "Restaurant Name")]
        public string Name { get; set; }

        public string Address { get; set; }
        public byte[] Logo { get; set; }

        [Display(Name = "Service Tax")]
        public Nullable<decimal> ServiceTax { get; set; }

        public Nullable<System.DateTime> CreateDate { get; set; }
        public Nullable<System.DateTime> LastModifiedDate { get; set; }
        public string LastModifiedBy { get; set; }

        public VMCountry Country { get; set; }
        public virtual ICollection<VMMenuCategory> MenuCategories { get; set; }

        public virtual ICollection<VMSubscription> Subscriptions { get; set; }
        public virtual ICollection<VMTable> Tables { get; set; }
        public virtual ICollection<VMUser> Users { get; set; }
    }
}