using OnlineMenu.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineMenu.Service.ViewModels
{
    public class VMUserVsRestaurant
    {
        public System.Guid Id { get; set; }
        public System.Guid UserId { get; set; }
        public System.Guid RestaurantId { get; set; }

        public virtual VMRestaurant Restaurant { get; set; }
        public virtual VMUser User { get; set; }
    }
}