using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineMenu.Service.ViewModels
{
    public class VMOrderItem
    {
        public System.Guid Id { get; set; }
        public System.Guid OrderId { get; set; }
        public System.Guid MenuItemId { get; set; }
        public int Quantity { get; set; }
        public string Notes { get; set; }

        public virtual VMMenuItem MenuItem { get; set; }
        public virtual VMOrder Order { get; set; }
    }
}