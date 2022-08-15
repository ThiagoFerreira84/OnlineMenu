using OnlineMenu.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineMenu.Service.ViewModels
{
    public class VMUser
    {
        public System.Guid Id { get; set; }
        public System.Guid UserTypeId { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }

        public virtual ICollection<VMOrder> Orders { get; set; }
        public virtual VMUserType UserType { get; set; }
        public virtual ICollection<VMUserVsRestaurant> UserVsRestaurants { get; set; }
    }
}