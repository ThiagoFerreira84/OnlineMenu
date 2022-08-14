using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineMenu.Service.ViewModels
{
    public class VMMenuItem
    {
        public System.Guid Id { get; set; }
        public System.Guid MenuCategoryId { get; set; }
        public System.Guid MenuSubCategoryId { get; set; }

        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        public Nullable<bool> Vegan { get; set; }
        public Nullable<bool> Vegetarian { get; set; }

        [Display(Name = "Gluten Free")]
        public Nullable<bool> GlutenFree { get; set; }

        [Display(Name = "Chef Recommendation")]
        public Nullable<bool> ChefRecommendation { get; set; }

        [Required]
        [Display(Name = "Price Small (Default)")]
        public decimal PriceSmall { get; set; }

        [Display(Name = "Price Big")]
        public Nullable<decimal> PriceBig { get; set; }

        public string Type { get; set; }
        public string Photo { get; set; }

        [Required]
        public Nullable<int> Sequence { get; set; }

        public virtual VMMenuCategory MenuCategory { get; set; }
        public virtual VMMenuSubCategory MenuSubCategory { get; set; }
        public virtual ICollection<VMOrderItem> OrderItems { get; set; }
    }
}