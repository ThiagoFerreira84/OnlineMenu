using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineMenu.Service.ViewModels
{
    public class VMOrder
    {
        public System.Guid Id { get; set; }
        public System.Guid UserId { get; set; }
        public System.Guid TableId { get; set; }
        public string UserName { get; set; }
        public string Status { get; set; }
        public Nullable<System.DateTime> DateTime { get; set; }

        public virtual VMOrderItem OrderItem { get; set; }
        public virtual VMTable Table { get; set; }
        public virtual VMUser User { get; set; }
    }
}