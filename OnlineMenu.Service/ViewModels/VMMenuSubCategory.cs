using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineMenu.Service.ViewModels
{
    public class VMMenuSubCategory
    {
        public System.Guid Id { get; set; }
        public System.Guid MenuCategoryId { get; set; }
        public string Tittle { get; set; }
        public string Subtitle { get; set; }
        public string Footer { get; set; }

        [Required]
        public Nullable<int> Sequency { get; set; }

        public virtual VMMenuCategory MenuCategory { get; set; }
        public virtual ICollection<VMMenuItem> MenuItems { get; set; }
    }
}