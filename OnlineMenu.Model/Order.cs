//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace OnlineMenu.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class Order
    {
        public System.Guid Id { get; set; }
        public System.Guid UserId { get; set; }
        public System.Guid TableId { get; set; }
        public string UserName { get; set; }
        public string Status { get; set; }
        public Nullable<System.DateTime> DateTime { get; set; }
    
        public virtual OrderItem OrderItem { get; set; }
        public virtual Table Table { get; set; }
        public virtual User User { get; set; }
    }
}