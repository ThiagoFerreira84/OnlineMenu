using System;
using System.Collections.Generic;
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
        public string Name { get; set; }
        public string Description { get; set; }
        public Nullable<bool> Vegan { get; set; }
        public Nullable<bool> Vegetarian { get; set; }
        public Nullable<bool> GlutenFree { get; set; }
        public Nullable<bool> ChefRecommendation { get; set; }
        public decimal PriceSmall { get; set; }
        public Nullable<decimal> PriceBig { get; set; }
        public string Type { get; set; }
        public byte[] Photo { get; set; }
        public Nullable<int> Sequency { get; set; }

        public virtual VMMenuCategory MenuCategory { get; set; }
        public virtual VMMenuSubCategory MenuSubCategory { get; set; }
        public virtual ICollection<VMOrderItem> OrderItems { get; set; }
    }
}