using OnlineMenu.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineMenu.Service.ViewModels
{
    public class VMCategoryVsItem
    {
        public System.Guid Id { get; set; }
        public System.Guid CategoryId { get; set; }
        public System.Guid ItemId { get; set; }

        [Required]
        public Nullable<int> Sequence { get; set; }

        public virtual VMCategory Category { get; set; }
        public virtual VMItem Item { get; set; }
    }
}