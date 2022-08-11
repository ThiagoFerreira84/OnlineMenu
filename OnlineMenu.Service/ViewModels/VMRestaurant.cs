using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineMenu.Service.ViewModels
{
    public class VMRestaurant
    {
        public System.Guid Id { get; set; }
        public System.Guid CountryId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public byte[] Logo { get; set; }
        public Nullable<decimal> ServiceTax { get; set; }
        public Nullable<System.DateTime> CreateDate { get; set; }
        public Nullable<System.DateTime> LastModifiedDate { get; set; }
        public string LastModifiedBy { get; set; }

        public virtual VMCountry Country { get; set; }
        public virtual ICollection<VMMenuCategory> MenuCategories { get; set; }
        public virtual ICollection<VMSubscription> Subscriptions { get; set; }
        public virtual ICollection<VMTable> Tables { get; set; }
        public virtual ICollection<VMUser> Users { get; set; }
    }
}