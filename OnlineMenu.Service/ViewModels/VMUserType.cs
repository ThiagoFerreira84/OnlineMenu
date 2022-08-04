using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineMenu.Service.ViewModels
{
    public class VMUserType
    {
        public System.Guid Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<VMUser> Users { get; set; }
    }
}