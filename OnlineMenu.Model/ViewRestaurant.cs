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
    
    public partial class ViewRestaurant
    {
        public System.Guid Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public Nullable<decimal> ServiceTax { get; set; }
        public Nullable<System.DateTime> CreateDate { get; set; }
        public string LogoPath { get; set; }
        public string CountryName { get; set; }
        public decimal GovernmentTax { get; set; }
        public string CurrencySymbol { get; set; }
        public Nullable<int> NoOfTables { get; set; }
        public Nullable<int> MenuCategories { get; set; }
        public Nullable<int> Users { get; set; }
    }
}
