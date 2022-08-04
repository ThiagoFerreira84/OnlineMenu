using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineMenu.Service.ViewModels
{
    public class VMSubscription
    {
        public System.Guid Id { get; set; }
        public System.Guid RestaurantId { get; set; }
        public Nullable<System.DateTime> ActivationDate { get; set; }
        public Nullable<System.DateTime> EndDate { get; set; }

        public virtual VMRestaurant Restaurant { get; set; }
    }
}