using OnlineMenu.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace OnlineMenu.Service.ViewModels
{
    public class VMPage
    {
        public System.Guid Id { get; set; }
        public System.Guid RestaurantId { get; set; }
        public string Title { get; set; }
        public int Sequence { get; set; }

        public virtual ICollection<Category> Categories { get; set; }
        public virtual Restaurant Restaurant { get; set; }
    }
}