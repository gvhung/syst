//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Logic_Layer
{
    using System;
    using System.Collections.Generic;
    
    public partial class Customer
    {
        public Customer()
        {
            this.FinancialIncome = new HashSet<FinancialIncome>();
        }
    
        public string CustomerID { get; set; }
        public string CustomerName { get; set; }
        public string CustomerCategory { get; set; }
    
        public virtual ICollection<FinancialIncome> FinancialIncome { get; set; }
    }
}