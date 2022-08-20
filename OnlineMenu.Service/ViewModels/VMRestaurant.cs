using OnlineMenu.Model;
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

        [Display(Name = "Logo")]
        public string LogoFileName { get; set; }

        [Display(Name = "Service Tax (%)")]
        public Nullable<decimal> ServiceTax { get; set; }

        [Display(Name = "Create Date")]
        public Nullable<System.DateTime> CreateDate { get; set; }

        public Nullable<System.DateTime> LastModifiedDate { get; set; }
        public string LastModifiedBy { get; set; }
        public Nullable<bool> IskitchenOpen { get; set; }
        public string LogoPath { get; set; }

        public VMCountry Country { get; set; }
        public virtual ICollection<VMPage> Pages { get; set; }
        public virtual ICollection<VMSubscription> Subscriptions { get; set; }
        public virtual ICollection<VMTable> Tables { get; set; }
        public virtual ICollection<VMUserVsRestaurant> UserVsRestaurants { get; set; }
    }
}