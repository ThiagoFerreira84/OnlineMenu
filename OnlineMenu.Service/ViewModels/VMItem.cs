using Microsoft.Practices.ObjectBuilder2;
using OnlineMenu.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineMenu.Service.ViewModels
{
    public class VMItem
    {
        public System.Guid Id { get; set; }
        public System.Guid CategoryId { get; set; }
        public System.Guid SubCategoryId { get; set; }

        [Required]
        public string Name { get; set; }

        public string Description { get; set; }
        public bool Vegan { get; set; }
        public bool Vegetarian { get; set; }

        [Display(Name = "Gluten Free")]
        public bool GlutenFree { get; set; }

        [Display(Name = "Chef Recommendation")]
        public bool ChefRecommendation { get; set; }

        [Required]
        [Display(Name = "Price Small (Default)")]
        public decimal PriceSmall { get; set; }

        [Display(Name = "Price Big")]
        public Nullable<decimal> PriceBig { get; set; }

        public string Type { get; set; }

        public string Photo { get; set; }

        public int Sequence { get; set; }

        public virtual ICollection<VMCategoryVsItem> CategoryVsItems { get; set; }
        public virtual ICollection<VMOrderItem> OrderItems { get; set; }
        public virtual ICollection<VMSubCategoryVsItem> SubCategoryVsItems { get; set; }
    }
}