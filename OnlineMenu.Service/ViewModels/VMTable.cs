using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineMenu.Service.ViewModels
{
    public class VMTable
    {
        public System.Guid Id { get; set; }
        public System.Guid RestaurantId { get; set; }
        public int Number { get; set; }
        public string Status { get; set; }

        public virtual ICollection<VMOrder> Orders { get; set; }
        public virtual VMRestaurant Restaurant { get; set; }
    }
}