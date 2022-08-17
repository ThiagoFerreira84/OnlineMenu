using OnlineMenu.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineMenu.Service.ViewModels
{
    public class VMCategory
    {
        public System.Guid Id { get; set; }
        public System.Guid RestaurantId { get; set; }
        public string Title { get; set; }
        public string Subtitle { get; set; }
        public string Footer { get; set; }
        public byte[] BackgroundImage { get; set; }

        [Required]
        public Nullable<int> Sequence { get; set; }

        public virtual ICollection<VMItem> Items { get; set; }
        public virtual VMRestaurant Restaurant { get; set; }
    }
}