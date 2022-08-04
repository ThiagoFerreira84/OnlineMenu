using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineMenu.Service.ViewModels
{
    public class VMMenuCategory
    {
        public System.Guid Id { get; set; }
        public System.Guid RestaurantId { get; set; }
        public string Title { get; set; }
        public string Subtitle { get; set; }
        public string Footer { get; set; }
        public byte[] BackgroundImage { get; set; }
        public Nullable<int> Sequence { get; set; }

        public virtual VMRestaurant Restaurant { get; set; }
        public virtual ICollection<VMMenuItem> MenuItems { get; set; }
        public virtual ICollection<VMMenuSubCategory> MenuSubCategories { get; set; }
    }
}