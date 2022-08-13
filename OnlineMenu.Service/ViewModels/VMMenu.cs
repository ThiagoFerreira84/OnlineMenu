using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineMenu.Service.ViewModels
{
    public class VMMenu
    {
        public virtual ICollection<VMMenuCategory> VMMenuCategories { get; set; }
    }
}